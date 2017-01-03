
using System;
// Definición clase AdministradorEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class AdministradorEN                                                                        : Entrega1GenNHibernate.EN.GrayLine.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(string alias,
                       string nombre, String contrasenya, string email, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado, int numDenunciasUser, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, bool enRevisionU
                       )
{
        this.init (Alias, nombre, contrasenya, email, edad, fecha_alta, foto, bibliografia, libro, capitulo, baneado, numDenunciasUser, comentario, valoracion, enRevisionU);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Alias, administrador.Nombre, administrador.Contrasenya, administrador.Email, administrador.Edad, administrador.Fecha_alta, administrador.Foto, administrador.Bibliografia, administrador.Libro, administrador.Capitulo, administrador.Baneado, administrador.NumDenunciasUser, administrador.Comentario, administrador.Valoracion, administrador.EnRevisionU);
}

private void init (string alias
                   , string nombre, String contrasenya, string email, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado, int numDenunciasUser, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> comentario, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> valoracion, bool enRevisionU)
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
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
