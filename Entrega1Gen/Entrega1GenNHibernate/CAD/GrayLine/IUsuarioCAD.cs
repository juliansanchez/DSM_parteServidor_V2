
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);



string Registrarse (UsuarioEN usuario);

void EliminarCuenta (string email
                     );


void CambiarNombre (UsuarioEN usuario);


void CambiarContrasenya (UsuarioEN usuario);


void CambiarFoto (UsuarioEN usuario);


void CambiarBibliografia (UsuarioEN usuario);




System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> BuscarUsuario (string arg0);



UsuarioEN VerUsuario (string email
                      );
}
}
