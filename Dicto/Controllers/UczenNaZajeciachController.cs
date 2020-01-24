using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;
using Dicto.Repozytorium;
using Microsoft.AspNetCore.Mvc;

namespace Dicto.Controllers
{
    public class UczenNaZajeciachController : Controller
    {
        IRepository<UczenNaZajeciach> obecnosci;
        public UczenNaZajeciachController(IRepository<UczenNaZajeciach> obecnosci)
        {
            this.obecnosci = obecnosci;
        }

        // GET: Uczniowie
        public ActionResult Index() => View(obecnosci.Collection());


        public ActionResult Create()
        {
            UczenNaZajeciach obecnosc = new UczenNaZajeciach();
            return View(obecnosc);
        }
        [HttpPost]
        public ActionResult Create(UczenNaZajeciach obecnoscNaZajeciach)
        {
            if (!ModelState.IsValid)
            {
                return View(obecnoscNaZajeciach);
            }
            else
            {
                obecnosci.Insert(obecnoscNaZajeciach);
                obecnosci.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            UczenNaZajeciach obecnosc = obecnosci.Find(Id);
            if (obecnosc == null)
            {
                return NotFound();
            }
            else
            {
                return View(obecnosc);
            }
        }
        [HttpPost]
        public ActionResult Edit(UczenNaZajeciach obecnoscNaZajeciach, string Id)
        {
            UczenNaZajeciach obecnoscToEdit = obecnosci.Find(Id);
            if (obecnoscToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(obecnoscNaZajeciach);
                }
                obecnoscToEdit.Obecnosc = obecnoscNaZajeciach.Obecnosc;
                obecnoscToEdit.PostepUcznia = obecnoscNaZajeciach.PostepUcznia;
                obecnosci.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            UczenNaZajeciach obecnoscToDelete = obecnosci.Find(Id);
            if (obecnoscToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(obecnoscToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            UczenNaZajeciach obecnoscToDelete = obecnosci.Find(Id);
            if (obecnoscToDelete == null)
            {
                return NotFound();
            }
            else
            {
                obecnosci.Delete(Id);
                obecnosci.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}