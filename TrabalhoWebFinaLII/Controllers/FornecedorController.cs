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
    public class FornecedorController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fornecedor
        public ActionResult Index()
        {
            {
                return View(context.Fornecedores.OrderBy(c => c.NomeFornecedor));
            }
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var fornecedor = context.Fornecedores.Find(id);
                if (fornecedor == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(Fornecedor  fornecedor)
        {

            try
            {
                // TODO: Add insert logic here
                context.Fornecedores.Add(fornecedor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = context.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fornecedor).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = context.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Fornecedor fornecedor = context.Fornecedores.Find(id);
                context.Fornecedores.Remove(fornecedor);
                context.SaveChanges();
                TempData["Message"] = "fornecedor" + fornecedor.NomeFornecedor.ToUpper() + "foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
