

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
 *      Definition of the class CapituloCEN
 *
 */
public partial class CapituloCEN
{
private ICapituloCAD _ICapituloCAD;

public CapituloCEN()
{
        this._ICapituloCAD = new CapituloCAD ();
}

public CapituloCEN(ICapituloCAD _ICapituloCAD)
{
        this._ICapituloCAD = _ICapituloCAD;
}

public ICapituloCAD get_ICapituloCAD ()
{
        return this._ICapituloCAD;
}

public int New_ (string p_nombre, int p_numero, string p_contenido, int p_libro, bool p_editando)
{
        CapituloEN capituloEN = null;
        int oid;

        //Initialized CapituloEN
        capituloEN = new CapituloEN ();
        capituloEN.Nombre = p_nombre;

        capituloEN.Numero = p_numero;

        capituloEN.Contenido = p_contenido;


        if (p_libro != -1) {
                // El argumento p_libro -> Property libro es oid = false
                // Lista de oids id_capitulo
                capituloEN.Libro = new Entrega1GenNHibernate.EN.GrayLine.LibroEN ();
                capituloEN.Libro.Id_libro = p_libro;
        }

        capituloEN.Editando = p_editando;

        //Call to CapituloCAD

        oid = _ICapituloCAD.New_ (capituloEN);
        return oid;
}

public void EliminarCapitulo (int id_capitulo
                              )
{
        _ICapituloCAD.EliminarCapitulo (id_capitulo);
}

public System.Collections.Generic.IList<CapituloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CapituloEN> list = null;

        list = _ICapituloCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> BuscarCapitulo (int ? idlibro)
{
        return _ICapituloCAD.BuscarCapitulo (idlibro);
}
public CapituloEN VerCapitulo (int id_capitulo
                               )
{
        CapituloEN capituloEN = null;

        capituloEN = _ICapituloCAD.VerCapitulo (id_capitulo);
        return capituloEN;
}
}
}
