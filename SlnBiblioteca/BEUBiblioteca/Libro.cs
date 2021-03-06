//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUBiblioteca
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Libro
    {
        [ScaffoldColumn(false)]
        public int idLibro { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El título es requerido"), MaxLength(55)]
        [Display(Name = "Título:")]
        public string titulo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El autor es requerido"), MaxLength(55)]
        [Display(Name = "Autor:")]
        public string autor { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El ISBN es requerido"), MaxLength(55)]
        [Display(Name = "ISBN:")]
        public string isbn { get; set; }

        [Display(Name = "Fecha de Publicación: ")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fechapublicacion { get; set; }

        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "El número de ejemplares es requerido")]
        [Display(Name = "Número de ejemplares:")]
        public Nullable<int> numeroejemplares { get; set; }
        public Nullable<int> idCategoria { get; set; }
    
        public virtual Categoria Categoria { get; set; }
    }
}
