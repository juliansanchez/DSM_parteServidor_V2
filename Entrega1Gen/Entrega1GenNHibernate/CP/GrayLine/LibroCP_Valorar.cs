
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;



/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CP.GrayLine_Libro_valorar) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class LibroCP : BasicCP
{
public void Valorar (int p_Libro_OID, int puntuacion, string emailusuario)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CP.GrayLine_Libro_valorar) ENABLED START*/

        ILibroCAD libroCAD = null;
        LibroCEN libroCEN = null;
        IValoracionCAD valoracionCAD = null;
        ValoracionCEN valoracionCEN = null;

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;


        try
        {
                SessionInitializeTransaction ();
                libroCAD = new LibroCAD (session);
                libroCEN = new LibroCEN (libroCAD);

                valoracionCAD = new ValoracionCAD (session);
                valoracionCEN = new ValoracionCEN (valoracionCAD);

                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);




                // Write here your custom transaction ...

                UsuarioEN nombre = usuarioCEN.VerUsuario (emailusuario);

                IList<ValoracionEN> usuarioUnico = valoracionCEN.ValoracionUnicaFiltro (nombre, p_Libro_OID);

                if (usuarioUnico.Count == 0) {
                        var nuevaValoracion = valoracionCEN.New_ (puntuacion, p_Libro_OID, emailusuario);

                        IList<ValoracionEN> listValoraciones = valoracionCEN.ValoracionesLibro (p_Libro_OID);


                        // Para visualizar las categorias de los libros
                        if (listValoraciones != null) {
                                float sumatorio = 0;
                                float contador = 0;
                                float total = 0;

                                foreach (ValoracionEN valoraciones in listValoraciones) {
                                        sumatorio += valoraciones.Puntuacion;
                                        contador++;
                                }

                                total = sumatorio / contador;
                                libroCEN.ModificarNotaMedia (p_Libro_OID, total);
                        }
                }
                else{
                        System.Console.WriteLine ("No puedes valorar otra vez");
                }
                /*
                 * else {
                 *
                 * throw new StackOverflowException("Ya has valorado este libro");
                 *
                 * }
                 *
                 */



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
