
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
 * Clase Pago:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class PagoCAD : BasicCAD, IPagoCAD
{
public PagoCAD() : base ()
{
}

public PagoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PagoEN ReadOIDDefault (int id_libro
                              )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoEN), id_libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PagoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                        else
                                result = session.CreateCriteria (typeof(PagoEN)).List<PagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), pago.Id_libro);

                pagoEN.Precio = pago.Precio;


                pagoEN.Pagado = pago.Pagado;

                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Pagar (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), pago.Id_libro);
                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public int New_ (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                if (pago.Usuario != null) {
                        for (int i = 0; i < pago.Usuario.Count; i++) {
                                pago.Usuario [i] = (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.UsuarioEN), pago.Usuario [i].Email);
                                pago.Usuario [i].Libro.Add (pago);
                        }
                }
                if (pago.Categoria != null) {
                        for (int i = 0; i < pago.Categoria.Count; i++) {
                                pago.Categoria [i] = (Entrega1GenNHibernate.EN.GrayLine.CategoriaEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.CategoriaEN), pago.Categoria [i].Id_categoria);
                                pago.Categoria [i].Libro.Add (pago);
                        }
                }

                session.Save (pago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pago.Id_libro;
}

public System.Collections.Generic.IList<PagoEN> VerLibrosPago (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PagoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                else
                        result = session.CreateCriteria (typeof(PagoEN)).List<PagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
