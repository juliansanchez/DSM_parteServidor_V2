
using System;
// Definición clase ComentarioEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo texto_comentario
 */
private string texto_comentario;



/**
 *	Atributo libro
 */
private Entrega1GenNHibernate.EN.GrayLine.LibroEN libro;



/**
 *	Atributo baneado
 */
private bool baneado;



/**
 *	Atributo numdenunciasComentario
 */
private int numdenunciasComentario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuario
 */
private Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto_comentario {
        get { return texto_comentario; } set { texto_comentario = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.LibroEN Libro {
        get { return libro; } set { libro = value;  }
}



public virtual bool Baneado {
        get { return baneado; } set { baneado = value;  }
}



public virtual int NumdenunciasComentario {
        get { return numdenunciasComentario; } set { numdenunciasComentario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, string texto_comentario, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, bool baneado, int numdenunciasComentario, Nullable<DateTime> fecha, Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario
                    )
{
        this.init (Id, texto_comentario, libro, baneado, numdenunciasComentario, fecha, usuario);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Texto_comentario, comentario.Libro, comentario.Baneado, comentario.NumdenunciasComentario, comentario.Fecha, comentario.Usuario);
}

private void init (int id
                   , string texto_comentario, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, bool baneado, int numdenunciasComentario, Nullable<DateTime> fecha, Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario)
{
        this.Id = id;


        this.Texto_comentario = texto_comentario;

        this.Libro = libro;

        this.Baneado = baneado;

        this.NumdenunciasComentario = numdenunciasComentario;

        this.Fecha = fecha;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
