
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Usuario_banearUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class UsuarioCEN
{
public void BanearUsuario (string p_oid)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Usuario_banearUsuario) ENABLED START*/

        // Write here your custom code...
        try
        {
                // capturamos el usuario baneado
                UsuarioEN usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_oid);

                /* Como comprobamos que el que realiza la accion es el administrador??*/
                if (p_oid != null && usuarioEN.Baneado == false) {
                        usuarioEN.Baneado = true;
                        _IUsuarioCAD.ModifyDefault (usuarioEN);
                }
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }


        // throw new NotImplementedException ("Method BanearUsuario() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
