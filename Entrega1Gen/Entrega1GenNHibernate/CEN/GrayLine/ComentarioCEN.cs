

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (string p_texto_comentario, int p_libro, bool p_baneado)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Texto_comentario = p_texto_comentario;


        if (p_libro != -1) {
                // El argumento p_libro -> Property libro es oid = false
                // Lista de oids id
                comentarioEN.Libro = new Entrega1GenNHibernate.EN.GrayLine.LibroEN ();
                comentarioEN.Libro.Id_libro = p_libro;
        }

        comentarioEN.Baneado = p_baneado;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Destroy (int id
                     )
{
        _IComentarioCAD.Destroy (id);
}

public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN> VerComentarios (int ? idlibro)
{
        return _IComentarioCAD.VerComentarios (idlibro);
}
}
}
