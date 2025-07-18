﻿using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class EntradaViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        public int? ProductoId { get; set; }

        [Display(Name = "Precio Unidad")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        [RegularExpression(@"^\d{1,20}(\.\d{1,10})?$", ErrorMessage = "PriceMaxLenght")]
        [DisplayFormat(DataFormatString = "{0:#.##########}")]
        public string EntPrecioUnidad { get; set; }


        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        //[Range(0, int.MaxValue, ErrorMessage = "Introduce un valor mayor a cero..")]
        public int EntStock { get; set; }

        [Display(Name = "Detalles")]
        //[Required(ErrorMessage = "El campo: {0} es requerido")]
        //[StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} y máximo {1} caracteres", MinimumLength = 3)]        
        [MaxLength(255)]
        public string? EntDetalles { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo: {0} es requerido")]
        public DateTime? EntFecha { get; set; }

        [Display(Name = "Procesado")]
        [Required]
        public int EntEstatus { get; set; }

        [Display(Name = "¿ Actualiza Inventario ?")]        
        public bool ActualizaInv { get; set; }



        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref EntradaModel model)
        {
            model.Id = Id;
            model.ProductoId = ProductoId;
            model.EntStock = EntStock;
            model.EntDetalles = EntDetalles;
            model.EntFecha = EntFecha;
            model.EntEstatus = EntEstatus;
            EntPrecioUnidad = EntPrecioUnidad.Replace(".", ",");
            model.EntPrecioUnidad = decimal.Parse(EntPrecioUnidad);
            model.EntEstatus = EntEstatus;
            model.ActualizaInv= ActualizaInv;
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
            EntPrecioUnidad = model.EntPrecioUnidad.ToString();
            EntPrecioUnidad = EntPrecioUnidad.Replace(",", ".");
            EntEstatus = model.EntEstatus;
        }


    }
}
