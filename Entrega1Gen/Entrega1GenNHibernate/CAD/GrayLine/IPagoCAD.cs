
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IPagoCAD
{
PagoEN ReadOIDDefault (int id_libro
                       );

void ModifyDefault (PagoEN pago);



void Pagar (PagoEN pago);



int New_ (PagoEN pago);

System.Collections.Generic.IList<PagoEN> VerLibrosPago (int first, int size);
}
}
