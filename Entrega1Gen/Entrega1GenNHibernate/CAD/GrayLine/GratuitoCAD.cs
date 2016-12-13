
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
 * Clase Gratuito:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class GratuitoCAD : BasicCAD, IGratuitoCAD
{
public GratuitoCAD() : base ()
{
}

public GratuitoCAD(ISession sessionAux) : base (sessionAux)
{
}



public GratuitoEN ReadOIDDefault (int id_libro
                                  )
{
        GratuitoEN gratuitoEN = null;

        try
        {
                SessionInitializeTransaction ();
                gratuitoEN = (GratuitoEN)session.Get (typeof(GratuitoEN), id_libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in GratuitoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gratuitoEN;
}

public System.Collections.Generic.IList<GratuitoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GratuitoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GratuitoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GratuitoEN>();
                        else
                                result = session.CreateCriteria (typeof(GratuitoEN)).List<GratuitoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in GratuitoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GratuitoEN gratuito)
{
        try
        {
                SessionInitializeTransaction ();
                GratuitoEN gratuitoEN = (GratuitoEN)session.Load (typeof(GratuitoEN), gratuito.Id_libro);
                session.Update (gratuitoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in GratuitoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (GratuitoEN gratuito)
{
        try
        {
                SessionInitializeTransaction ();
                if (gratuito.Usuario != null) {
                        for (int i = 0; i < gratuito.Usuario.Count; i++) {
                                gratuito.Usuario [i] = (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.UsuarioEN), gratuito.Usuario [i].Email);
                                gratuito.Usuario [i].Libro.Add (gratuito);
                        }
                }
                if (gratuito.Categoria != null) {
                        for (int i = 0; i < gratuito.Categoria.Count; i++) {
                                gratuito.Categoria [i] = (Entrega1GenNHibernate.EN.GrayLine.CategoriaEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.CategoriaEN), gratuito.Categoria [i].Id_categoria);
                                gratuito.Categoria [i].Libro.Add (gratuito);
                        }
                }

                session.Save (gratuito);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in GratuitoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gratuito.Id_libro;
}

public System.Collections.Generic.IList<GratuitoEN> VerLibrosGratuitos (int first, int size)
{
        System.Collections.Generic.IList<GratuitoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GratuitoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GratuitoEN>();
                else
                        result = session.CreateCriteria (typeof(GratuitoEN)).List<GratuitoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in GratuitoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
