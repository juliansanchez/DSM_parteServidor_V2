

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
 *      Definition of the class RolCEN
 *
 */
public partial class RolCEN
{
private IRolCAD _IRolCAD;

public RolCEN()
{
        this._IRolCAD = new RolCAD ();
}

public RolCEN(IRolCAD _IRolCAD)
{
        this._IRolCAD = _IRolCAD;
}

public IRolCAD get_IRolCAD ()
{
        return this._IRolCAD;
}

public string New_ (string p_tipoRoll)
{
        RolEN rolEN = null;
        string oid;

        //Initialized RolEN
        rolEN = new RolEN ();
        rolEN.TipoRoll = p_tipoRoll;

        //Call to RolCAD

        oid = _IRolCAD.New_ (rolEN);
        return oid;
}

public void Modify (string p_Rol_OID)
{
        RolEN rolEN = null;

        //Initialized RolEN
        rolEN = new RolEN ();
        rolEN.TipoRoll = p_Rol_OID;
        //Call to RolCAD

        _IRolCAD.Modify (rolEN);
}

public void Destroy (string tipoRoll
                     )
{
        _IRolCAD.Destroy (tipoRoll);
}

public RolEN ReadOID (string tipoRoll
                      )
{
        RolEN rolEN = null;

        rolEN = _IRolCAD.ReadOID (tipoRoll);
        return rolEN;
}

public System.Collections.Generic.IList<RolEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RolEN> list = null;

        list = _IRolCAD.ReadAll (first, size);
        return list;
}
}
}
