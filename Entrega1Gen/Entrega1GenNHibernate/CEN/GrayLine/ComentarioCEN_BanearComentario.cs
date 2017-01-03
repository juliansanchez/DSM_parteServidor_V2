
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Comentario_banearComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class ComentarioCEN
{
public void BanearComentario (int p_Comentario_OID)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Comentario_banearComentario_customized) ENABLED START*/

        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Baneado = true;
        //Call to ComentarioCAD

        _IComentarioCAD.BanearComentario (comentarioEN);

        /*PROTECTED REGION END*/
}
}
}
