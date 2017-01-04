
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Entrega1GenNHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Libro_banearLibro) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class LibroCEN
{
public void BanearLibro (int p_Libro_OID)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Libro_banearLibro) ENABLED START*/

        // Write here your custom code...
        try
        {
                // capturamos el usuario baneado

                LibroEN libroEN = _ILibroCAD.ReadOIDDefault (p_Libro_OID);

                if (p_Libro_OID != null && libroEN.Baneado == false) {
                        libroEN.Baneado = true;
                        _ILibroCAD.ModifyDefault (libroEN);
                }
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }



        /*PROTECTED REGION END*/
}
}
}
