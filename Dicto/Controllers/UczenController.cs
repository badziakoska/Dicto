using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dicto.Repozytorium;
using Dicto.Models;
using Dicto.Enums;

namespace Dicto.Controllers
{
    public class UczenController : Controller
    {
        IRepository<Uczen> uczniowie;

        public UczenController(IRepository<Uczen> uczniowie)
        {
            this.uczniowie = uczniowie;
        }
        
        // GET: Uczniowie
        public ActionResult Index() => View(uczniowie.Collection().OrderBy(u => u.Nazwisko));
        

        public ActionResult Create()
        {
            Uczen uczen = new Uczen();
            return View(uczen);
        }
        [HttpPost]
        public ActionResult Create(Uczen uczen)
        {
            if (!ModelState.IsValid)
            {
                return View(uczen);
            }
            else
            {
                uczniowie.Insert(uczen);
                uczniowie.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Uczen uczen = uczniowie.Find(Id);
            if (uczen == null)
            {
                return NotFound();
            }
            else
            {
                return View(uczen);
            }
        }
        [HttpPost]
        public ActionResult Edit(Uczen uczen, string Id)
        {
            Uczen uczenToEdit = uczniowie.Find(Id);
            if (uczenToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(uczen);
                }
                uczenToEdit.Imie = uczen.Imie;
                uczenToEdit.Nazwisko = uczen.Nazwisko;
                uczenToEdit.IdGrupy = uczen.IdGrupy;
                uczenToEdit.IdDziennika = uczen.IdDziennika;
                uczenToEdit.Diagnoza = uczen.Diagnoza;
                uczenToEdit.OpisWady = uczen.OpisWady;
                uczenToEdit.Uwagi = uczen.Uwagi;
                uczenToEdit.PlanPracy = uczen.PlanPracy;
                uczniowie.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Uczen uczenToDelete = uczniowie.Find(Id);
            if (uczenToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(uczenToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Uczen uczenToDelete = uczniowie.Find(Id);
            if (uczenToDelete == null)
            {
                return NotFound();
            }
            else
            {
                uczniowie.Delete(Id);
                uczniowie.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}