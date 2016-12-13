
using System;
// Definición clase CapituloEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class CapituloEN
{
/**
 *	Atributo id_capitulo
 */
private int id_capitulo;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo numero
 */
private int numero;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo libro
 */
private Entrega1GenNHibernate.EN.GrayLine.LibroEN libro;



/**
 *	Atributo usuario
 */
private Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario;



/**
 *	Atributo editando
 */
private bool editando;






public virtual int Id_capitulo {
        get { return id_capitulo; } set { id_capitulo = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.LibroEN Libro {
        get { return libro; } set { libro = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual bool Editando {
        get { return editando; } set { editando = value;  }
}





public CapituloEN()
{
}



public CapituloEN(int id_capitulo, string nombre, int numero, string contenido, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario, bool editando
                  )
{
        this.init (Id_capitulo, nombre, numero, contenido, libro, usuario, editando);
}


public CapituloEN(CapituloEN capitulo)
{
        this.init (Id_capitulo, capitulo.Nombre, capitulo.Numero, capitulo.Contenido, capitulo.Libro, capitulo.Usuario, capitulo.Editando);
}

private void init (int id_capitulo
                   , string nombre, int numero, string contenido, Entrega1GenNHibernate.EN.GrayLine.LibroEN libro, Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario, bool editando)
{
        this.Id_capitulo = id_capitulo;


        this.Nombre = nombre;

        this.Numero = numero;

        this.Contenido = contenido;

        this.Libro = libro;

        this.Usuario = usuario;

        this.Editando = editando;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CapituloEN t = obj as CapituloEN;
        if (t == null)
                return false;
        if (Id_capitulo.Equals (t.Id_capitulo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id_capitulo.GetHashCode ();
        return hash;
}
}
}
