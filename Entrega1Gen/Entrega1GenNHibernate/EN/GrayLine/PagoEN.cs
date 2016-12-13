
using System;
// Definición clase PagoEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class PagoEN                                                                 : Entrega1GenNHibernate.EN.GrayLine.LibroEN


{
/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo pagado
 */
private bool pagado;






public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual bool Pagado {
        get { return pagado; } set { pagado = value;  }
}





public PagoEN() : base ()
{
}



public PagoEN(int id_libro, float precio, bool pagado
              , string titulo, string portada, string descripcion, Nullable<DateTime> fecha, bool publicado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> categoria, bool baneado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, int num_denuncias
              )
{
        this.init (Id_libro, precio, pagado, titulo, portada, descripcion, fecha, publicado, capitulo, usuario, categoria, baneado, comentario, valoracion, num_denuncias);
}


public PagoEN(PagoEN pago)
{
        this.init (Id_libro, pago.Precio, pago.Pagado, pago.Titulo, pago.Portada, pago.Descripcion, pago.Fecha, pago.Publicado, pago.Capitulo, pago.Usuario, pago.Categoria, pago.Baneado, pago.Comentario, pago.Valoracion, pago.Num_denuncias);
}

private void init (int id_libro
                   , float precio, bool pagado, string titulo, string portada, string descripcion, Nullable<DateTime> fecha, bool publicado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> categoria, bool baneado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, int num_denuncias)
{
        this.Id_libro = id_libro;


        this.Precio = precio;

        this.Pagado = pagado;

        this.Titulo = titulo;

        this.Portada = portada;

        this.Descripcion = descripcion;

        this.Fecha = fecha;

        this.Publicado = publicado;

        this.Capitulo = capitulo;

        this.Usuario = usuario;

        this.Categoria = categoria;

        this.Baneado = baneado;

        this.Comentario = comentario;

        this.Valoracion = valoracion;

        this.Num_denuncias = num_denuncias;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PagoEN t = obj as PagoEN;
        if (t == null)
                return false;
        if (Id_libro.Equals (t.Id_libro))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id_libro.GetHashCode ();
        return hash;
}
}
}
