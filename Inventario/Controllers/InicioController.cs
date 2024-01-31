using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Domain.Entities;

namespace Inventario.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        //private readonly ILibreriaService _libreriaService;

        public InicioController(IUsuarioService usuarioServicio) //, ILibreriaService libreriaService
        {
            _usuarioServicio = usuarioServicio;
            //_libreriaService = libreriaService;

        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Clave = EncriptarClave(modelo.Clave);

            Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (usuario_creado.Id > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuario_encontrado = new Usuario();

            usuario_encontrado = await _usuarioServicio.GetUsuario(correo, EncriptarClave(clave));


            if (usuario_encontrado.Id == 0 || usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado..";
                return View();
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario),
                new Claim(ClaimTypes.Uri, usuario_encontrado.Foto),
                new Claim(ClaimTypes.Actor, usuario_encontrado.Id.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }

        private string EncriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(clave));
                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
