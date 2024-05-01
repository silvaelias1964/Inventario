using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class EntradaViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Producto")]
        public int? ProductoId { get; set; }

        [Display(Name = "Precio Unidad")]
        [Required]
        public decimal EntPrecioUnidad { get; set; }

        [Display(Name = "Cantidad")]
        [Required]
        public int EntStock { get; set; }

        [Display(Name = "Detalles")]        
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Required]
        public string EntDetalles { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        public DateTime? EntFecha { get; set; }

        [Required]
        public int EntEstatus { get; set; }

        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref EntradaModel model)
        {
            model.Id = Id;
            model.ProductodId = ProductoId;
            model.EntStock = EntStock;
            model.EntDetalles = EntDetalles;
            model.EntFecha = EntFecha;
            model.EntEstatus = EntEstatus;
            model.EntPrecioUnidad = EntPrecioUnidad;
            model.EntEstatus = EntEstatus;
        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref Entrada model)
        {
            Id = model.Id;
            ProductoId = model.ProductoId;
            EntStock = model.EntStock;
            EntDetalles = model.EntDetalles;
            EntFecha = model.EntFecha;
            EntEstatus = model.EntEstatus;
            EntPrecioUnidad = model.EntPrecioUnidad;
            EntEstatus = model.EntEstatus;
        }


    }
}
