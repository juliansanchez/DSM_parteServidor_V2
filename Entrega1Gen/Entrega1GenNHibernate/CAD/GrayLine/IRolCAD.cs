
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IRolCAD
{
RolEN ReadOIDDefault (string tipoRoll
                      );

void ModifyDefault (RolEN rol);



string New_ (RolEN rol);

void Modify (RolEN rol);


void Destroy (string tipoRoll
              );
}
}
