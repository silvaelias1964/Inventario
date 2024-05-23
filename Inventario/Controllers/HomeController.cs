using CoreInventario.Application.DTOS;
using CoreInventario.Transversal.Logins;
using Inventario.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using CoreInventario.Transversal.Commons;

namespace Inventario.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPathConfiguration _pathConfiguration;

        public HomeController(ILogger<HomeController> logger, IPathConfiguration pathConfiguration)
        {
            _logger = logger;
            _pathConfiguration = pathConfiguration;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            string nombreUsuario = "";
            string foto = "";
            string id = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                //nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                //    .Select(c => c.Value).SingleOrDefault();
                //foto = claimuser.Claims.Where(c => c.Type != ClaimTypes.Uri)
                //    .Select(c => c.Value).SingleOrDefault();
                foreach (var claim in claimuser.Claims)
                {
                    if (nombreUsuario == "")
                    {
                           nombreUsuario = claim.Value.ToString();
                    }
                    else if (foto == "")
                    {
                        foto = claim.Value.ToString();
                    }
                    else
                    {
                        id = claim.Value.ToString();
                    }
                }


            }
            //var sesion = _sesionService.SetSesion(0, nombreUsuario);

            ViewData["nombreUsuario"] = nombreUsuario;
            if (foto == "")
            {
                ViewData["foto"] = "/"+_pathConfiguration.PathAvatar + "/" + "defaultUser.png";
            }
            else
            {
                ViewData["foto"] = "/"+_pathConfiguration.PathAvatar + "/" + foto;
            }
            

            //var sesionget = _sesionService.GetSesion();


            //var datos = new
            //{
            //    IdUsuario = id,
            //    NombreUsuario =nombreUsuario,
            //    foto=foto,

            //};

            // Guarda sesion
            List<UsuarioSesionDTO> lista = new List<UsuarioSesionDTO>();
            lista.Add(new UsuarioSesionDTO
            {
                IdUsuario = id,
                Usuario = nombreUsuario,
                Foto = "/"+_pathConfiguration.PathAvatar + "/" + foto
            });

            HttpContext.Session.SetObject("dataUserSession", lista);


            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }

    }
}