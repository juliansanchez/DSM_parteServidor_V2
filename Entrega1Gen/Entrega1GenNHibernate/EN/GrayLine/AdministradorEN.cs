
using System;
// Definición clase AdministradorEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class AdministradorEN                                                                        : Entrega1GenNHibernate.EN.GrayLine.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(string email,
                       string nombre, String contrasenya, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado
                       )
{
        this.init (Email, nombre, contrasenya, edad, fecha_alta, foto, bibliografia, libro, capitulo, baneado);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.Nombre, administrador.Contrasenya, administrador.Edad, administrador.Fecha_alta, administrador.Foto, administrador.Bibliografia, administrador.Libro, administrador.Capitulo, administrador.Baneado);
}

private void init (string email
                   , string nombre, String contrasenya, int edad, Nullable<DateTime> fecha_alta, string foto, string bibliografia, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> libro, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> capitulo, bool baneado)
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
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
