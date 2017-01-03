
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



/**
 *	Atributo enRevisionU
 */
private bool enRevisionU;



/**
 *	Atributo alias
 */
private string alias;



/**
 *	Atributo rol
 */
private Entrega1GenNHibernate.EN.GrayLine.RolEN rol;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.PagoEN> pago;






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



public virtual bool EnRevisionU {
        get { return enRevisionU; } set { enRevisionU = value;  }
}



public virtual string Alias {
        get { return alias; } set { alias = value;  }
}



public virtual Entrega1GenNHibernate.EN.GrayLine.RolEN Rol {
        get { return rol; } set { rol = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}





public UsuarioEN()
{
        libro = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
        capitulo = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.CapituloEN>();
        comentario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN>();
        valoracion = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN>();
        pago = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.PagoEN>();
}



public UsuarioEN(string alias, string nombre, String contrasenya, string email, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado, int numDenunciasUser, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, bool enRevisionU, Entrega1GenNHibernate.EN.GrayLine.RolEN rol, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.PagoEN> pago
                 )
{
        this.init (Alias, nombre, contrasenya, email, edad, fecha_alta, foto, bibliografia, libro, capitulo, baneado, numDenunciasUser, comentario, valoracion, enRevisionU, rol, pago);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Alias, usuario.Nombre, usuario.Contrasenya, usuario.Email, usuario.Edad, usuario.Fecha_alta, usuario.Foto, usuario.Bibliografia, usuario.Libro, usuario.Capitulo, usuario.Baneado, usuario.NumDenunciasUser, usuario.Comentario, usuario.Valoracion, usuario.EnRevisionU, usuario.Rol, usuario.Pago);
}

private void init (string alias
                   , string nombre, String contrasenya, string email, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado, int numDenunciasUser, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, bool enRevisionU, Entrega1GenNHibernate.EN.GrayLine.RolEN rol, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.PagoEN> pago)
{
        this.Alias = alias;


        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Email = email;

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

        this.EnRevisionU = enRevisionU;

        this.Rol = rol;

        this.Pago = pago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Alias.Equals (t.Alias))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Alias.GetHashCode ();
        return hash;
}
}
}
