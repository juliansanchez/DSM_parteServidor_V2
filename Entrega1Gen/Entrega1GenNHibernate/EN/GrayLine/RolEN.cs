
using System;
// Definición clase RolEN
namespace Entrega1GenNHibernate.EN.GrayLine
{
public partial class RolEN
{
/**
 *	Atributo tipoRoll
 */
private string tipoRoll;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario;






public virtual string TipoRoll {
        get { return tipoRoll; } set { tipoRoll = value;  }
}



public virtual System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public RolEN()
{
        usuario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN>();
}



public RolEN(string tipoRoll, System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario
             )
{
        this.init (TipoRoll, usuario);
}


public RolEN(RolEN rol)
{
        this.init (TipoRoll, rol.Usuario);
}

private void init (string tipoRoll
                   , System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> usuario)
{
        this.TipoRoll = tipoRoll;


        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RolEN t = obj as RolEN;
        if (t == null)
                return false;
        if (TipoRoll.Equals (t.TipoRoll))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.TipoRoll.GetHashCode ();
        return hash;
}
}
}
