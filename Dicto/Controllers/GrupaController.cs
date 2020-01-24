using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dicto.Models;
using Dicto.Repozytorium;

namespace Dicto.Controllers
{
    public class GrupaController : Controller
    {
        IRepository<Grupa> grupy;

        public GrupaController(IRepository<Grupa> grupy)
        {
            this.grupy = grupy;
        }

        // GET: Grupy
        public ActionResult Index() => View(grupy.Collection());


        public ActionResult Create()
        {
            Grupa grupa = new Grupa();
            return View(grupa);
        }
        [HttpPost]
        public ActionResult Create(Grupa grupa)
        {
            if (!ModelState.IsValid)
            {
                return View(grupa);
            }
            else
            {
                grupy.Insert(grupa);
                grupy.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Grupa grupa = grupy.Find(Id);
            if (grupa == null)
            {
                return NotFound();
            }
            else
            {
                return View(grupa);
            }
        }
        [HttpPost]
        public ActionResult Edit(Grupa grupa, string Id)
        {
            Grupa grupaToEdit = grupy.Find(Id);
            if (grupaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(grupa);
                }
                grupaToEdit.Nazwa = grupa.Nazwa;
                grupaToEdit.PlanPracy = grupa.PlanPracy;
                grupy.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Grupa grupaToDelete = grupy.Find(Id);
            if (grupaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(grupaToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Grupa grupaToDelete = grupy.Find(Id);
            if (grupaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                grupy.Delete(Id);
                grupy.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}