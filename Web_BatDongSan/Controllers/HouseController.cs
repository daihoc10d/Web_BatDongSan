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
        BDSContext db =new BDSContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TopHouse(bool? IsBan)
        {
            var lst = db.Houses.Where(q => q.State != MState.DELETE).Take(3 * 1).ToList();
            foreach (var item in lst)
            {
                item.xImage = item.ImagesHouses.FirstOrDefault(q => q.IDHouse == item.IDHouse && q.Rank == 0);
                //item.xAddress1 = @item.AddressHouses.FirstOrDefault(q => q.Address.Rank == 1)?.Address;
                //item.xAddress2 = @item.AddressHouses.FirstOrDefault(q => q.Address.Rank == 2)?.Address;
                //item.xAddress3 = @item.AddressHouses.FirstOrDefault(q => q.Address.Rank == 3)?.Address;
            }

            ViewBag.IsBan = IsBan;
            return View(lst);
        }
    }
}