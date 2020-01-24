using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;
using Dicto.Repozytorium;
using Microsoft.AspNetCore.Mvc;

namespace Dicto.Controllers
{
    public class TerapeutaController : Controller
    {
        IRepository<Terapeuta> terapeuci;

        public TerapeutaController(IRepository<Terapeuta> terapeuci)
        {
            this.terapeuci = terapeuci;
        }

        // GET: Grupy
        public ActionResult Index() => View(terapeuci.Collection());


        public ActionResult Create()
        {
            Terapeuta terapeuta = new Terapeuta();
            return View(terapeuta);
        }
        [HttpPost]
        public ActionResult Create(Terapeuta terapeuta)
        {
            if (!ModelState.IsValid)
            {
                return View(terapeuta);
            }
            else
            {
                terapeuci.Insert(terapeuta);
                terapeuci.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Terapeuta terapeuta = terapeuci.Find(Id);
            if (terapeuta == null)
            {
                return NotFound();
            }
            else
            {
                return View(terapeuta);
            }
        }
        [HttpPost]
        public ActionResult Edit(Terapeuta terapeuta, string Id)
        {
            Terapeuta terapeutaToEdit = terapeuci.Find(Id);
            if (terapeutaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(terapeuta);
                }
                terapeutaToEdit.Imie = terapeuta.Imie;
                terapeutaToEdit.Nazwisko = terapeuta.Nazwisko;
                terapeutaToEdit.Email = terapeuta.Email;
                terapeutaToEdit.Haslo = terapeuta.Haslo;
                terapeuci.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Terapeuta terapeutaToDelete = terapeuci.Find(Id);
            if (terapeutaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(terapeutaToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Terapeuta terapeutaToDelete = terapeuci.Find(Id);
            if (terapeutaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                terapeuci.Delete(Id);
                terapeuci.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}