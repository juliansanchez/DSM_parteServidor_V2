

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
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionCAD _IValoracionCAD;

public ValoracionCEN()
{
        this._IValoracionCAD = new ValoracionCAD ();
}

public ValoracionCEN(IValoracionCAD _IValoracionCAD)
{
        this._IValoracionCAD = _IValoracionCAD;
}

public IValoracionCAD get_IValoracionCAD ()
{
        return this._IValoracionCAD;
}

public int New_ (int p_puntuacion, int p_libro, string p_usuario)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Puntuacion = p_puntuacion;


        if (p_libro != -1) {
                // El argumento p_libro -> Property libro es oid = false
                // Lista de oids id
                valoracionEN.Libro = new Entrega1GenNHibernate.EN.GrayLine.LibroEN ();
                valoracionEN.Libro.Id_libro = p_libro;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                valoracionEN.Usuario = new Entrega1GenNHibernate.EN.GrayLine.UsuarioEN ();
                valoracionEN.Usuario.Alias = p_usuario;
        }

        //Call to ValoracionCAD

        oid = _IValoracionCAD.New_ (valoracionEN);
        return oid;
}

public void Modify (int p_Valoracion_OID, int p_puntuacion)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Puntuacion = p_puntuacion;
        //Call to ValoracionCAD

        _IValoracionCAD.Modify (valoracionEN);
}

public void Destroy (int id
                     )
{
        _IValoracionCAD.Destroy (id);
}

public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> ValoracionesLibro (int ? identificadorlibro)
{
        return _IValoracionCAD.ValoracionesLibro (identificadorlibro);
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> ValoracionUnicaFiltro (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario1, int ? libro1)
{
        return _IValoracionCAD.ValoracionUnicaFiltro (usuario1, libro1);
}
}
}
