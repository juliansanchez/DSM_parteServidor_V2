using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Libro
    {
        [ScaffoldColumn(false)]
     
        public int id { get; set; }


        [Display(Prompt = "Titulo del libro", Description = "Titulo del libro", Name = "Titulo ")]
        [Required(ErrorMessage = "Debe indicar un titulo para el libro")]
        [StringLength(maximumLength: 200, ErrorMessage = "El titulo no puede tener más de 200 caracteres")]
        public string titulo { get; set; }

        [Display(Prompt = "Portada del libro", Description = "Enlace a la Portada del libro", Name = "Portada")]
        public string portada { get; set; }

        [Display(Prompt = "Descripción del artículo", Description = "Descripción del artículo", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripcion no puede tener más de 500 caracteres")]
        public string descripcion { get; set; }
    
        [Display(Prompt =   "Fecha de subida", Description="Fecha de subida del libro",Name="Fecha")]
        public System.DateTime? fecha { get; set; }

        [Display(Prompt="Libro publicado",Description="El libro se ha publicado",Name="Publicado")]
        public Boolean publicado {get;set;}

         [Display(Prompt="Libro baneado",Description="El libro se ha baneado",Name="Baneado")]
        public Boolean baneado{get;set;}

        [Display(Prompt="Numero de denuncias",Description="El numero de denuncias del libro",Name="Numero de Denuncias")]
        public Int32 numDen{get;set;}





    }
}