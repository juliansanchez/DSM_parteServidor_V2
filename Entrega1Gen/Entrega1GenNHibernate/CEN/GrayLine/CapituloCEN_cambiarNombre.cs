
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Capitulo_cambiarNombre) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class CapituloCEN
{
public void CambiarNombre (string p_nombre)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Capitulo_cambiarNombre_customized) START*/

        CapituloEN capituloEN = null;

        //Initialized CapituloEN
        capituloEN = new CapituloEN ();
        capituloEN.Nombre = p_nombre;
        //Call to CapituloCAD

        _ICapituloCAD.CambiarNombre (capituloEN);

        /*PROTECTED REGION END*/
}
}
}
