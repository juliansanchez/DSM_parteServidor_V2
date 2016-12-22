
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Capitulo_redactarColaborativo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class CapituloCEN
{
public void RedactarColaborativo (int p_oid)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Capitulo_redactarColaborativo) ENABLED START*/

        // Write here your custom code...

        CapituloEN capituloEN = null;

        capituloEN = _ICapituloCAD.ReadOIDDefault (p_oid);

        if (capituloEN.Editando == false) {
                capituloEN.Editando = true;
                _ICapituloCAD.ModifyDefault (capituloEN);
                System.Console.WriteLine ("Me he metido a editar el contenido");
        }
        else{
                System.Console.WriteLine ("Ya hay alguien editando el contenido");
        }





        /*PROTECTED REGION END*/
}
}
}
