

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;

using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


namespace Entrega1GenNHibernate.CEN.GrayLine
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string Registrarse (string p_nombre, String p_contrasenya, string p_email, int p_edad, Nullable<DateTime> p_fecha_alta, string p_foto, string p_bibliografia, bool p_baneado, int p_numDenunciasUser, bool p_enRevisionU, string p_alias, string p_rol)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.Email = p_email;

        usuarioEN.Edad = p_edad;

        usuarioEN.Fecha_alta = p_fecha_alta;

        usuarioEN.Foto = p_foto;

        usuarioEN.Bibliografia = p_bibliografia;

        usuarioEN.Baneado = p_baneado;

        usuarioEN.NumDenunciasUser = p_numDenunciasUser;

        usuarioEN.EnRevisionU = p_enRevisionU;

        usuarioEN.Alias = p_alias;


        if (p_rol != null) {
                // El argumento p_rol -> Property rol es oid = false
                // Lista de oids alias
                usuarioEN.Rol = new Entrega1GenNHibernate.EN.GrayLine.RolEN ();
                usuarioEN.Rol.TipoRoll = p_rol;
        }

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registrarse (usuarioEN);
        return oid;
}

public void EliminarCuenta (string alias
                            )
{
        _IUsuarioCAD.EliminarCuenta (alias);
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.UsuarioEN> BuscarUsuario (string mote)
{
        return _IUsuarioCAD.BuscarUsuario (mote);
}
public UsuarioEN VerUsuario (string alias
                             )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.VerUsuario (alias);
        return usuarioEN;
}
}
}
