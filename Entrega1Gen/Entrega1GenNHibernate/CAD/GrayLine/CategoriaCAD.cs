
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
 * Clase Categoria:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class CategoriaCAD : BasicCAD, ICategoriaCAD
{
public CategoriaCAD() : base ()
{
}

public CategoriaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CategoriaEN ReadOIDDefault (int id_categoria
                                   )
{
        CategoriaEN categoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Get (typeof(CategoriaEN), id_categoria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaEN)).List<CategoriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), categoria.Id_categoria);

                categoriaEN.Nombre_categoria = categoria.Nombre_categoria;


                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (categoria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoria.Id_categoria;
}

public void Cambiar_categoria (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), categoria.Id_categoria);
                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id_categoria
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), id_categoria);
                session.Delete (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<CategoriaEN> VerCategorias (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CategoriaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                else
                        result = session.CreateCriteria (typeof(CategoriaEN)).List<CategoriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
