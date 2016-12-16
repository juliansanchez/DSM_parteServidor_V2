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

        public ActionResult CreateGratis()
        {
            Libro libr = null;

            return View(libr);

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
                UsuarioCEN UsuCEN=new UsuarioCEN();
                IList<UsuarioEN> listaUsu= UsuCEN.ReadAll(0,1);
                UsuarioEN usu = new UsuarioEN();
                usu= listaUsu[0];
                string emailUsu = usu.Email; 
                CategoriaCEN CategoriaCEN=new CategoriaCEN();
                IList<CategoriaEN> CategoriaList= CategoriaCEN.VerCategorias(0,1);
                   System.Collections.Generic.List<int> Cate = new List<int>();
       /*         Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.fantasia
                Cate.Add(Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.fantasia);
                Cate.Add(2);*/

                 CategoriaCEN categoriaCEN=new CategoriaCEN();
                 CategoriaEN categoria_1EN = new CategoriaEN ();
                categoria_1EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.aventura;
                var cat1 = categoriaCEN.New_ (categoria_1EN.Nombre_categoria);
                Cate.Add(cat1);
           
                 GratuitoCEN cen = new GratuitoCEN();
                // cen.New_(libr.titulo, libr.portada, libr.descripcion, DateTime.Today, libr.publicado, usu, CategoriaList, false, 0);
                 cen.New_(libr.titulo, libr.portada, libr.descripcion, DateTime.Today, libr.publicado, emailUsu, Cate, false, 0);
/*
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



        public ActionResult Edit(int id, Libro libr)
        {
            try
            {
                // TODO: Add update logic here
                /*Falta que cambiar furule bien*/
               LibroCEN cen = new LibroCEN();
                cen.CambiarTitulo(id,libr.titulo);
                cen.CambiarPortada(id,libr.portada);
                cen.CambiarDescripcion(id,libr.descripcion);

                var valorGetC = (libr.titulo);
                var valorGetU = (libr.portada);
                var valorGetD = (libr.descripcion);
                return RedirectToAction("Details",new {id = libr.id});
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

            LibroCEN cen = new LibroCEN();

            cen.EliminarLibro(id);

            return RedirectToAction("Index");
        }

        //
        // POST: /Libreria/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                LibroCEN cen = new LibroCEN();
    
                cen.EliminarLibro(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
