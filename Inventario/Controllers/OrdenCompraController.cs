using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Inventario.Controllers.ProductoController;

namespace Inventario.Controllers
{
    public class OrdenCompraController : Controller
    {
        // Repositorios
        private readonly IOrdenCompraService ordenCompraService;
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;
        private readonly IProveedorService proveedorService;

        private List<SelectListItem> lstEstatusOcc;
        private List<SelectListItem> lstProveedores;

        // Constructor
        public OrdenCompraController(IOrdenCompraService ordenCompraService, IMapper mapper, ILibreriaService libreriaService, IProveedorService proveedorService)
        {
            this.ordenCompraService = ordenCompraService;
            this.mapper = mapper;
            this.libreriaService = libreriaService;                
            this.proveedorService = proveedorService;
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

            // Lista proveedores
            lstProveedores = libreriaService.ProveedorList();
            lstProveedores[0].Selected = true;
            ViewBag.Proveedores = lstProveedores;
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



        #endregion


    }
}
