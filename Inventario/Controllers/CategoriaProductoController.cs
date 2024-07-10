using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    public class CategoriaProductoController : Controller
    {
        // Inicializar el repositorio, Inicio
        private readonly ICategoriaProductoRepository categoriaProductoRepository;

        public CategoriaProductoController(ICategoriaProductoRepository categoriaProductoRepository)
        {
            this.categoriaProductoRepository = categoriaProductoRepository;
        }
        // Inicializar el repositorio, Fin

        /// <summary>
        /// Listado de Categorias repositorio
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var data = await categoriaProductoRepository.GetAll();
            return View(data);
        }


        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoriaProducto categoriaProducto)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    await categoriaProductoRepository.Add(categoriaProducto);

                    // El TempData despliega mensaje en el index 
                    TempData["mensaje"] = "El registro se ha creado correctamente";
                    var response = new { success = true };
                    return Json(response);
                }
                else
                {
                    var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    var msg = "";
                    foreach (var item in allErrors)
                    {
                        msg += item.ErrorMessage + " - ";
                    }
                    TempData["mensaje"] = msg;
                    var response = new { success = false };
                    return Json(response);

                }
            }
            catch (Exception ex)
            {
                var msg = "";
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    msg += ex.Message + " - ";
                }
                TempData["mensaje"] = "Error en la creación. " + msg;

                var response = new { success = false };
                return Json(response);
            }
        }

        // Post Edit
        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaProducto categoriaProducto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await categoriaProductoRepository.Update(categoriaProducto);

                    // El TempData despliega mensaje en el index 
                    TempData["mensaje"] = "El registro se ha editado correctamente";
                    var response = new { success = true };
                    return Json(response);

                }
                else
                {

                    var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    var msg = "";
                    foreach (var item in allErrors)
                    {
                        msg += item.ErrorMessage + " - ";
                    }
                    TempData["mensaje"] = msg;
                    var response = new { success = false };
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                var msg = "";
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    msg += ex.Message + " - ";
                }
                TempData["mensaje"] = "Error en la edición. " + msg;

                var response = new { success = false };
                return Json(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoriaProducto categoriaProducto)
        {
            try
            {
                await categoriaProductoRepository.Remove(categoriaProducto);

                // El TempData despliega mensaje en el index 
                TempData["mensaje"] = "El registro se ha eliminado correctamente";
                var response = new { success = true };
                return Json(response);

            }
            catch (Exception ex)
            {
                var msg = "";
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    msg += ex.Message + " - ";
                }
                TempData["mensaje"] = "Error en la eliminación. " + msg;

                var response = new { success = false };
                return Json(response);
            }
        }

    }

}
