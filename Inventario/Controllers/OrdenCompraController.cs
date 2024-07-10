using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static Inventario.Controllers.ProductoController;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inventario.Controllers
{
    [Authorize]
    public class OrdenCompraController : Controller
    {
        // Repositorios
        private readonly IOrdenCompraService ordenCompraService;
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;
        private readonly IProveedorService proveedorService;
        private readonly IProductoService productoService;

        private List<SelectListItem> lstEstatusOcc;
        private List<SelectListItem> lstProductos;
        private List<SelectListItem> lstUnidadesMedida;

        // Constructor
        public OrdenCompraController(
            IOrdenCompraService ordenCompraService, 
            IMapper mapper, 
            ILibreriaService libreriaService, 
            IProveedorService proveedorService,
            IProductoService productoService)
        {
            this.ordenCompraService = ordenCompraService;
            this.mapper = mapper;
            this.libreriaService = libreriaService;                
            this.proveedorService = proveedorService;
            this.productoService = productoService;
        }

        // Listado inicial
        public async Task<IActionResult> Index()
        {
            var entities = await ordenCompraService.GetAll();
            return View(entities);
        }

        #region Create
        // GET: Create
        public IActionResult Create()
        {

            LlenarListas();
            OrdenCompraViewModel data = new OrdenCompraViewModel();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdenCompraViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new OrdenCompraModel();
                    viewModel.MapToModel(ref model);
                    var result = await ordenCompraService.Add(model);
                    if (result == "Ok")
                    {
                        TempData["mensaje"] = "El registro se ha creado correctamente";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result);
                        LlenarListas();
                        return View(viewModel);
                    }

                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error en los datos, revise..");
                    LlenarListas();
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                LlenarListas();
                return View(viewModel);
            }
        }
        #endregion

        #region Edit_Update
        public async Task<IActionResult> Edit(int id)
        {
            LlenarListas();
            OrdenCompraModel ordencompra = await ordenCompraService.GetById(id);

            OrdenCompraViewModel viewModel = new OrdenCompraViewModel();
            viewModel.MapToViewModel(ref ordencompra);

            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrdenCompraViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Mapping
                    var model = new OrdenCompraModel();
                    viewModel.MapToModel(ref model);
                    var result = await ordenCompraService.Edit(model);
                    if (result == "Ok")
                    {
                        TempData["mensaje"] = "El registro se ha actualizado correctamente";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result);
                        LlenarListas();
                        return View(viewModel);
                    }
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error en los datos, revise..");

                    LlenarListas();

                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                LlenarListas();

                return View(viewModel);
            }
        }
        #endregion

        //#region Ver
        //public async Task<IActionResult> Details(int id)
        //{
        //    LlenarListas();

        //    Cliente cliente = await clienteService.GetById(id);

        //    ClienteViewModel viewModel = new ClienteViewModel();
        //    viewModel.MapToViewModel(ref cliente);


        //    return View(viewModel);
        //}
        //#endregion

        //#region Delete
        //// GET
        //public async Task<IActionResult> Delete(int id)
        //{
        //    LlenarListas();
        //    Cliente cliente = await clienteService.GetById(id);
        //    ClienteViewModel viewModel = new ClienteViewModel();
        //    viewModel.MapToViewModel(ref cliente);

        //    return View(viewModel);
        //}

        //// POST: Delete Alumnos
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(ClienteViewModel viewModel)
        //{
        //    try
        //    {
        //        int id = viewModel.Id;
        //        string estado = await clienteService.Delete(id);

        //        if (estado == "Ok")
        //        {
        //            TempData["mensaje"] = "El registro se ha borrado correctamente";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Error en el borrado de datos: " + estado);
        //            LlenarListas();
        //            return View(viewModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        foreach (var error in ex.Message.Split("*"))
        //        {
        //            ModelState.AddModelError(string.Empty, ex.Message);
        //        }
        //        LlenarListas();
        //        return View(viewModel);
        //    }
        //}


        //#endregion


        #region Others

        /// <summary>
        /// Llenar listas de combos
        /// </summary>
        public void LlenarListas()
        {
            // Lista Estatus orden de compra
            lstEstatusOcc = libreriaService.EstatusOdcList();
            lstEstatusOcc[0].Selected = true;
            ViewBag.Estatus = lstEstatusOcc;

            // Lista productos
            lstProductos = libreriaService.ProductosList();
            lstProductos[0].Selected = true;
            ViewBag.Productos = lstProductos;

            // Lista unidades de medida
            lstUnidadesMedida = libreriaService.UnidadMedidaList();
            lstUnidadesMedida[0].Selected = true;
            ViewBag.UnidadesMedida = lstUnidadesMedida;

            ViewBag.IVA = libreriaService.ValParametros("IVA");

        }

        /// <summary>
        /// Llenado de grid de consulta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult _Proveedores() 
        {
            List<ProveedorModel> lista = (List<ProveedorModel>)proveedorService.GetAllByStatus();            
            return PartialView("_Proveedores",lista);
        }

        /// <summary>
        /// Buscar proveedor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BuscaProveedor(int Id)
        {
            //new List<ProveedorModel>();
            //var list = new List<ProveedorModel>();

            Proveedor proveedor = proveedorService.GetByIdNoAsync(Id);
            
            // Llenar modelo
            //foreach (var Item in lista)
            //{

            //    list.Add(new ProveedorModel()
            //    {
            //        //Id = Item.
            //        //name = Item.Text,
            //        //id = Item.Value.ToString()
            //    });
            //}
            
            return Json(proveedor);

        }

        /// <summary>
        /// Buscar un producto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BuscaProducto(int Id) 
        {
            Producto producto= await productoService.GetById(Id);            
            string codigo="";
            string nombre="";
            string cantPorUnidad = "";
            decimal precioUnidad=0;
            int stockMinimo=0;
            int stock = 0;
            
            if (producto != null)
            {                
                codigo = producto.PrdCodigo;
                nombre = producto.PrdNombre;
                cantPorUnidad = producto.PrdCantPorUnidad;
                precioUnidad = producto.PrdPrecioUnidad;
                stockMinimo = producto.PrdStockMinimo;
                stock = producto.PrdStock;
            }
            var response = new
            {
                jcodigo = codigo,
                jnombre = nombre,
                jcantPorUnidad = cantPorUnidad,
                jprecioUnidad = precioUnidad.ToString(),
                jstockMinimo = stockMinimo.ToString(),
                jstock = stock.ToString()
            };
            return Json(response);

        
        }

        [HttpPost]
        public IActionResult BuscaProductoNA(int Id) 
        {
            var response = new
            {
                jcodigo = "1",
                jnombre = "2",
                jcantPorUnidad = "3",
                jprecioUnidad = "4",
                jstockMinimo = "5",
                jstock = "6"
            };
            return Json(response);

        }



        #endregion


    }
}
