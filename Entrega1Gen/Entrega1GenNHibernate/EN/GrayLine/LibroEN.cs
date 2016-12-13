
using System;
// Definición clase LibroEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class LibroEN
{
/**
 *	Atributo id_libro
 */
private int id_libro;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo portada
 */
private string portada;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo publicado
 */
private bool publicado;



/**
 *	Atributo capitulo
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario;



/**
 *	Atributo categoria
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> categoria;



/**
 *	Atributo baneado
 */
private bool baneado;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion;



/**
 *	Atributo num_denuncias
 */
private int num_denuncias;






public virtual int Id_libro {
        get { return id_libro; } set { id_libro = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Portada {
        get { return portada; } set { portada = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool Publicado {
        get { return publicado; } set { publicado = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> Capitulo {
        get { return capitulo; } set { capitulo = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual bool Baneado {
        get { return baneado; } set { baneado = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual int Num_denuncias {
        get { return num_denuncias; } set { num_denuncias = value;  }
}





public LibroEN()
{
        capitulo = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CapituloEN>();
        usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
        categoria = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN>();
        comentario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN>();
        valoracion = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN>();
}



public LibroEN(int id_libro, string titulo, string portada, string descripcion, Nullable<DateTime> fecha, bool publicado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CategoriaEN> categoria, bool baneado, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, int num_denuncias
               )
{
        this.init (Id_libro, titulo, portada, descripcion, fecha, publicado, capitulo, usuario, categoria, baneado, comentario, valoracion, num_denuncias);
}


public LibroEN(LibroEN libro)
{
        this.init (Id_libro, libro.Titulo, libro.Portada, libro.Descripcion, libro.Fecha, libro.Publicado, libro.Capitulo, libro.Usuario, libro.Categoria, libro.Baneado, libro.Comentario, libro.Valoracion, libro.Num_denuncias);
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
        LibroEN t = obj as LibroEN;
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
