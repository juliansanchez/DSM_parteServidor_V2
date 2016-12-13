
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;



/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CP.GrayLine_Administrador_eliminarLibro) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class AdministradorCP : BasicCP
{
public void EliminarLibro (string p_Administrador_OID)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CP.GrayLine_Administrador_eliminarLibro) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;



        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);




                AdministradorEN administradorEN = null;
                //Initialized AdministradorEN
                administradorEN = new AdministradorEN ();
                administradorEN.Email = p_Administrador_OID;
                //Call to AdministradorCAD

                administradorCAD.EliminarLibro (administradorEN);


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
