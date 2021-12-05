using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoWebFinaLII.Context;
using TrabalhoWebFinaLII.Models;

namespace TrabalhoWebFinaLII.Controllers
{
    public class LojaController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Loja
        public ActionResult Index()
        {
            {
                return View(context.Lojas.OrderBy(c => c.NomeLoja));
            }
        }


        // GET: Loja/Details/5
        public ActionResult Details(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var loja = context.Lojas.Find(id);
                if (loja == null)
                {
                    return HttpNotFound();
                }
                return View(loja);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: Loja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loja loja)
        {
            try
            {
                // TODO: Add insert logic here
                context.Lojas.Add(loja);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loja/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = context.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Loja/Edit/5
        [HttpPost]
        public ActionResult Edit(Loja loja)
        {
            if (ModelState.IsValid)
            {
                context.Entry(loja).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loja);
        }

        // GET: Loja/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja lojas = context.Lojas.Find(id);
            if (lojas == null)
            {
                return HttpNotFound();
            }
            return View(lojas);
        }

        // POST: Loja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Loja loja = context.Lojas.Find(id);
                context.Lojas.Remove(loja);
                context.SaveChanges();
                TempData["Message"] = "Loja" + loja.NomeLoja.ToUpper() + "foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
