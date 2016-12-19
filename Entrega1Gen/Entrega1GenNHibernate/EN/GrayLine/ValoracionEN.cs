
using System;
// Definición clase ValoracionEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class ValoracionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo libro
 */
private Entrega1GenNHibernate.EN.GrayLine.LibroEN libro;



/**
 *	Atributo usuario
 */
private Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.LibroEN Libro {
        get { return libro; } set { libro = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, int puntuacion, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario
                    )
{
        this.init (Id, puntuacion, libro, usuario);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Puntuacion, valoracion.Libro, valoracion.Usuario);
}

private void init (int id
                   , int puntuacion, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Libro = libro;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
