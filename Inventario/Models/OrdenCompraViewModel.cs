using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inventario.Models
{
    public class OrdenCompraViewModel
    {

        public OrdenCompraViewModel()
        {
            OrdenCompraDetalleModels = new List<OrdenCompraDetalleModel>();
        }

        [Display(Name="Id")]
        public int Id { get; set; }

        [Display(Name = "ODC Nro.")]
        public string OccNroOrden { get; set; }

        [Display(Name = "Fecha Emisión")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public string OccFechaEmision { get; set; }

        [Display(Name = "Fecha Orden")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public string OccFechaOrden { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public string OccFechaVencimiento { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [Display(Name = "IVA")]
        public decimal OccIVA { get; set; }

        [Display(Name = "Descuento")]
        public decimal OccDescuento { get; set; }

        [Display(Name = "Gastos adicionales")]
        public decimal OccGasto { get; set; }

        [Display(Name = "Estatus")]
        public int OccEstatus { get; set; }

        [Display(Name ="Dirección")]
        public string? OccDireccion { get; set; }

        [Display(Name = "Teléfonos")]
        public string? OccTelefonos { get; set; }

        [Display(Name = "Correos Electrónicos")]
        public string? OccCorreosElec { get; set; }

        [Display(Name = "Observaciones")]
        public string? OccObservaciones { get; set; }

        public bool OccMismaDireccion { get; set; }

        public string Estatus { get; set; }

        public virtual IList<OrdenCompraDetalleModel> OrdenCompraDetalleModels { get; set; }

        /// <summary>
        /// Pasar los datos de la vista al modelo
        /// </summary>
        /// <param name="model"></param>
        public void MapToModel(ref OrdenCompraModel model)
        {
            model.Id = Id;
            model.OccNroOrden = OccNroOrden;
            model.ProveedorId = ProveedorId;
            //model.OccFechaEmision = OccFechaEmision.ToString();

            if (OccFechaEmision != null)
                model.OccFechaEmision = DateTime.ParseExact(OccFechaEmision, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            if (OccFechaOrden!=null)
                model.OccFechaOrden = DateTime.ParseExact(OccFechaOrden, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            if (OccFechaVencimiento!=null)
                model.OccFechaVencimiento = DateTime.ParseExact(OccFechaVencimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

            model.OccGasto = OccGasto;
            model.OccIVA = OccIVA;
            model.OccDescuento = OccDescuento;
            model.OccEstatus = OccEstatus;
            model.OccDireccion = OccDireccion;
            model.OccTelefonos = OccTelefonos;
            model.OccCorreosElec = OccCorreosElec;
            model.OccMismaDireccion = OccMismaDireccion;
            model.OrdenCompraDetalleModels = OrdenCompraDetalleModels;
        }

        /// <summary>
        /// Cargar datos de la entidad al modelo view
        /// </summary>
        /// <param name="model"></param>
        public void MapToViewModel(ref OrdenCompraModel model)
        {
            Id = model.Id;
            OccNroOrden = model.OccNroOrden;
            ProveedorId = model.ProveedorId;
            //OccFechaEmision = model.OccFechaEmision == null ? DateTime.Today : (DateTime)model.OccFechaEmision;

            if (model.OccFechaEmision != null)
                OccFechaEmision = model.OccFechaEmision.Value.ToString("dd/MM/yyyy");
            if (model.OccFechaOrden != null)
                OccFechaOrden = model.OccFechaOrden.Value.ToString("dd/MM/yyyy");
            if (model.OccFechaVencimiento != null)
                OccFechaVencimiento = model.OccFechaVencimiento.Value.ToString("dd/MM/yyyy");

            OccGasto = model.OccGasto;
            OccIVA = model.OccIVA;
            OccDescuento = model.OccDescuento;
            OccEstatus = model.OccEstatus;
            OccDireccion = model.OccDireccion;
            OccTelefonos = model.OccTelefonos;
            OccCorreosElec = model.OccCorreosElec;
            OccMismaDireccion = model.OccMismaDireccion;

            OdcEstatusEnum occEstatus = (OdcEstatusEnum)model.OccEstatus;
            Estatus = occEstatus.ToString();

            OrdenCompraDetalleModels = model.OrdenCompraDetalleModels;
        }


    }



}
