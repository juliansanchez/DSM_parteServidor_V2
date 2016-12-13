
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Comentario_editarComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class ComentarioCEN
{
public void EditarComentario (int p_Comentario_OID, string p_texto_comentario)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Comentario_editarComentario_customized) START*/

        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Texto_comentario = p_texto_comentario;
        //Call to ComentarioCAD

        _IComentarioCAD.EditarComentario (comentarioEN);

        /*PROTECTED REGION END*/
}
}
}
