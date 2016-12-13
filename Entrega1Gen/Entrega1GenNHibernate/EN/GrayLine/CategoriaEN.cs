
using System;
// Definición clase CategoriaEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class CategoriaEN
{
/**
 *	Atributo nombre_categoria
 */
private Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum nombre_categoria;



/**
 *	Atributo id_categoria
 */
private int id_categoria;



/**
 *	Atributo libro
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro;






public virtual Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum Nombre_categoria {
        get { return nombre_categoria; } set { nombre_categoria = value;  }
}



public virtual int Id_categoria {
        get { return id_categoria; } set { id_categoria = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> Libro {
        get { return libro; } set { libro = value;  }
}





public CategoriaEN()
{
        libro = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
}



public CategoriaEN(int id_categoria, Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum nombre_categoria, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro
                   )
{
        this.init (Id_categoria, nombre_categoria, libro);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (Id_categoria, categoria.Nombre_categoria, categoria.Libro);
}

private void init (int id_categoria
                   , Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum nombre_categoria, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro)
{
        this.Id_categoria = id_categoria;


        this.Nombre_categoria = nombre_categoria;

        this.Libro = libro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
        if (t == null)
                return false;
        if (Id_categoria.Equals (t.Id_categoria))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id_categoria.GetHashCode ();
        return hash;
}
}
}
