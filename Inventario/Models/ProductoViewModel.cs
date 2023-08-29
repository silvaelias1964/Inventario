using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class ProductoViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Código Producto")]
        [MaxLength(15)]
        public string? PrdCodigo { get; set; }

        [Display(Name = "Nombre del Producto")]
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string PrdNombre { get; set; }

        [Display(Name = "Categoría Producto")]
        [Required]
        public int CatId { get; set; }

        [Display(Name = "Proveedor")]
        [Required]
        public int PrvId { get; set; }

        [Display(Name = "Cantidad")]
        [Required]        
        public int PrdStock { get; set; }

        [Display(Name = "Cantidad mínima")]
        [Required]
        public int PrdStockMinimo { get; set; }

        [Display(Name = "Cant.xUnidad")]
        [MaxLength(20)]
        public string? PrdCantPorUnidad { get; set; }

        [Display(Name = "Precio Unidad")]
        [Required]        
        public decimal PrdPrecioUnidad { get; set; }

        [Display(Name = "Estatus")]
        [Required]
        public int PrdEstatus { get; set; }

        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref ProductoModel model) 
        {
            model.Id = Id;
            model.PrdCodigo = PrdCodigo;
            model.PrdNombre = PrdNombre;
            model.PrvId = PrvId;
            model.CatId = CatId;
            model.PrdCantPorUnidad= PrdCantPorUnidad;
            model.PrdPrecioUnidad = PrdPrecioUnidad;
            model.PrdStockMinimo = PrdStockMinimo;
            model.PrdStock = PrdStock;
            model.PrdEstatus=PrdEstatus;
        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref Producto model)
        {
            Id = model.Id;
            PrdCodigo = model.PrdCodigo;
            PrdNombre = model.PrdNombre;
            PrvId = model.PrvId.GetValueOrDefault();
            CatId = model.CatId.GetValueOrDefault();
            PrdCantPorUnidad = model.PrdCantPorUnidad;
            PrdPrecioUnidad = model.PrdPrecioUnidad;
            PrdStockMinimo = model.PrdStockMinimo;
            PrdStock = model.PrdStock;
            PrdEstatus = model.PrdEstatus;
        }

    }
}
