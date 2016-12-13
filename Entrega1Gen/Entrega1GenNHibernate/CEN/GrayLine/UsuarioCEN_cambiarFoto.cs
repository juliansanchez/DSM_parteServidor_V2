
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Usuario_cambiarFoto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class UsuarioCEN
{
public void CambiarFoto (string p_Usuario_OID, string p_foto)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Usuario_cambiarFoto_customized) START*/

        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Foto = p_foto;
        //Call to UsuarioCAD

        _IUsuarioCAD.CambiarFoto (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
