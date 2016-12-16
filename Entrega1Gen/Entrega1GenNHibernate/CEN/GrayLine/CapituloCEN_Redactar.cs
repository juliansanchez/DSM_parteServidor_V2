
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
public void Redactar (string p_contenido, int id_capitulo)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Capitulo_redactar) ENABLED START*/

        // Write here your custom code...
        CapituloEN capituloEN = null;

        //Initialized LibroEN

        capituloEN = _ICapituloCAD.ReadOIDDefault (id_capitulo);

        capituloEN.Contenido = capituloEN.Contenido + " * " + p_contenido;

        _ICapituloCAD.ModifyDefault (capituloEN);

        // throw new NotImplementedException ("Method Redactar() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
