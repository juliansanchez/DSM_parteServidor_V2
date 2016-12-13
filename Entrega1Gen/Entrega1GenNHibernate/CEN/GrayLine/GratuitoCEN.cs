

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

public int New_ (string p_titulo, string p_portada, string p_descripcion, Nullable<DateTime> p_fecha, bool p_publicado, System.Collections.Generic.IList<string> p_usuario, System.Collections.Generic.IList<int> p_categoria, bool p_baneado, int p_num_denuncias)
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


        gratuitoEN.Usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        Entrega1GenNHibernate.EN.GrayLine.UsuarioEN en = new Entrega1GenNHibernate.EN.GrayLine.UsuarioEN ();
                        en.Email = item;
                        gratuitoEN.Usuario.Add (en);
                }
        }

        else{
                gratuitoEN.Usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
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
