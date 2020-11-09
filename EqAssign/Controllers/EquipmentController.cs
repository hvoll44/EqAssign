using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EqAssign.Models;
using EqAssign.ViewModels;

namespace EqAssign.Controllers
{
    public class EquipmentController : Controller
    {
        private MyDBContext _context;
        public EquipmentController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var equipment = _context.Equipment.SingleOrDefault(e => e.Id == id);

            return View(equipment);

        }


        public ActionResult New()
        {
            var modelTypes = _context.ModelTypes.ToList();
            
            var viewModel = new EquipmentFormViewModel
            {
                Equipment = new Equipment(),
                Models = modelTypes
            };

            ViewBag.PageTitle = "New";

            return View("EquipmentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EquipmentFormViewModel
                {
                    Equipment = equipment,
                    Models = _context.ModelTypes.ToList()
                };

                return View("EquipmentForm", viewModel);
            }
            
            
            if (equipment.Id == 0)
                _context.Equipment.Add(equipment);
            else
            {
                var equipmentInDb = _context.Equipment.Single(e => e.Id == equipment.Id);
                equipmentInDb.Name = equipment.Name;
                equipmentInDb.ModelType = equipment.ModelType;
                equipmentInDb.ManufactureDate = equipment.ManufactureDate;
                equipmentInDb.PurchaseDate = equipment.PurchaseDate;
                equipmentInDb.Stock = equipment.Stock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Equipment");
        }


        public ActionResult Edit(int id)
        {
            var equipment = _context.Equipment.SingleOrDefault(e => e.Id == id);

            if (equipment == null)
                return HttpNotFound();

            var viewModel = new EquipmentFormViewModel
            {
                Equipment = equipment,
                Models = _context.ModelTypes.ToList(),
            };

            ViewBag.PageTitle = "Edit";

            return View("EquipmentForm", viewModel);
        }

        // GET: Equipment/Random
        public ActionResult Random()
        {
            var equipment = new Equipment() { Name = "Sensor 52" };
            var customers = new List<Customer>
            {
                new Customer { Name = "John Smith"},
                new Customer { Name = "Bob Dole"}
            };

            var viewModel = new RandomEquipmentViewModel
            {
                Equipment = equipment,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}