
using System;
using Entrega1GenNHibernate.EN.GrayLine;

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial interface ILibroCAD
{
LibroEN ReadOIDDefault (int id_libro
                        );

void ModifyDefault (LibroEN libro);



int CrearLibro (LibroEN libro);

void EliminarLibro (int id_libro
                    );


void CambiarTitulo (LibroEN libro);


void CambiarPortada (LibroEN libro);


void CambiarDescripcion (LibroEN libro);


System.Collections.Generic.IList<LibroEN> VerLibreria (int first, int size);


LibroEN VerLibro (int id_libro
                  );


void Publicar (LibroEN libro);



System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size);



void Valorar (int p_Libro_OID, System.Collections.Generic.IList<int> p_valoracion_OIDs);

void Comentar (int p_Libro_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);

System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibro (string nombre);


System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibroPorCategoria (int ? id_categoria);
}
}
