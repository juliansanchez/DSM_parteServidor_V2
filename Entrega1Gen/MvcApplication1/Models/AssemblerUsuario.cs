/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entrega1GenNHibernate.EN.GrayLine;

namespace MvcApplication1.Models
{
    public class AssemblerUsuario
    {
        public Usuario ConvertENToModelUI(UsuarioEN en)
        {
            Libro art = new Libro();
            art.id = en.Id_libro;
            art.titulo = en.Titulo;
            art.portada = en.Portada;
            art.descripcion = en.Descripcion;
            art.fecha = en.Fecha;
            art.publicado = en.Publicado;
            art.baneado = en.Baneado;
            art.numDen = en.Num_denuncias;
            return art;



        }
        public IList<Libro> ConvertListENToModel(IList<LibroEN> ens)
        {
            IList<Libro> arts = new List<Libro>();
            foreach (LibroEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }

    }
}*/