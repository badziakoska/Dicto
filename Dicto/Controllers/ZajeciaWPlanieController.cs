using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;
using Dicto.Repozytorium;
using Microsoft.AspNetCore.Mvc;

namespace Dicto.Controllers
{
    public class ZajeciaWPlanieController : Controller
    {
        IRepository<ZajeciaWPlanie> planZajec;
        public ZajeciaWPlanieController(IRepository<ZajeciaWPlanie> planZajec)
        {
            this.planZajec = planZajec;
        }

        // GET: Uczniowie
        public ActionResult Index() => View(planZajec.Collection());


        public ActionResult Create()
        {
            ZajeciaWPlanie zajecia = new ZajeciaWPlanie();
            return View(zajecia);
        }
        [HttpPost]
        public ActionResult Create(ZajeciaWPlanie zajecia)
        {
            if (!ModelState.IsValid)
            {
                return View(zajecia);
            }
            else
            {
                planZajec.Insert(zajecia);
                planZajec.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ZajeciaWPlanie zajecia = planZajec.Find(Id);
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
        public ActionResult Edit(ZajeciaWPlanie zajecia, string Id)
        {
            ZajeciaWPlanie zajeciaToEdit = planZajec.Find(Id);
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
                zajeciaToEdit.DzienTygodnia = zajecia.DzienTygodnia;
                zajeciaToEdit.GodzinaRozpoczecia = zajecia.GodzinaRozpoczecia;
                zajeciaToEdit.GodzinaZakonczenia = zajecia.GodzinaZakonczenia;
                planZajec.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ZajeciaWPlanie zajeciaToDelete = planZajec.Find(Id);
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
            ZajeciaWPlanie zajeciaToDelete = planZajec.Find(Id);
            if (zajeciaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                planZajec.Delete(Id);
                planZajec.Commit();
                return RedirectToAction("Index");
            }
        }
 
    }
}