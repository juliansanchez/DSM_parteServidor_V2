
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
 * Clase Libro:
 *
 */

namespace Entrega1GenNHibernate.CAD.GrayLine
{
public partial class LibroCAD : BasicCAD, ILibroCAD
{
public LibroCAD() : base ()
{
}

public LibroCAD(ISession sessionAux) : base (sessionAux)
{
}



public LibroEN ReadOIDDefault (int id_libro
                               )
{
        LibroEN libroEN = null;

        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Get (typeof(LibroEN), id_libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libroEN;
}

public System.Collections.Generic.IList<LibroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LibroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                        else
                                result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.Titulo = libro.Titulo;


                libroEN.Portada = libro.Portada;


                libroEN.Descripcion = libro.Descripcion;


                libroEN.Fecha = libro.Fecha;


                libroEN.Publicado = libro.Publicado;





                libroEN.Baneado = libro.Baneado;




                libroEN.Num_denuncias = libro.Num_denuncias;


                libroEN.NotaMediaValoracion = libro.NotaMediaValoracion;


                libroEN.ContValoraciones = libro.ContValoraciones;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLibro (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                if (libro.Usuario != null) {
                        // Argumento OID y no colección.
                        libro.Usuario = (Entrega1GenNHibernate.EN.GrayLine.UsuarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.UsuarioEN), libro.Usuario.Email);

                        libro.Usuario.Libro
                        .Add (libro);
                }
                if (libro.Categoria != null) {
                        for (int i = 0; i < libro.Categoria.Count; i++) {
                                libro.Categoria [i] = (Entrega1GenNHibernate.EN.GrayLine.CategoriaEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.CategoriaEN), libro.Categoria [i].Id_categoria);
                                libro.Categoria [i].Libro.Add (libro);
                        }
                }

                session.Save (libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libro.Id_libro;
}

public void EliminarLibro (int id_libro
                           )
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), id_libro);
                session.Delete (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void CambiarTitulo (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.Titulo = libro.Titulo;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void CambiarPortada (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.Portada = libro.Portada;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void CambiarDescripcion (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.Descripcion = libro.Descripcion;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<LibroEN> VerLibreria (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LibroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                else
                        result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: VerLibro
//Con e: LibroEN
public LibroEN VerLibro (int id_libro
                         )
{
        LibroEN libroEN = null;

        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Get (typeof(LibroEN), id_libro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return libroEN;
}

public void Publicar (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.Publicado = libro.Publicado;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<LibroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LibroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LibroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LibroEN>();
                else
                        result = session.CreateCriteria (typeof(LibroEN)).List<LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Comentar (int p_Libro_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        Entrega1GenNHibernate.EN.GrayLine.LibroEN libroEN = null;
        try
        {
                SessionInitializeTransaction ();
                libroEN = (LibroEN)session.Load (typeof(LibroEN), p_Libro_OID);
                Entrega1GenNHibernate.EN.GrayLine.ComentarioEN comentarioENAux = null;
                if (libroEN.Comentario == null) {
                        libroEN.Comentario = new System.Collections.Generic.List<Entrega1GenNHibernate.EN.GrayLine.ComentarioEN>();
                }

                foreach (int item in p_comentario_OIDs) {
                        comentarioENAux = new Entrega1GenNHibernate.EN.GrayLine.ComentarioEN ();
                        comentarioENAux = (Entrega1GenNHibernate.EN.GrayLine.ComentarioEN)session.Load (typeof(Entrega1GenNHibernate.EN.GrayLine.ComentarioEN), item);
                        comentarioENAux.Libro = libroEN;

                        libroEN.Comentario.Add (comentarioENAux);
                }


                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibro (string nombre)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LibroEN self where FROM LibroEN li WHERE  (li.Titulo= :nombre)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LibroENbuscarLibroHQL");
                query.SetParameter ("nombre", nombre);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> BuscarLibroPorCategoria (int ? id_categoria)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LibroEN self where select lib FROM LibroEN lib INNER JOIN lib.Categoria cat WHERE cat.Id_categoria=:id_categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LibroENbuscarLibroPorCategoriaHQL");
                query.SetParameter ("id_categoria", id_categoria);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> VerLibrosUsuario (string nombre)
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LibroEN self where  SELECT lib FROM  LibroEN lib INNER JOIN lib.Usuario usu WHERE usu.Email=:nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LibroENverLibrosUsuarioHQL");
                query.SetParameter ("nombre", nombre);

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void ModificarNotaMedia (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.NotaMediaValoracion = libro.NotaMediaValoracion;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> MejoresLibros ()
{
        System.Collections.Generic.IList<Entrega1GenNHibernate.EN.GrayLine.LibroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LibroEN self where FROM LibroEN lib ORDER BY lib.NotaMediaValoracion DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LibroENmejoresLibrosHQL");

                result = query.List<Entrega1GenNHibernate.EN.GrayLine.LibroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void NumValoraciones (LibroEN libro)
{
        try
        {
                SessionInitializeTransaction ();
                LibroEN libroEN = (LibroEN)session.Load (typeof(LibroEN), libro.Id_libro);

                libroEN.ContValoraciones = libro.ContValoraciones;

                session.Update (libroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Entrega1GenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Entrega1GenNHibernate.Exceptions.DataLayerException ("Error in LibroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
