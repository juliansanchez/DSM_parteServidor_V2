

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;

using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


namespace Entrega1GenNHibernate.CEN.GrayLine
{
/*
 *      Definition of the class LibroCEN
 *
 */
public partial class LibroCEN
{
private ILibroCAD _ILibroCAD;

public LibroCEN()
{
        this._ILibroCAD = new LibroCAD ();
}

public LibroCEN(ILibroCAD _ILibroCAD)
{
        this._ILibroCAD = _ILibroCAD;
}

public ILibroCAD get_ILibroCAD ()
{
        return this._ILibroCAD;
}

public int CrearLibro (string p_titulo, string p_portada, string p_descripcion, Nullable<DateTime> p_fecha, bool p_publicado, System.Collections.Generic.IList<string> p_usuario, System.Collections.Generic.IList<int> p_categoria, bool p_baneado, int p_num_denuncias)
{
        LibroEN libroEN = null;
        int oid;

        //Initialized LibroEN
        libroEN = new LibroEN ();
        libroEN.Titulo = p_titulo;

        libroEN.Portada = p_portada;

        libroEN.Descripcion = p_descripcion;

        libroEN.Fecha = p_fecha;

        libroEN.Publicado = p_publicado;


        libroEN.Usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        Entrega1GenNHibernate.EN.GrayLine.UsuarioEN en = new Entrega1GenNHibernate.EN.GrayLine.UsuarioEN ();
                        en.Email = item;
                        libroEN.Usuario.Add (en);
                }
        }

        else{
                libroEN.Usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
        }


        libroEN.Categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        if (p_categoria != null) {
                foreach (int item in p_categoria) {
                        Entrega1GenNHibernate.EN.GrayLine.CategoriaEN en = new Entrega1GenNHibernate.EN.GrayLine.CategoriaEN ();
                        en.Id_categoria = item;
                        libroEN.Categoria.Add (en);
                }
        }

        else{
                libroEN.Categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        }

        libroEN.Baneado = p_baneado;

        libroEN.Num_denuncias = p_num_denuncias;

        //Call to LibroCAD

        oid = _ILibroCAD.CrearLibro (libroEN);
        return oid;
}

public void EliminarLibro (int id_libro
                           )
{
        _ILibroCAD.EliminarLibro (id_libro);
}

public LibroEN VerLibro (int id_libro
                         )
{
        LibroEN libroEN = null;

        libroEN = _ILibroCAD.VerLibro (id_libro);
        return libroEN;
}

public System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> list = null;

        list = _ILibroCAD.ReadAll (first, size);
        return list;
}
public void Valorar (int p_Libro_OID, System.Collections.Generic.IList<int> p_valoracion_OIDs)
{
        //Call to LibroCAD

        _ILibroCAD.Valorar (p_Libro_OID, p_valoracion_OIDs);
}
public void Comentar (int p_Libro_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to LibroCAD

        _ILibroCAD.Comentar (p_Libro_OID, p_comentario_OIDs);
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibro (string nombre)
{
        return _ILibroCAD.BuscarLibro (nombre);
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibroPorCategoria (int ? id_categoria)
{
        return _ILibroCAD.BuscarLibroPorCategoria (id_categoria);
}
}
}
