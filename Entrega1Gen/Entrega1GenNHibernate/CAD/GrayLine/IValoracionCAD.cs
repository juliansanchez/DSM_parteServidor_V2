
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IValoracionCAD
{
ValoracionEN ReadOIDDefault (int id
                             );

void ModifyDefault (ValoracionEN valoracion);



int New_ (ValoracionEN valoracion);

void Modify (ValoracionEN valoracion);


void Destroy (int id
              );
}
}
