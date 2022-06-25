using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BatDongSan.Models;

namespace Web_BatDongSan.Controllers
{
    public class HouseController : Controller
    {
        // GET: House
        
        public ActionResult ListHouse()
        {
            BDSContext context = new BDSContext();

            var ListHouse = context.Houses.ToList();
            return View(ListHouse);
        }
        public ActionResult Detail(int id)
        {
            BDSContext context = new BDSContext();
            var D_theloai = context.Houses.Where(m => m.IDHouse == id).First();
            return View(D_theloai);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BDSContext context = new BDSContext();
            House house = context.Houses.SingleOrDefault(p => p.IDHouse == id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, House b)
        {
            BDSContext context = new BDSContext();
            var E_id = Convert.ToInt32(collection["IDHouse"]);
            var E_Code = collection["Code"];
            var E_Name = collection["Name"];
            var E_Sumary = collection["Sumary"];
            var E_BedRoom = collection["BedRoom"];

            var E_Area = collection["Area"];
            var E_Price = Convert.ToInt32(collection["Price"]);
            var E_State = collection["State"];
            
            if (string.IsNullOrEmpty(E_Code))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                decimal a = 0;
                try
                {
                    a = Convert.ToDecimal(E_Price.ToString());
                }
                catch
                {
                    a = 0;
                }

                b.IDHouse = E_id;
                b.Code = E_Code.ToString();
                b.Name = E_Name.ToString();
                b.Sumary = E_Sumary.ToString();
                b.Price = a;
                context.Houses.Add(b);
                context.SaveChanges();
            }
            return RedirectToAction("listHouse");
        }

        //public ActionResult Edit(int id)
        //{
        //    Modelcontext context = new Modelcontext();
        //    var E_category = context.Book1.First(m => m.ID == id);
        //    return View(E_category);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, FormCollection collection, Book1 b)
        //{
        //    Modelcontext context = new Modelcontext();
        //    var E_sach = context.Book1.FirstOrDefault(m => m.ID == id);
        //    var E_id = Convert.ToInt32(collection["ID"]);
        //    var E_title = collection["Title"];
        //    var E_description = collection["Description"];
        //    var E_author = collection["Author"];
        //    var E_images = collection["Images"];
        //    var E_price = Convert.ToInt32(collection["Price"]);
        //    if (string.IsNullOrEmpty(E_title))
        //    {
        //        ViewData["Error"] = "Don't empty!";
        //    }
        //    else
        //    {
        //        b.ID = E_id;
        //        b.Title = E_title.ToString();
        //        b.Description = E_description.ToString();
        //        b.Author = E_author.ToString();
        //        b.Images = E_images.ToString();
        //        b.Price = E_price.ToString();
        //        context.Book1.AddOrUpdate(b);
        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("ListBook");
        //}
        //public ActionResult Delete(int id)
        //{
        //    Modelcontext context = new Modelcontext();
        //    var D_sach = context.Book1.First(m => m.ID == id);
        //    return View(D_sach);
        //}

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    Modelcontext context = new Modelcontext();
        //    Book1 dbDelete = context.Book1.FirstOrDefault(p => p.ID == id);
        //    if (dbDelete != null)
        //    {
        //        context.Book1.Remove(dbDelete);
        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("ListBook");
        //}
    }
}