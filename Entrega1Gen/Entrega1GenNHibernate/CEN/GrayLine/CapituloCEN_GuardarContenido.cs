
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Capitulo_guardarContenido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class CapituloCEN
{
public void GuardarContenido (int p_Capitulo_OID, string p_contenido)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Capitulo_guardarContenido) ENABLED START*/

        // Write here your custom code...
        CapituloEN capituloEN = null;

        capituloEN = _ICapituloCAD.ReadOIDDefault (p_Capitulo_OID);

        //Initialized CapituloEN

        capituloEN.Id_capitulo = p_Capitulo_OID;
        capituloEN.Contenido = p_contenido;
        capituloEN.Editando = false;



        //Call to CapituloCAD
        _ICapituloCAD.ModifyDefault (capituloEN);

        System.Console.WriteLine ("Guardo y salgo para que otro usuario pueda redactar");


        /*PROTECTED REGION END*/
}
}
}
