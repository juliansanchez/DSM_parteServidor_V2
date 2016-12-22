
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Libro_denunciar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class LibroCEN
{
public void Denunciar (int idlibro)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Libro_denunciar) ENABLED START*/

        // Write here your custom code...

        LibroEN libroEN = null;

        //Initialized LibroEN

        libroEN = _ILibroCAD.ReadOIDDefault (idlibro);

        libroEN.Num_denuncias++;

        if(libroEN.EnRevision == false){
            libroEN.EnRevision = true;
        }
        



        _ILibroCAD.ModifyDefault (libroEN);

        /*PROTECTED REGION END*/
}
}
}
