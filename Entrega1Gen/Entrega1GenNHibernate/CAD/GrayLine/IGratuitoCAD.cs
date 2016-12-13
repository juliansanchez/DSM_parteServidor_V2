
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IGratuitoCAD
{
GratuitoEN ReadOIDDefault (int id_libro
                           );

void ModifyDefault (GratuitoEN gratuito);




int New_ (GratuitoEN gratuito);

System.Collections.Generic.IList<GratuitoEN> VerLibrosGratuitos (int first, int size);
}
}
