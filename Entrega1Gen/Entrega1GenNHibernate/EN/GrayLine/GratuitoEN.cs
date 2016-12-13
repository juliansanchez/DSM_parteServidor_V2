
using System;
// Definición clase GratuitoEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class GratuitoEN                                                                     : Entrega1GenNHibernate.EN.GrayLine.LibroEN


{
public GratuitoEN() : base ()
{
}



public GratuitoEN(int id_libro,
                  string titulo, string portada, string descripcion, Nullable<DateTime> fecha, bool publicado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> categoria, bool baneado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, int num_denuncias
                  )
{
        this.init (Id_libro, titulo, portada, descripcion, fecha, publicado, capitulo, usuario, categoria, baneado, comentario, valoracion, num_denuncias);
}


public GratuitoEN(GratuitoEN gratuito)
{
        this.init (Id_libro, gratuito.Titulo, gratuito.Portada, gratuito.Descripcion, gratuito.Fecha, gratuito.Publicado, gratuito.Capitulo, gratuito.Usuario, gratuito.Categoria, gratuito.Baneado, gratuito.Comentario, gratuito.Valoracion, gratuito.Num_denuncias);
}

private void init (int id_libro
                   , string titulo, string portada, string descripcion, Nullable<DateTime> fecha, bool publicado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> categoria, bool baneado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, int num_denuncias)
{
        this.Id_libro = id_libro;


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
        GratuitoEN t = obj as GratuitoEN;
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
