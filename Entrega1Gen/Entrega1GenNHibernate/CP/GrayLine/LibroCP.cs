
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Entrega1GenNHibernate.Exceptions;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;


namespace Entrega1GenNHibernate.CP.GrayLine
{
public partial class LibroCP : BasicCP
{
public LibroCP() : base ()
{
}

public LibroCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
