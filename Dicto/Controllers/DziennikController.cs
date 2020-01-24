using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dicto.Models;
using Dicto.Repozytorium;

namespace Dicto.Controllers
{
    public class DziennikController : Controller
    {
        IRepository<Dziennik> dzienniki;
        IEnumerable<Uczen> uczniowie;

        public DziennikController(IRepository<Dziennik> dzienniki, IRepository<Uczen> uczniowie)
        {
            this.dzienniki = dzienniki;
            //wyselekcjonowanie listy uczniów z danego dziennika
            //TO DO - POPRAWIĆ FILTROWANIE NA AUTOMATYCZNE
            this.uczniowie = uczniowie.Collection();
        }

        // GET: Uczniowie
        public ActionResult Index() => View(dzienniki.Collection());


        public ActionResult Create()
        {
            Dziennik dziennik = new Dziennik();
            return View(dziennik);
        }
        [HttpPost]
        public ActionResult Create(Dziennik dziennik)
        {
            if (!ModelState.IsValid)
            {
                return View(dziennik);
            }
            else
            {
                dzienniki.Insert(dziennik);
                dzienniki.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Dziennik dziennik = dzienniki.Find(Id);
            if (dziennik == null)
            {
                return NotFound();
            }
            else
            {
                return View(dziennik);
            }
        }
        [HttpPost]
        public ActionResult Edit(Dziennik dziennik, string Id)
        {
            Dziennik dziennikToEdit = dzienniki.Find(Id);
            if (dziennikToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(dziennik);
                }
                dziennikToEdit.Nazwa = dziennik.Nazwa;
                dziennikToEdit.Rok = dziennik.Rok;
                dzienniki.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Dziennik dziennikToDelete = dzienniki.Find(Id);
            if (dziennikToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(dziennikToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Dziennik dziennikToDelete = dzienniki.Find(Id);
            if (dziennikToDelete == null)
            {
                return NotFound();
            }
            else
            {
                dzienniki.Delete(Id);
                dzienniki.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Open(string Id)
        {
            Dziennik dziennik = dzienniki.Find(Id);
            ViewBag.NazwaDziennika = dziennik.Nazwa;
            if (dziennik == null)
            {
                return NotFound();
            }
            else
            {
                return View(uczniowie.OrderBy(u=>u.Nazwisko));
            }
        }
    }
}