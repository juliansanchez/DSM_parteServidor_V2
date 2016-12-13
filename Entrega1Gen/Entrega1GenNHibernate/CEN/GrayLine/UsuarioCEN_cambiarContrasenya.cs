
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Usuario_cambiarContrasenya) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class UsuarioCEN
{
public void CambiarContrasenya (string p_Usuario_OID, String p_contrasenya)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Usuario_cambiarContrasenya_customized) START*/

        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        //Call to UsuarioCAD

        _IUsuarioCAD.CambiarContrasenya (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
