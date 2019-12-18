using ppedv.TombstoneStrong.Data.EF;
using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.TombstoneStrong.UI.ASP.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {
            core = new Core(new EFUnitOfWork());
        }
        private Core core;

        // GET: Employee
        public ActionResult Index()
        {
            return View(core.Modul<Employee>().GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Modul<Employee>().GetByID(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new Employee { Name = "Max Mustermann" });
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee newItem)
        {
            try
            {
                core.Modul<Employee>().Add(newItem);
                core.SaveAllUoW();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Modul<Employee>().GetByID(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee updatedItem)
        {
            try
            {
                // TODO: Add update logic here
                core.Modul<Employee>().Update(updatedItem);
                core.SaveAllUoW();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Modul<Employee>().GetByID(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee deleteItem)
        {
            try
            {
                // TODO: Add delete logic here
                core.Modul<Employee>().Delete(deleteItem);
                core.SaveAllUoW();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
