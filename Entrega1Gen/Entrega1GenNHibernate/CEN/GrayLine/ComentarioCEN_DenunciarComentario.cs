
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Comentario_denunciarComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class ComentarioCEN
{
public void DenunciarComentario (int p_oid)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Comentario_denunciarComentario) ENABLED START*/

        // Write here your custom code...

        ComentarioEN comentarioEN = null;

        //Initialized LibroEN

        comentarioEN = _IComentarioCAD.ReadOIDDefault (p_oid);

        comentarioEN.NumdenunciasComentario++;

        if (comentarioEN.EnRevisionC == false) {
                comentarioEN.EnRevisionC = true;
        }

        _IComentarioCAD.ModifyDefault (comentarioEN);

        /*PROTECTED REGION END*/
}
}
}
