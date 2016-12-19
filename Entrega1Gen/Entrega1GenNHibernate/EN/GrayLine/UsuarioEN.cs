
using System;
// Definición clase UsuarioEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class UsuarioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo edad
 */
private int edad;



/**
 *	Atributo fecha_alta
 */
private Nullable<DateTime> fecha_alta;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo bibliografia
 */
private string bibliografia;



/**
 *	Atributo libro
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro;



/**
 *	Atributo capitulo
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo;



/**
 *	Atributo baneado
 */
private bool baneado;



/**
 *	Atributo numDenunciasUser
 */
private int numDenunciasUser;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual int Edad {
        get { return edad; } set { edad = value;  }
}



public virtual Nullable<DateTime> Fecha_alta {
        get { return fecha_alta; } set { fecha_alta = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual string Bibliografia {
        get { return bibliografia; } set { bibliografia = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> Libro {
        get { return libro; } set { libro = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> Capitulo {
        get { return capitulo; } set { capitulo = value;  }
}



public virtual bool Baneado {
        get { return baneado; } set { baneado = value;  }
}



public virtual int NumDenunciasUser {
        get { return numDenunciasUser; } set { numDenunciasUser = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}





public UsuarioEN()
{
        libro = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
        capitulo = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CapituloEN>();
        comentario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN>();
        valoracion = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN>();
}



public UsuarioEN(string email, string nombre, String contrasenya, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado, int numDenunciasUser, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion
                 )
{
        this.init (Email, nombre, contrasenya, edad, fecha_alta, foto, bibliografia, libro, capitulo, baneado, numDenunciasUser, comentario, valoracion);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Nombre, usuario.Contrasenya, usuario.Edad, usuario.Fecha_alta, usuario.Foto, usuario.Bibliografia, usuario.Libro, usuario.Capitulo, usuario.Baneado, usuario.NumDenunciasUser, usuario.Comentario, usuario.Valoracion);
}

private void init (string email
                   , string nombre, String contrasenya, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado, int numDenunciasUser, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Edad = edad;

        this.Fecha_alta = fecha_alta;

        this.Foto = foto;

        this.Bibliografia = bibliografia;

        this.Libro = libro;

        this.Capitulo = capitulo;

        this.Baneado = baneado;

        this.NumDenunciasUser = numDenunciasUser;

        this.Comentario = comentario;

        this.Valoracion = valoracion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
