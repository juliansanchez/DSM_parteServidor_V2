
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
private Entrega1GenNHibernate.Enumerated.GrayLine.Puntuacion1Enum puntuacion;



/**
 *	Atributo libro
 */
private Entrega1GenNHibernate.EN.GrayLine.LibroEN libro;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Entrega1GenNHibernate.Enumerated.GrayLine.Puntuacion1Enum Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.LibroEN Libro {
        get { return libro; } set { libro = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, Entrega1GenNHibernate.Enumerated.GrayLine.Puntuacion1Enum puntuacion, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro
                    )
{
        this.init (Id, puntuacion, libro);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Puntuacion, valoracion.Libro);
}

private void init (int id
                   , Entrega1GenNHibernate.Enumerated.GrayLine.Puntuacion1Enum puntuacion, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro)
{
        this.Id = id;


        this.Puntuacion = puntuacion;

        this.Libro = libro;
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
