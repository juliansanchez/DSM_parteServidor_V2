
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





public ComentarioEN()
{
}



public ComentarioEN(int id, string texto_comentario, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, bool baneado
                    )
{
        this.init (Id, texto_comentario, libro, baneado);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Texto_comentario, comentario.Libro, comentario.Baneado);
}

private void init (int id
                   , string texto_comentario, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, bool baneado)
{
        this.Id = id;


        this.Texto_comentario = texto_comentario;

        this.Libro = libro;

        this.Baneado = baneado;
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
