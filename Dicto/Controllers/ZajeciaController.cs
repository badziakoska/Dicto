using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;
using Dicto.Repozytorium;
using Microsoft.AspNetCore.Mvc;

namespace Dicto.Controllers
{
    public class ZajeciaController : Controller
    {
        IRepository<Zajecia>  wszystkieZajecia;
        public ZajeciaController(IRepository<Zajecia> wszystkieZajecia)
        {
            this.wszystkieZajecia = wszystkieZajecia;
        }

        // GET: Uczniowie
        public ActionResult Index() => View(wszystkieZajecia.Collection());


        public ActionResult Create()
        {
            Zajecia zajecia = new Zajecia();
            return View(zajecia);
        }
        [HttpPost]
        public ActionResult Create(Zajecia zajecia)
        {
            if (!ModelState.IsValid)
            {
                return View(zajecia);
            }
            else
            {
                wszystkieZajecia.Insert(zajecia);
                wszystkieZajecia.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Zajecia zajecia = wszystkieZajecia.Find(Id);
            if (zajecia == null)
            {
                return NotFound();
            }
            else
            {
                return View(zajecia);
            }
        }
        [HttpPost]
        public ActionResult Edit(Zajecia zajecia, string Id)
        {
            Zajecia zajeciaToEdit = wszystkieZajecia.Find(Id);
            if (zajeciaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(zajecia);
                }
                zajeciaToEdit.Data = zajecia.Data;
                zajeciaToEdit.Temat = zajecia.Temat;
                zajeciaToEdit.Scenariusz = zajecia.Scenariusz;
                wszystkieZajecia.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Zajecia zajeciaToDelete = wszystkieZajecia.Find(Id);
            if (zajeciaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(zajeciaToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Zajecia zajeciaToDelete = wszystkieZajecia.Find(Id);
            if (zajeciaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                wszystkieZajecia.Delete(Id);
                wszystkieZajecia.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}