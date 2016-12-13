
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface ICategoriaCAD
{
CategoriaEN ReadOIDDefault (int id_categoria
                            );

void ModifyDefault (CategoriaEN categoria);



int New_ (CategoriaEN categoria);

void Cambiar_categoria (CategoriaEN categoria);


void Destroy (int id_categoria
              );


System.Collections.Generic.IList<CategoriaEN> VerCategorias (int first, int size);
}
}
