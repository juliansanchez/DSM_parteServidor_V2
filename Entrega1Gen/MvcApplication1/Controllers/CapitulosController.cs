using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CP.GrayLine;
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

               /*   int id = Int32.Parse(idLibro);
               CapituloCP cp = new CapituloCP();
               //CapituloCEN cen = new CapituloCEN();
               CapituloEN capituloEN = new CapituloEN();
               IList<CapituloEN> capitulos = cp.LeerCapitulo(id);
               //string idString = id.ToString();

               //    capituloEN = cp.LeerCapitulo(id);
               return View(capitulos);
               */

        }

        //
        // GET: /Capitulos/Details/5

        public ActionResult Details(int id)
        {
            CapituloCEN cen = new CapituloCEN();
            //CapituloCEN cen = new CapituloCEN();
            CapituloEN capituloEN = new CapituloEN();
            capituloEN = cen.VerCapitulo(id);
            //string idString = id.ToString();
          
        //    capituloEN = cp.LeerCapitulo(id);
            return View(capituloEN);


           
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


        // GET: /Capitulos/listadoCapituloPartial/5

        public ActionResult listadoCapituloPartial(string idLibro)
        {
            int id = Int32.Parse(idLibro);
            CapituloCEN cen = new CapituloCEN();
            IEnumerable<CapituloEN> list = cen.BuscarCapitulo(id).ToList();



            return PartialView("_listadoCapituloPartial",list);

        }

        //

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
            //aqui tenemos que cargar al dueño o al invitado
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
