
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;



/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CP.GrayLine_Pago_pagar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class PagoCP : BasicCP
{
public void Pagar (int p_oid, string usuario_oid)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CP.GrayLine_Pago_pagar) ENABLED START*/

        IPagoCAD pagoCAD = null;
        PagoCEN pagoCEN = null;

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;



        try
        {
                SessionInitializeTransaction ();
                pagoCAD = new PagoCAD (session);
                pagoCEN = new  PagoCEN (pagoCAD);

                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);


                UsuarioEN usu1 = usuarioCAD.ReadOIDDefault (usuario_oid);
                PagoEN pag1 = pagoCAD.ReadOIDDefault (p_oid);

                usu1.Pago.Add (pag1);
                pag1.Usuario_0.Add (usu1);


                usuarioCAD.ModifyDefault (usu1);
                pagoCAD.ModifyDefault (pag1);






                //Call to PagoCAD

                // pagoCAD.Pagar (p_Pago_OID, p_pagado);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
