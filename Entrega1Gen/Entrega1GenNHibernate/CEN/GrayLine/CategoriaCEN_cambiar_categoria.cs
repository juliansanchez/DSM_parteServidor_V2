
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


/*PROTECTED REGION ID(usingEntrega1GenNHibernate.CEN.GrayLine_Categoria_cambiar_categoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Entrega1GenNHibernate.CEN.GrayLine
{
public partial class CategoriaCEN
{
public void Cambiar_categoria (Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum p_nombre_categoria)
{
        /*PROTECTED REGION ID(Entrega1GenNHibernate.CEN.GrayLine_Categoria_cambiar_categoria_customized) START*/

        CategoriaEN categoriaEN = null;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Nombre_categoria = p_nombre_categoria;
        //Call to CategoriaCAD

        _ICategoriaCAD.Cambiar_categoria (categoriaEN);

        /*PROTECTED REGION END*/
}
}
}
