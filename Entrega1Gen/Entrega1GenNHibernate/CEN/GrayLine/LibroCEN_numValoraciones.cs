
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Libro_numValoraciones) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class LibroCEN
{
public void NumValoraciones (int p_Libro_OID, float p_contValoraciones)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Libro_numValoraciones_customized) START*/

        LibroEN libroEN = null;

        //Initialized LibroEN
        libroEN = new LibroEN ();
        libroEN.Id_libro = p_Libro_OID;
        libroEN.ContValoraciones = p_contValoraciones;
        //Call to LibroCAD

        _ILibroCAD.NumValoraciones (libroEN);

        /*PROTECTED REGION END*/
}
}
}
