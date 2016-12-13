
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Usuario_denunciarUser) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class UsuarioCEN
{
public void DenunciarUser (string p_oid)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Usuario_denunciarUser) ENABLED START*/

        // Write here your custom code...

        UsuarioEN usuarioEN = null;

        //Initialized LibroEN

        usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_oid);

        usuarioEN.NumDenunciasUser++;

        _IUsuarioCAD.ModifyDefault (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
