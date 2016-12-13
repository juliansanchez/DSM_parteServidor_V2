
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Pago_pagar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class PagoCEN
{
public void Pagar (bool p_pagado)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Pago_pagar_customized) START*/

        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Pagado = p_pagado;
        //Call to PagoCAD

        _IPagoCAD.Pagar (pagoEN);

        /*PROTECTED REGION END*/
}
}
}
