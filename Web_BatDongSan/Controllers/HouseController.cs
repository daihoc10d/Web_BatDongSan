using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BatDongSan.Models;

namespace Web_BatDongSan.Controllers
{
    public class HouseController : Controller
    {
        // GET: House
        BDSContext context = new BDSContext();
        public ActionResult ListHouse()
        {
            

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
        

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, House b)
        {
            BDSContext context = new BDSContext();
           
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
                b.Code = E_Code.ToString();
                b.Name = E_Name.ToString();
                b.Sumary = E_Sumary.ToString();
                b.Price = a;
                context.Houses.Add(b);
                context.SaveChanges();
            }
            return RedirectToAction("listHouse");
        }

        public ActionResult Edit(int id)
        {
            BDSContext context = new BDSContext();
            var E_category = context.Houses.First(m => m.IDHouse == id);
            return View(E_category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, House b)
        {
            BDSContext context = new BDSContext();
            var E_sach = context.Houses.FirstOrDefault(m => m.IDHouse == id);
            var E_id = collection["Code"];
            var E_idtk = collection["Id"];
            var E_idDUAN = collection["IDDuAn"];
            var E_title = collection["Name"];
            var E_description = collection["Sumary"];
            var E_author = collection["BedRoom"];
            var E_images = collection["Area"];
            var E_price = decimal.Parse(collection["Price"]);
            var E_State = collection["State"];
            if (string.IsNullOrEmpty(E_id))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                b.Code = E_id;
                b.Id = E_idtk;
                b.IDDuAn = int.Parse(E_idDUAN);
                b.Name = E_title.ToString();
                b.Sumary = E_description.ToString();
                b.BedRoom = int.Parse(E_author);
                b.Area = int.Parse(E_images.ToString());
                b.Price = int.Parse(E_price.ToString());
                b.State = byte.Parse(E_State);
                context.Houses.AddOrUpdate(b);
                context.SaveChanges();
            }
            return RedirectToAction("ListHouse");
        }
        //public ActionResult Delete(int id)
        //{
        //    Modelcontext context = new Modelcontext();
        //    var D_sach = context.Book1.First(m => m.ID == id);
        //    return View(D_sach);
        //}

        //[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            BDSContext context = new BDSContext();
            House dbDelete = context.Houses.FirstOrDefault(p => p.IDHouse == id);
            if (dbDelete != null)
            {
                context.Houses.Remove(dbDelete);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
    }
}