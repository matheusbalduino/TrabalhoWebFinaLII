using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoWebFinaLII.Context;

namespace TrabalhoWebFinaLII.Controllers
{
    public class ProdutoController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Produto
        public ActionResult Index()
        {
            return View(context.Produtos.OrderBy(context => context.Nome));
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.LojaId = new SelectList(context.Lojas.OrderBy(L => L.NomeLoja),
              "Loja", "Nome");
                ViewBag.FornecedorId = new SelectList(context.Fornecedores.OrderBy(f => f.NomeFornecedor),
                    "FornecedorId", "Nome");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
