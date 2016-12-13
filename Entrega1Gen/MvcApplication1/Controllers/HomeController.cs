
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using System.IO;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      /*  public ActionResult Destacados()
        {
            LibroCEN cen = new LibroCEN();
            IEnumerable<LibroEN> list = cen.VerLibreria(0, -1).ToList();

            return PartialView("_DestacadosPartial", list);
        }
        */
    }
}
