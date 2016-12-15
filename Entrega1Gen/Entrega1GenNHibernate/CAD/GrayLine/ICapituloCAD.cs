
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface ICapituloCAD
{
CapituloEN ReadOIDDefault (int id_capitulo
                           );

void ModifyDefault (CapituloEN capitulo);



int New_ (CapituloEN capitulo);

void CambiarNombre (CapituloEN capitulo);


void EliminarCapitulo (int id_capitulo
                       );



void InvitarUsuario (int p_Capitulo_OID, string p_usuario_OID);

System.Collections.Generic.IList<CapituloEN> ReadAll (int first, int size);


System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> LeerCapitulo (int ? id_libro);


System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> BuscarCapitulo (int ? idlibro);


CapituloEN VerCapitulo (int id_capitulo
                        );
}
}
