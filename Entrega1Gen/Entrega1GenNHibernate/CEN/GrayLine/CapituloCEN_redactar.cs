
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Capitulo_redactar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class CapituloCEN
{
public void Redactar (string p_contenido)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Capitulo_redactar_customized) START*/

        CapituloEN capituloEN = null;

        //Initialized CapituloEN
        capituloEN = new CapituloEN ();
        capituloEN.Contenido = p_contenido;
        //Call to CapituloCAD

        _ICapituloCAD.Redactar (capituloEN);

        /*PROTECTED REGION END*/
}
}
}
