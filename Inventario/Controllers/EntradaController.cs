using AutoMapper;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Repositories;
using CoreInventario.Migrations;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using Entrada = CoreInventario.Domain.Entities.Entrada;

namespace Inventario.Controllers
{
    [Authorize]
    public class EntradaController : Controller
    {
        // Iniciar repositorios
        private readonly IEntradaService entradaService;        
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;
        private readonly IProductoService productoService;


        private List<SelectListItem> lstProductos;

        // Constructor
        public EntradaController(
            IEntradaService entradaService, 
            IMapper mapper, 
            ILibreriaService libreriaService,
            IProductoService productoService)
        {
            this.entradaService = entradaService;
            this.mapper = mapper;
            this.libreriaService = libreriaService;
            this.productoService = productoService;
        }

        // Listado inicial
        public async Task<IActionResult> Index()
        {
            var entities = await entradaService.GetAll();
            return View(entities);
        }

        #region Create
        // GET: Create
        public IActionResult Create()
        {
            LlenarListas();
            EntradaViewModel data = new EntradaViewModel();
            data.ActualizaInv = true;   // Por default actualiza inventario
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntradaViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new EntradaModel();
                    viewModel.MapToModel(ref model);
                    var result = await entradaService.Add(model);                    
                    if (result.MsgProc == "Ok-Ok")
                    {
                        TempData["mensaje"] = "El registro se ha creado correctamente";
                        return RedirectToAction(nameof(Index));
                    }
                    else if(result.MsgProc == "Ok-No") 
                    {
                        //ModelState.AddModelError(string.Empty, "Error: No se actualizó el inventario..(intente en opción Editar)");
                        //LlenarListas();
                        //return View(viewModel);
                        TempData["mensaje"] = "El registro se ha creado correctamente, pero no se actualizó el inventario.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.MsgProc);
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
            Entrada entrada = await entradaService.GetById(id);            
            EntradaViewModel viewModel = new EntradaViewModel();
            viewModel.MapToViewModel(ref entrada);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EntradaViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new EntradaModel();
                    viewModel.MapToModel(ref model);
                    var result = await entradaService.Edit(model);
                    if (result == "Ok-Ok")
                    {
                        TempData["mensaje"] = "El registro se ha actualizado correctamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    else if (result == "Ok-No")
                    {
                        //ModelState.AddModelError(string.Empty, "Error: No se actualizó el inventario..");
                        //LlenarListas();
                        //return View(viewModel);
                        TempData["mensaje"] = "El registro se ha actualizado correctamente, pero no se actualizó el inventario.";
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

        #region Ver
        public async Task<IActionResult> Details(int id)
        {
            LlenarListas();
            Entrada entrada = await entradaService.GetById(id);
            EntradaViewModel viewModel = new EntradaViewModel();
            viewModel.MapToViewModel(ref entrada);
            return View(viewModel);
        }
        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            LlenarListas();
            Entrada entrada = await entradaService.GetById(id);
            EntradaViewModel viewModel = new EntradaViewModel();
            viewModel.MapToViewModel(ref entrada);
            return View(viewModel);
        }

        // POST: Delete Alumnos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EntradaViewModel viewModel)
        {
            try
            {
                int id = viewModel.Id;
                string estado = await entradaService.Delete(id);

                if (estado == "Ok")
                {
                    TempData["mensaje"] = "El registro se ha borrado correctamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error en el borrado de datos: " + estado);
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


        #region Others

        /// <summary>
        /// Llenar listas de combos
        /// </summary>
        public void LlenarListas()
        {
            // Lista categoria de productos
            lstProductos = productoService.ProductosList();
            lstProductos[0].Selected = true;
            ViewBag.Productos = lstProductos;
        }


        #endregion

    }

}
