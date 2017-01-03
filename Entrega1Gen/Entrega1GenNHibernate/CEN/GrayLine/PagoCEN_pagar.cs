
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
public void Pagar (int p_Pago_OID, bool p_pagado)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Pago_pagar_customized) START*/


        //Call to PagoCAD

        _IPagoCAD.Pagar (p_Pago_OID, p_pagado);

        /*PROTECTED REGION END*/
}
}
}
