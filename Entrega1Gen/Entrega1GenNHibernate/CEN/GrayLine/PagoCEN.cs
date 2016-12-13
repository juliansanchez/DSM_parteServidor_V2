

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
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoCAD _IPagoCAD;

public PagoCEN()
{
        this._IPagoCAD = new PagoCAD ();
}

public PagoCEN(IPagoCAD _IPagoCAD)
{
        this._IPagoCAD = _IPagoCAD;
}

public IPagoCAD get_IPagoCAD ()
{
        return this._IPagoCAD;
}

public int New_ (string p_titulo, string p_portada, string p_descripcion, Nullable<DateTime> p_fecha, bool p_publicado, System.Collections.Generic.IList<string> p_usuario, System.Collections.Generic.IList<int> p_categoria, bool p_baneado, int p_num_denuncias, float p_precio, bool p_pagado)
{
        PagoEN pagoEN = null;
        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Titulo = p_titulo;

        pagoEN.Portada = p_portada;

        pagoEN.Descripcion = p_descripcion;

        pagoEN.Fecha = p_fecha;

        pagoEN.Publicado = p_publicado;


        pagoEN.Usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        Entrega1GenNHibernate.EN.GrayLine.UsuarioEN en = new Entrega1GenNHibernate.EN.GrayLine.UsuarioEN ();
                        en.Email = item;
                        pagoEN.Usuario.Add (en);
                }
        }

        else{
                pagoEN.Usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
        }


        pagoEN.Categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        if (p_categoria != null) {
                foreach (int item in p_categoria) {
                        Entrega1GenNHibernate.EN.GrayLine.CategoriaEN en = new Entrega1GenNHibernate.EN.GrayLine.CategoriaEN ();
                        en.Id_categoria = item;
                        pagoEN.Categoria.Add (en);
                }
        }

        else{
                pagoEN.Categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        }

        pagoEN.Baneado = p_baneado;

        pagoEN.Num_denuncias = p_num_denuncias;

        pagoEN.Precio = p_precio;

        pagoEN.Pagado = p_pagado;

        //Call to PagoCAD

        oid = _IPagoCAD.New_ (pagoEN);
        return oid;
}

public System.Collections.Generic.IList<PagoEN> VerLibrosPago (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> list = null;

        list = _IPagoCAD.VerLibrosPago (first, size);
        return list;
}
}
}
