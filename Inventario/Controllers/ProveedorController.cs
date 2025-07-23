using AutoMapper;
using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Inventario.Controllers
{
    [Authorize]
    public class ProveedorController : Controller
    {
        // Iniciar repositorios
        private readonly IProveedorService proveedorService;
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;

        private List<SelectListItem> lstEstatusProv;

        // Constructor
        public ProveedorController(IProveedorService proveedorService, IMapper mapper, ILibreriaService libreriaService)
        {
            this.proveedorService = proveedorService;
            this.mapper = mapper;
            this.libreriaService = libreriaService;
        }

        // Listado inicial
        public async Task<IActionResult> Index()
        {
            var entities = await proveedorService.GetAll();
            return View(entities);
        }

        #region Create
        // GET: Create
        public IActionResult Create()
        {

            LlenarListas();
            ProveedorViewModel data = new ProveedorViewModel();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProveedorViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new ProveedorModel();
                    viewModel.MapToModel(ref model);

                    // Sesion
                    ClaimsPrincipal claimuser = HttpContext.User;
                    var usuarioLog = libreriaService.UsuarioLog(claimuser);
                    model.IdUsuarioSesion = usuarioLog.IdUsuario;
                    model.UsuarioSesion = usuarioLog.Usuario;

                    var result = await proveedorService.Add(model);
                    if (result == "Ok")
                    {
                        TempData["mensaje"] = "El registro se ha creado correctamente.";
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
            Proveedor proveedor = await proveedorService.GetById(id);

            ProveedorViewModel viewModel = new ProveedorViewModel();
            viewModel.MapToViewModel(ref proveedor);
            
            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProveedorViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new ProveedorModel();
                    viewModel.MapToModel(ref model);

                    // Sesion
                    ClaimsPrincipal claimuser = HttpContext.User;
                    var usuarioLog = libreriaService.UsuarioLog(claimuser);
                    model.IdUsuarioSesion = usuarioLog.IdUsuario;
                    model.UsuarioSesion = usuarioLog.Usuario;

                    var result = await proveedorService.Edit(model);
                    if (result == "Ok")
                    {
                        TempData["mensaje"] = "El registro se ha actualizado correctamente.";
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

            Proveedor proveedor = await proveedorService.GetById(id);

            ProveedorViewModel viewModel = new ProveedorViewModel();
            viewModel.MapToViewModel(ref proveedor);

            
            return View(viewModel);
        }
        #endregion

        #region Delete
        // GET
        public async Task<IActionResult> Delete(int id)
        {
            LlenarListas();
            Proveedor proveedor = await proveedorService.GetById(id);
            ProveedorViewModel viewModel = new ProveedorViewModel();
            viewModel.MapToViewModel(ref proveedor);


            return View(viewModel);
        }

        // POST: Delete Alumnos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProveedorViewModel viewModel)
        {
            try
            {
                // Sesion
                ClaimsPrincipal claimuser = HttpContext.User;
                var usuarioLog = libreriaService.UsuarioLog(claimuser);

                int id = viewModel.Id;
                string estado = await proveedorService.Delete(id, usuarioLog);

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
  
            // Lista Estatus proveedor
            lstEstatusProv = libreriaService.EstatusProveedorList();
            lstEstatusProv[0].Selected = true;
            ViewBag.Estatus = lstEstatusProv;

        }

        /// <summary>
        /// Extraer usuario en sesión, para guardar log
        /// </summary>
        /// <returns>UsuarioSesionDTO</returns>
        //public UsuarioSesionDTO UsuarioLog()
        //{
        //    ClaimsPrincipal claimuser = HttpContext.User;
        //    UsuarioSesionDTO usuario = new UsuarioSesionDTO();
        //    if (claimuser.Identity.IsAuthenticated)
        //    {
        //        foreach (var claim in claimuser.Claims)
        //        {
        //            if (usuario.Usuario == null)
        //            {
        //                usuario.Usuario = claim.Value.ToString();
        //            }
        //            else if (usuario.Foto == null)
        //            {
        //                usuario.Foto = claim.Value.ToString();
        //            }
        //            else
        //            {
        //                usuario.IdUsuario = claim.Value.ToString();
        //            }
        //        }
        //    }
        //    return usuario;
        //}


        #endregion

    }
}

