
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
 * Clase Valoracion:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class ValoracionCAD : BasicCAD, IValoracionCAD
{
public ValoracionCAD() : base ()
{
}

public ValoracionCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionEN ReadOIDDefault (int id
                                    )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionEN)).List<ValoracionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), valoracion.Id);

                valoracionEN.Puntuacion = valoracion.Puntuacion;



                session.Update (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracion.Libro != null) {
                        // Argumento OID y no colección.
                        valoracion.Libro = (Entrega1GenNHibernate.EN.GrayLine.LibroEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.LibroEN), valoracion.Libro.Id_libro);

                        valoracion.Libro.Valoracion
                        .Add (valoracion);
                }
                if (valoracion.Usuario != null) {
                        // Argumento OID y no colección.
                        valoracion.Usuario = (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.UsuarioEN), valoracion.Usuario.Alias);

                        valoracion.Usuario.Valoracion
                        .Add (valoracion);
                }

                session.Save (valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracion.Id;
}

public void Modify (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), valoracion.Id);

                valoracionEN.Puntuacion = valoracion.Puntuacion;

                session.Update (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), id);
                session.Delete (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> ValoracionesLibro (int ? identificadorlibro)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN val WHERE  (val.Libro= :identificadorlibro)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENvaloracionesLibroHQL");
                query.SetParameter ("identificadorlibro", identificadorlibro);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> ValoracionUnicaFiltro (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN usuario1, int ? libro1)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN val WHERE (val.Libro=:libro1) AND (val.Usuario=:usuario1)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENvaloracionUnicaFiltroHQL");
                query.SetParameter ("usuario1", usuario1);
                query.SetParameter ("libro1", libro1);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
