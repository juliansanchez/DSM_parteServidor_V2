
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Usuario_iniciarSesion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class UsuarioCEN
{
public bool IniciarSesion (string p_oid, string pass)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Usuario_iniciarSesion) ENABLED START*/

        // ciframos la cadena que nos pasan como password y comprobamos que es la misma que la del usuario
        var passCifrado = Utils.Util.GetEncondeMD5 (pass);

        UsuarioEN usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_oid);
        bool login = false;

        if (pass != null && passCifrado.Equals (usuarioEN.Contrasenya)) {
                login = true;
        }

        return login;
        /*PROTECTED REGION END*/
}
}
}
