﻿using System;
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
    public class ProdutoController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Produto
        public ActionResult Index()
        {
            try
            {
                IQueryable<Produto> produtos = context.Produtos.OrderBy(context => context.Nome)
                                       .Include(l => l.Loja)
                                       .Include(f => f.Fornecedor);
                
                return View(produtos.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // GET: Produto/Details/5
        public ActionResult Details(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var produto = innerJoinProduto(id);
                if (produto == null)
                {
                    return HttpNotFound();
                }
                return View(produto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.LojaId = new SelectList(context.Lojas.OrderBy(L => L.NomeLoja),
              "LojaId", "NomeLoja");
                ViewBag.FornecedorId = new SelectList(context.Fornecedores.OrderBy(f => f.NomeFornecedor),
                    "FornecedorId", "NomeFornecedor");
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {

                context.Produtos.Add(produto);
                context.SaveChanges();

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
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = innerJoinProduto(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Produto Produto = context.Produtos.Find(id);
                context.Produtos.Remove(Produto);
                context.SaveChanges();
                TempData["Message"] = "Produto" + Produto.Nome.ToUpper() + "foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        private Produto innerJoinProduto(long? id)
        {
            IQueryable<Produto> produto = context.Produtos.Where(p => p.ProdutoId == id);

            produto = produto.Include(l => l.Loja).Include(f => f.Fornecedor);

            if (produto == null)
            {
                return null;
            }
            return produto.FirstOrDefault();

        }
    }
}
