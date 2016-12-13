
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email
                                );

void ModifyDefault (AdministradorEN administrador);



string New_ (AdministradorEN administrador);

void Destroy (string email
              );


void EliminarComentario (AdministradorEN administrador);


void EliminarLibro (AdministradorEN administrador);


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
