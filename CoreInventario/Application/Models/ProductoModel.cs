using CoreInventario.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }

        public string PrdCodigo { get; set; }

        public string PrdNombre { get; set; }

        public int? CatId { get; set; }

        public int? PrvId { get; set; }

        public string PrdCantPorUnidad { get; set; }

        public decimal PrdPrecioUnidad { get; set; }

        public int PrdStockMinimo { get; set; }

        public int PrdStock { get; set; }

        public int PrdEstatus { get; set; }

        public string PrdFoto1 { get; set; }
        public string PrdFoto2 { get; set; }
        

        public virtual CategoriaProducto CategoriaProductos { get; set; }
        public virtual Proveedor Proveedores { get; set; }

    }
}
