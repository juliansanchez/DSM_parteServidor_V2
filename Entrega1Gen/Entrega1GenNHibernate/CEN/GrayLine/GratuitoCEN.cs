

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
 *      Definition of the class GratuitoCEN
 *
 */
public partial class GratuitoCEN
{
private IGratuitoCAD _IGratuitoCAD;

public GratuitoCEN()
{
        this._IGratuitoCAD = new GratuitoCAD ();
}

public GratuitoCEN(IGratuitoCAD _IGratuitoCAD)
{
        this._IGratuitoCAD = _IGratuitoCAD;
}

public IGratuitoCAD get_IGratuitoCAD ()
{
        return this._IGratuitoCAD;
}

public int New_ (string p_titulo, string p_portada, string p_descripcion, Nullable<DateTime> p_fecha, bool p_publicado, string p_usuario, System.Collections.Generic.IList<int> p_categoria, bool p_baneado, int p_num_denuncias, float p_notaMediaValoracion, float p_contValoraciones, bool p_enRevision)
{
        GratuitoEN gratuitoEN = null;
        int oid;

        //Initialized GratuitoEN
        gratuitoEN = new GratuitoEN ();
        gratuitoEN.Titulo = p_titulo;

        gratuitoEN.Portada = p_portada;

        gratuitoEN.Descripcion = p_descripcion;

        gratuitoEN.Fecha = p_fecha;

        gratuitoEN.Publicado = p_publicado;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id_libro
                gratuitoEN.Usuario = new Entrega1GenNHibernate.EN.GrayLine.UsuarioEN ();
                gratuitoEN.Usuario.Alias = p_usuario;
        }


        gratuitoEN.Categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        if (p_categoria != null) {
                foreach (int item in p_categoria) {
                        Entrega1GenNHibernate.EN.GrayLine.CategoriaEN en = new Entrega1GenNHibernate.EN.GrayLine.CategoriaEN ();
                        en.Id_categoria = item;
                        gratuitoEN.Categoria.Add (en);
                }
        }

        else{
                gratuitoEN.Categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        }

        gratuitoEN.Baneado = p_baneado;

        gratuitoEN.Num_denuncias = p_num_denuncias;

        gratuitoEN.NotaMediaValoracion = p_notaMediaValoracion;

        gratuitoEN.ContValoraciones = p_contValoraciones;

        gratuitoEN.EnRevision = p_enRevision;

        //Call to GratuitoCAD

        oid = _IGratuitoCAD.New_ (gratuitoEN);
        return oid;
}

public System.Collections.Generic.IList<GratuitoEN> VerLibrosGratuitos (int first, int size)
{
        System.Collections.Generic.IList<GratuitoEN> list = null;

        list = _IGratuitoCAD.VerLibrosGratuitos (first, size);
        return list;
}
}
}
