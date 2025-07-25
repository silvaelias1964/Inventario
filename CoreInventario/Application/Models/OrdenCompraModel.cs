﻿using CoreInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class OrdenCompraModel
    {
        public OrdenCompraModel()
        {
            OrdenCompraDetalleModels = new List<OrdenCompraDetalleModel>();
                
        }

        public int Id { get; set; }
        public string OccNroOrden { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? OccFechaEmision { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? OccFechaOrden { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? OccFechaVencimiento { get; set; }

        public int ProveedorId { get; set; }
        public decimal OccIVA { get; set; }
        public decimal OccDescuento { get; set; }
        public decimal OccGasto { get; set; }
        public int OccEstatus { get; set; }

        public bool OccMismaDireccion { get; set; }
        public string OccDireccion { get; set; }
        public string OccTelefonos { get; set; }
        public string OccCorreosElec { get; set; }
        public string OccObservaciones { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual IList<OrdenCompraDetalleModel> OrdenCompraDetalleModels { get; set; }

    }
}
