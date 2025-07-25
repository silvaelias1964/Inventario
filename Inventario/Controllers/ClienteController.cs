﻿using AutoMapper;
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
    public class ClienteController : Controller
    {
        // Iniciar repositorios
        private readonly IClienteService clienteService;
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;

        private List<SelectListItem> lstEstatusClie;
        private List<SelectListItem> lstTipoClie;

        // Constructor
        public ClienteController(IClienteService clienteService, IMapper mapper, ILibreriaService libreriaService)
        {
            this.clienteService = clienteService;
            this.mapper = mapper;
            this.libreriaService = libreriaService;
        }

        // Listado inicial
        public async Task<IActionResult> Index()
        {
            var entities = await clienteService.GetAll();            
            return View(entities);
        }

        #region Create
        // GET: Create
        public IActionResult Create()
        {

            LlenarListas();
            ClienteViewModel data = new ClienteViewModel();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Sesion
                    var usuarioLog = UsuarioLog();
                    viewModel.IdUsuarioSesion = usuarioLog.IdUsuario;
                    viewModel.UsuarioSesion = usuarioLog.Usuario;

                    // Mapping
                    var model = new ClienteModel();
                    viewModel.MapToModel(ref model);
                    var result = await clienteService.Add(model);
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
            Cliente cliente = await clienteService.GetById(id);
            ClienteViewModel viewModel = new ClienteViewModel();
            viewModel.MapToViewModel(ref cliente);
            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Sesion
                    var usuarioLog = UsuarioLog();
                    viewModel.IdUsuarioSesion = usuarioLog.IdUsuario;
                    viewModel.UsuarioSesion = usuarioLog.Usuario;

                    // Mapping
                    var model = new ClienteModel();
                    viewModel.MapToModel(ref model);
                    var result = await clienteService.Edit(model);
                    if(result == "Ok")
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

        #region Ver
        public async Task<IActionResult> Details(int id)
        {
            LlenarListas();

            Cliente cliente = await clienteService.GetById(id);

            ClienteViewModel viewModel = new ClienteViewModel();
            viewModel.MapToViewModel(ref cliente);


            return View(viewModel);
        }
        #endregion

        #region Delete
        // GET
        public async Task<IActionResult> Delete(int id)
        {
            LlenarListas();
            Cliente cliente = await clienteService.GetById(id);
            ClienteViewModel viewModel = new ClienteViewModel();
            viewModel.MapToViewModel(ref cliente);

            return View(viewModel);
        }

        // POST: Delete Alumnos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClienteViewModel viewModel)
        {
            try
            {
                // Sesion
                var usuarioLog = UsuarioLog();
                viewModel.IdUsuarioSesion = usuarioLog.IdUsuario;
                viewModel.UsuarioSesion = usuarioLog.Usuario;

                int id = viewModel.Id;
                string estado = await clienteService.Delete(id, usuarioLog);

                if (estado == "Ok")
                {
                    TempData["mensaje"] = "El registro se ha borrado correctamente";
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
            // Lista Estatus cliente
            lstEstatusClie = libreriaService.EstatusClienteList();
            lstEstatusClie[0].Selected = true;
            ViewBag.Estatus = lstEstatusClie;

            // Lista tipo cliente
            lstTipoClie = libreriaService.TipoClienteList();
            lstTipoClie[0].Selected = true;
            ViewBag.TipoCliente = lstTipoClie;
        }

        /// <summary>
        /// Extraer usuario en sesión, para guardar log
        /// </summary>
        /// <returns>UsuarioSesionDTO</returns>
        public UsuarioSesionDTO UsuarioLog()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            UsuarioSesionDTO usuario = new UsuarioSesionDTO();
            if (claimuser.Identity.IsAuthenticated)
            {
                foreach (var claim in claimuser.Claims)
                {
                    if (usuario.Usuario == null)
                    {                        
                        usuario.Usuario = claim.Value.ToString();
                    }
                    else if (usuario.Foto == null)
                    {                     
                        usuario.Foto = claim.Value.ToString();
                    }
                    else
                    {
                        usuario.IdUsuario = claim.Value.ToString();
                    }
                }
            }
            return usuario;
        }

        #endregion

    }
}

