using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class SalidaViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        public int? ProductoId { get; set; }

        //[Display(Name = "Precio Unidad")]
        //[Required(ErrorMessage = "El campo: {0} es requerido")]
        //[RegularExpression(@"^\d{1,20}(\.\d{1,10})?$", ErrorMessage = "PriceMaxLenght")]
        //[DisplayFormat(DataFormatString = "{0:#.##########}")]
        //public string SalPrecioUnidad { get; set; }


        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        //[Range(0, int.MaxValue, ErrorMessage = "Introduce un valor mayor a cero..")]
        public int SalStock { get; set; }

        [Display(Name = "Detalles")]
        //[Required(ErrorMessage = "El campo: {0} es requerido")]
        //[StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]        
        [MaxLength(255)]
        public string? SalDetalles { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        public DateTime? SalFecha { get; set; }

        [Display(Name = "Procesado")]
        [Required]
        public int SalEstatus { get; set; }

        [Display(Name = "¿ Actualiza Inventario ?")]
        public bool ActualizaInv { get; set; }



        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref SalidaModel model)
        {
            model.Id = Id;
            model.ProductoId = ProductoId;
            model.SalStock = SalStock;
            model.SalDetalles = SalDetalles;
            model.SalFecha = SalFecha;
            model.SalEstatus = SalEstatus;
            //SalPrecioUnidad = SalPrecioUnidad.Replace(".", ",");
            //model.SalPrecioUnidad = decimal.Parse(SalPrecioUnidad);
            model.SalEstatus = SalEstatus;
            model.ActualizaInv = ActualizaInv;
        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref Salida model)
        {
            Id = model.Id;
            ProductoId = model.ProductoId;
            SalStock = model.SalStock;
            SalDetalles = model.SalDetalles;
            SalFecha = model.SalFecha;
            SalEstatus = model.SalEstatus;
            //SalPrecioUnidad = model.SalPrecioUnidad.ToString();
            //SalPrecioUnidad = SalPrecioUnidad.Replace(",", ".");
            SalEstatus = model.SalEstatus;
        }


    }
}
