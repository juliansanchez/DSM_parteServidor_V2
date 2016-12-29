using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.EN.GrayLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ComentariosController : BasicController
    {
        //
        // GET: /Comentarios/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Comentarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Comentarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //

        // GET: /Comentarios/Create
        public ActionResult listaComentario(int idLibro)
        {

            //int id = Int32.Parse(idLibro);
            ComentarioCEN cen = new ComentarioCEN();
            IEnumerable<ComentarioEN> list = cen.ComentariosLibro(idLibro).ToList();
               
          
            return PartialView("_listaComentarioPartial", list);

        }


        //

        // POST: /Comentarios/Create

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
        // GET: /Comentarios/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Comentarios/Edit/5

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
        // GET: /Comentarios/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Comentarios/Delete/5

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
