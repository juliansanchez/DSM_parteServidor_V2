
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
public void Pagar (int p_Pago_OID, bool p_pagado)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CP.GrayLine_Pago_pagar) ENABLED START*/

        IPagoCAD pagoCAD = null;
        PagoCEN pagoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                pagoCAD = new PagoCAD (session);
                pagoCEN = new  PagoCEN (pagoCAD);






                //Call to PagoCAD

                pagoCAD.Pagar (p_Pago_OID, p_pagado);



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
