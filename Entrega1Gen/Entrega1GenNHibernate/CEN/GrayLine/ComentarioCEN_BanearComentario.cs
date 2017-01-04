
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Comentario_banearComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class ComentarioCEN
{
public void BanearComentario (int p_Comentario_OID)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Comentario_banearComentario) ENABLED START*/

        // Write here your custom code...

        try
        {
                // capturamos el usuario baneado

                ComentarioEN comentarioEN = _IComentarioCAD.ReadOIDDefault (p_Comentario_OID);

                /* Como comprobamos que el que realiza la accion es el administrador??*/
                if (p_Comentario_OID != null && comentarioEN.Baneado == false) {
                        comentarioEN.Baneado = true;
                        _IComentarioCAD.ModifyDefault (comentarioEN);
                }
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }


        /*PROTECTED REGION END*/
}
}
}
