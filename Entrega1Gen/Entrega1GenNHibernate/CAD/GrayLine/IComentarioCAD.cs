
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);



int New_ (ComentarioEN comentario);

void EditarComentario (ComentarioEN comentario);


void Destroy (int id
              );


System.Collections.Generic.IList<ComentarioEN> VerComentarios (int first, int size);



System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> ComentariosLibro (int ? milibro);
}
}
