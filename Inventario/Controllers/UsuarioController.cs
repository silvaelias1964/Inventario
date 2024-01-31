using CoreInventario.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var entities = await usuarioService.GetAll();
            return View(entities);
        }
    }
}
