using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.EN.GrayLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcApplication1.Models;
using Entrega1GenNHibernate.CAD.GrayLine;


namespace MvcApplication1.Controllers
{
    public class CapitulosController : BasicController
    {
        //
        // GET: /Capitulos/

        public ActionResult Index(string idLibro)
        {

            int id = Int32.Parse(idLibro);
            CapituloCEN cen = new CapituloCEN();
            IEnumerable<CapituloEN> list = cen.BuscarCapitulo(id).ToList();

            return View(list);

        }

        //
        // GET: /Capitulos/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Capitulos/Create

        public ActionResult Create()
        {
            return View();
        }
        //
        // GET: /Capitulos/listadoCapitulo/5

        public ActionResult listadoCapitulo(string idLibro)
        {
            int id = Int32.Parse(idLibro);
            CapituloCEN cen = new CapituloCEN();
            IEnumerable<CapituloEN> list = cen.BuscarCapitulo(id).ToList();

            return View(list);

        }

        //
        // POST: /Capitulos/Create

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
        // GET: /Capitulos/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Capitulos/Edit/5

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
        // GET: /Capitulos/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Capitulos/Delete/5

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
