using AutoMapper;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Controllers
{
    
    [Authorize]
    public class ConfiguracionController : Controller
    {
        private readonly IConfiguracionService configuracionService;
        private readonly ILibreriaService libreriaService;

        private List<SelectListItem> lstMoneda;

        public ConfiguracionController(IConfiguracionService configuracionService, ILibreriaService libreriaService)
        {
            this.configuracionService = configuracionService;
            this.libreriaService = libreriaService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new ConfiguracionViewModel();
            
            var model = configuracionService.GetAll();

            LlenarListas();

            if (model != null)
                viewModel.MapToViewModel(model);


            return View(viewModel);
        }

        
        [HttpPost]
        public IActionResult Index(ConfiguracionViewModel viewModel) 
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Mapping
                    var model = new ConfiguracionModel();
                    viewModel.MapToModel(ref model);
                    var result = configuracionService.Edit(model);
                    if (result == "Ok")
                    {
                        TempData["mensaje"] = "El registro se ha actualizado correctamente";
                        //return RedirectToAction(nameof(Index));
                        return Redirect("~/Configuracion/Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result);
                        LlenarListas();
                        //return View(viewModel);
                        return BadRequest(ModelState);
                    }
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error en los datos, revise..");

                    LlenarListas();

                    return View(viewModel);
                    //return BadRequest(ModelState);

                }
            }
            catch (Exception ex)
            {
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                LlenarListas();

                //return View(viewModel);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult IEdit() //ConfiguracionViewModel viewModel
        {
            try
            {
                return Redirect("~/Configuracion/Index");
            }
            catch (Exception ex)
            {

                return Redirect("~/Configuracion/Index");
            }
        }


        //[HttpPost]
        //public IActionResult Edit(ConfiguracionViewModel viewModel) 
        //{
        //    try
        //    {
        //        return Redirect("~/Configuracion/Index");
        //    }
        //    catch (Exception ex)
        //    {

        //        return Redirect("~/Configuracion/Index");
        //    }
        //}

        #region Others

        /// <summary>
        /// Llenar listas de combos
        /// </summary>
        public void LlenarListas()
        {
            // Lista categoria de productos
            lstMoneda = libreriaService.MonedaDefList();
            lstMoneda[0].Selected = true;
            ViewBag.MonedaDefecto = lstMoneda;
        }


        #endregion


    }
}
