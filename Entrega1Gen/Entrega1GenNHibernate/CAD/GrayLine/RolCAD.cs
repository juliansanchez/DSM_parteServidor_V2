
using System;
using System.Text;
using Entrega1GenNHibernate.CEN.GrayLine;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.Exceptions;


/*
 * Clase Rol:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class RolCAD : BasicCAD, IRolCAD
{
public RolCAD() : base ()
{
}

public RolCAD(ISession sessionAux) : base (sessionAux)
{
}



public RolEN ReadOIDDefault (string tipoRoll
                             )
{
        RolEN rolEN = null;

        try
        {
                SessionInitializeTransaction ();
                rolEN = (RolEN)session.Get (typeof(RolEN), tipoRoll);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rolEN;
}

public System.Collections.Generic.IList<RolEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RolEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RolEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RolEN>();
                        else
                                result = session.CreateCriteria (typeof(RolEN)).List<RolEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                RolEN rolEN = (RolEN)session.Load (typeof(RolEN), rol.TipoRoll);

                session.Update (rolEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (rol);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rol.TipoRoll;
}

public void Modify (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                RolEN rolEN = (RolEN)session.Load (typeof(RolEN), rol.TipoRoll);
                session.Update (rolEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string tipoRoll
                     )
{
        try
        {
                SessionInitializeTransaction ();
                RolEN rolEN = (RolEN)session.Load (typeof(RolEN), tipoRoll);
                session.Delete (rolEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in RolCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
