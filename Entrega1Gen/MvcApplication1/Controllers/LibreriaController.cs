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

        // GET: /Libreria/listaDestacados

        public ActionResult listaDestacados()
        {
            LibroCEN cen = new LibroCEN();
            IEnumerable<LibroEN> list = cen.VerLibreria(0, -1).ToList();
            return PartialView("_ListaDestacadosPartial", list);
        }


        //


        // POST: /Libreria/Create

        [HttpPost]
        public ActionResult CreateGratis(Libro libr)
        {
            try
            {
              // TODO: Add insert logic here

      /*          GratuitoCEN cen = new GratuitoCEN();
                cen.New_(libr.titulo, libr.portada,libr.descripcion,libr.fecha,libr.publicado,)

                    gratuitoCEN.New_ (libro1EN.Titulo, libro1EN.Portada, libro1EN.Descripcion, libro1EN.Fecha, libro1EN.Publicado, listaUsuarios, listaCategorias, libro1EN.Baneado, libro1EN.Num_denuncias);
                */

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
            /*
            Articulo art = null;
            SessionInitialize();
            ArticuloEN artEN = new ArticuloCAD(session).ReadOIDDefault(id);
            art = new AssemblerArticulo().ConvertENToModelUI(artEN);
            SessionClose();
            return View(art);
            */

            Libro libr = null;
            SessionInitialize();
            LibroEN libroEN = new LibroCAD(session).ReadOIDDefault(id);
            libr = new AssemblerLibro().ConvertENToModelUI(libroEN);
            SessionClose();
            return View(libr);


        /*   LibroCEN cen = new LibroCEN();
            LibroEN libroEN = new LibroEN();
            //string idString = id.ToString();
            libroEN = cen.VerLibro(id);

            return View(libroEN);*/
        }

        //
        // POST: /Libreria/Edit/5

        [HttpPost]
        public ActionResult Edit(Libro libr)
        {
            try
            {
                LibroCEN cen = new LibroCEN();
               // cen.CambiarTitulo(libr.titulo);
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }



      /*  public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                /*Falta que cambiar furule bien*/
         /*       LibroCEN cen = new LibroCEN();
                cen.CambiarTitulo(collection.Get(1));
                cen.CambiarPortada(collection.Get(2));
                cen.CambiarDescripcion(collection.Get(3));

                var valorGetC = (collection.Get(1));
                var valorGetU = (collection.Get(2));
                var valorGetD = (collection.Get(3));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

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
