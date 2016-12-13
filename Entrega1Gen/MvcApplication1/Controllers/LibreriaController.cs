using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.EN.GrayLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entrega1GenNHibernate.CAD.GrayLine;
using System.IO;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class LibreriaController : BasicController
    {
        //
        // GET: /Libreria/

        public ActionResult Index()
        {
            LibroCEN cen = new LibroCEN();
            IEnumerable<LibroEN> list = cen.VerLibreria(0, -1).ToList();

            return View(list);
        }

        //
        // GET: /Libreria/Details/5

        public ActionResult Details(int id)
        {
           
            LibroCEN cen = new LibroCEN();
            LibroEN libroEN = new LibroEN();
            //string idString = id.ToString();
            libroEN = cen.VerLibro(id);
            return View(libroEN);
        }

        //
        // GET: /Libreria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Libreria/Create

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

        //
        // GET: /Libreria/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Libreria/Edit/5

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

        //
        // GET: /Libreria/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Libreria/Delete/5

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
