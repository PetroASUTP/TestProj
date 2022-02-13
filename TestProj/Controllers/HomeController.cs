using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {

            db.datacreate();

            var warehouse = db.Warehouse;

            ViewBag.Warehouse = warehouse;

            return View();
        }



        public ActionResult Nomenclature(int Id)
        {

            //db.datacreate();

            var nomenclature = db.Nomenclature.Where(c=>c.WarehouseId==Id);

            ViewBag.Nomenclature = nomenclature;
            ViewBag.Warehouse = db.Warehouse.FirstOrDefault(c=>c.Id==Id).Name;

            return PartialView();
        }



        public ActionResult Product(int Id)
        {

            var products = db.Product.Where(c => c.NomenclatureId == Id);

            ViewBag.Product = products;
            ViewBag.Nomenclature = "Количество единиц товара:"+products.Count();

            return PartialView();
        }

        public ActionResult NomenclatureItem(int Id)
        {
            var nomenclature = db.Nomenclature.FirstOrDefault(c => c.Id == Id);
            ViewBag.Nomenclature = nomenclature;
            ViewBag.Warehouse = db.Warehouse.FirstOrDefault(c=>c.Id==nomenclature.WarehouseId).Name;
            ViewBag.List = new SelectList(db.Warehouse, "Id", "Name");
            ViewBag.MoveHistory = db.MoveNomenclature.Where(c => c.NomenclatureId == Id).ToList();
            ViewBag.Product = db.Product.Where(c => c.NomenclatureId == Id).ToList();
            ViewBag.Count = db.Product.Where(c=>c.NomenclatureId==Id).ToList().Count();
            return View();
        }


        public ActionResult SaveMove(int IdN, int IdWar)
        {
            Nomenclature nomenclature = db.Nomenclature.FirstOrDefault(c => c.Id == IdN);
            db.MoveNomenclature.Add(new MoveNomenclature() { NomenclatureId = IdN,fromId= nomenclature.WarehouseId, ToId= IdWar, date=DateTime.Now });
            nomenclature.WarehouseId = IdWar;
            
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }




        public ActionResult ProductItem(int Id)
        {
            var product = db.Product.FirstOrDefault(c => c.Id == Id);
            ViewBag.Name = product.Name;
            ViewBag.Id = product.Id;
            ViewBag.NoName = product.getnomname;
            ViewBag.ProductHistory = db.MovingProduct.Where(c=>c.productId==Id).ToList();
            var list  = new SelectList(db.Nomenclature, "Id", "Name");
            ViewBag.List = list;
            return View();
        }


        public ActionResult SaveMoveProduct(int Id, int IdN)
        {
            Product product = db.Product.FirstOrDefault(c => c.Id == Id);
            db.MovingProduct.Add(new MovingProduct() { productId = Id, fromid = product.NomenclatureId, toid = IdN, date = DateTime.Now });
            product.NomenclatureId = IdN;

            db.SaveChanges();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }





    }
}