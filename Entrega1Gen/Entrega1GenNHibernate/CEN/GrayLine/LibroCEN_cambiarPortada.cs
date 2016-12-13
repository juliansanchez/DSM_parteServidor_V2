
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Libro_cambiarPortada) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class LibroCEN
{
public void CambiarPortada (int p_Libro_OID, string p_portada)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Libro_cambiarPortada_customized) START*/

        LibroEN libroEN = null;

        //Initialized LibroEN
        libroEN = new LibroEN ();
        libroEN.Id_libro = p_Libro_OID;
        libroEN.Portada = p_portada;
        //Call to LibroCAD

        _ILibroCAD.CambiarPortada (libroEN);

        /*PROTECTED REGION END*/
}
}
}
