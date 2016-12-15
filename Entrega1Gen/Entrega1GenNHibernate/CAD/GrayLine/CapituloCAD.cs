
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
 * Clase Capitulo:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class CapituloCAD : BasicCAD, ICapituloCAD
{
public CapituloCAD() : base ()
{
}

public CapituloCAD(ISession sessionAux) : base (sessionAux)
{
}



public CapituloEN ReadOIDDefault (int id_capitulo
                                  )
{
        CapituloEN capituloEN = null;

        try
        {
                SessionInitializeTransaction ();
                capituloEN = (CapituloEN)session.Get (typeof(CapituloEN), id_capitulo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return capituloEN;
}

public System.Collections.Generic.IList<CapituloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CapituloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CapituloEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CapituloEN>();
                        else
                                result = session.CreateCriteria (typeof(CapituloEN)).List<CapituloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CapituloEN capitulo)
{
        try
        {
                SessionInitializeTransaction ();
                CapituloEN capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), capitulo.Id_capitulo);

                capituloEN.Nombre = capitulo.Nombre;


                capituloEN.Numero = capitulo.Numero;


                capituloEN.Contenido = capitulo.Contenido;




                capituloEN.Editando = capitulo.Editando;

                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CapituloEN capitulo)
{
        try
        {
                SessionInitializeTransaction ();
                if (capitulo.Libro != null) {
                        // Argumento OID y no colección.
                        capitulo.Libro = (Entrega1GenNHibernate.EN.GrayLine.LibroEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.LibroEN), capitulo.Libro.Id_libro);

                        capitulo.Libro.Capitulo
                        .Add (capitulo);
                }

                session.Save (capitulo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return capitulo.Id_capitulo;
}

public void CambiarNombre (CapituloEN capitulo)
{
        try
        {
                SessionInitializeTransaction ();
                CapituloEN capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), capitulo.Id_capitulo);
                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarCapitulo (int id_capitulo
                              )
{
        try
        {
                SessionInitializeTransaction ();
                CapituloEN capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), id_capitulo);
                session.Delete (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void InvitarUsuario (int p_Capitulo_OID, string p_usuario_OID)
{
        Entrega1GenNHibernate.EN.GrayLine.CapituloEN capituloEN = null;
        try
        {
                SessionInitializeTransaction ();
                capituloEN = (CapituloEN)session.Load (typeof(CapituloEN), p_Capitulo_OID);
                capituloEN.Usuario = (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.UsuarioEN), p_usuario_OID);

                capituloEN.Usuario.Capitulo.Add (capituloEN);



                session.Update (capituloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<CapituloEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CapituloEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CapituloEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CapituloEN>();
                else
                        result = session.CreateCriteria (typeof(CapituloEN)).List<CapituloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> LeerCapitulo (int ? id_libro)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CapituloEN self where FROM CapituloEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CapituloENleerCapituloHQL");
                query.SetParameter ("id_libro", id_libro);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.CapituloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> BuscarCapitulo (int ? idlibro)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.CapituloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CapituloEN self where FROM CapituloEN cap WHERE cap.Libro=:idlibro";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CapituloENbuscarCapituloHQL");
                query.SetParameter ("idlibro", idlibro);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.CapituloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: VerCapitulo
//Con e: CapituloEN
public CapituloEN VerCapitulo (int id_capitulo
                               )
{
        CapituloEN capituloEN = null;

        try
        {
                SessionInitializeTransaction ();
                capituloEN = (CapituloEN)session.Get (typeof(CapituloEN), id_capitulo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CapituloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return capituloEN;
}
}
}
