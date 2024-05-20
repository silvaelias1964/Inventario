using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Helpers;
using CoreInventario.Transversal.Commons;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace Inventario.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public readonly IUsuarioService usuarioService;
        public readonly ILibreriaService libreriaService;
        public UploadFile uploadFile;
        public DeleteFile deleteFile;
        public PathProvider pathProvider;

        private List<SelectListItem> lstEstatus;
        private List<SelectListItem> lstRoles;

        public UsuarioController(
            IUsuarioService usuarioService, 
            ILibreriaService libreriaService, 
            UploadFile uploadFile,
            DeleteFile deleteFile, 
            PathProvider pathProvider)
        {
            this.usuarioService = usuarioService;
            this.libreriaService = libreriaService;
            this.uploadFile = uploadFile;
            this.deleteFile = deleteFile;
            this.pathProvider = pathProvider;
        }

        public async Task<IActionResult> Index()
        {
            var entities = await usuarioService.GetAll();
            return View(entities);
        }

        #region Create
        // GET: Create
        public IActionResult Create()
        {
            LlenarListas();
            UsuarioViewModel data = new UsuarioViewModel();            
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new UsuarioModel();
                    viewModel.MapToModel(ref model);
                    var result = await usuarioService.Add(model);
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
            UsuarioViewModel viewModel = new UsuarioViewModel();
            if (id > 0)
            {
                Usuario usuario = await usuarioService.GetById(id);                
                viewModel.MapToViewModel(ref usuario);
            }
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    // Mapping
                    var model = new UsuarioModel();
                    viewModel.MapToModel(ref model);
                    var result = await usuarioService.Edit(model);
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

        //#region Ver
        //public async Task<IActionResult> Details(int id)
        //{
        //    LlenarListas();
        //    Entrada entrada = await entradaService.GetById(id);
        //    EntradaViewModel viewModel = new EntradaViewModel();
        //    viewModel.MapToViewModel(ref entrada);
        //    return View(viewModel);
        //}
        //#endregion

        //#region Delete

        //public async Task<IActionResult> Delete(int id)
        //{
        //    LlenarListas();
        //    Entrada entrada = await entradaService.GetById(id);
        //    EntradaViewModel viewModel = new EntradaViewModel();
        //    viewModel.MapToViewModel(ref entrada);
        //    return View(viewModel);
        //}

        //// POST: Delete Alumnos
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(EntradaViewModel viewModel)
        //{
        //    try
        //    {
        //        int id = viewModel.Id;
        //        string estado = await entradaService.Delete(id);

        //        if (estado == "Ok")
        //        {
        //            TempData["mensaje"] = "El registro se ha borrado correctamente.";
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
            // Lista Estatus usuario
            lstEstatus = libreriaService.EstatusUsuarioList();
            lstEstatus[0].Selected = true;
            ViewBag.Estatus = lstEstatus;

            // Lista Roles
            lstRoles = libreriaService.RolesList();
            lstRoles[0].Selected = true;
            ViewBag.Roles = lstRoles;


        }

        [HttpPost]
        public IActionResult ChangePassword([FromBody] CambiarClaveViewModel cambiarClaveViewModel)
        {
            if (ModelState.IsValid)
            {
                int userId;
                userId = Convert.ToInt32(cambiarClaveViewModel.UserId);
                var result = usuarioService.CheckPass(userId, libreriaService.EncriptarClave(cambiarClaveViewModel.CurrentPassword), cambiarClaveViewModel.NewPassword);
                if (result.Id==0)
                {
                    return Json(new
                    {
                        data = result
                    });
                }
                else
                {
                    return Json(new
                    {
                        data = result
                    });
                }
            }
            else
            {
                return BadRequest();
            }
        }


        //[HttpPost]
        //public IActionResult ChangeImg(string name)
        //{

        //    var ruta = pathProvider.MapPath(name,"avatar" );  //pathConfiguration.PathAvatar

        //    using (var stream = new FileStream(ruta, FileMode.Create))
        //    {
        //        await imagen.CopyToAsync(stream);
        //    }



        //    var result = usuarioService.CopyImgTemp(name);
        //}

        #endregion


    }
}
