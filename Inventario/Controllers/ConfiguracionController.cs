using AutoMapper;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
