
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;



/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CP.GrayLine_Capitulo_invitarUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class CapituloCP : BasicCP
{
public void InvitarUsuario (int p_Capitulo_OID, string p_usuario_OID)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CP.GrayLine_Capitulo_invitarUsuario) ENABLED START*/

        ICapituloCAD capituloCAD = null;
        CapituloCEN capituloCEN = null;



        try
        {
                SessionInitializeTransaction ();
                capituloCAD = new CapituloCAD (session);
                capituloCEN = new  CapituloCEN (capituloCAD);






                //Call to CapituloCAD

                capituloCAD.InvitarUsuario (p_Capitulo_OID, p_usuario_OID);



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
