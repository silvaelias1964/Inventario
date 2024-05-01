using AutoMapper;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;


namespace Inventario.Controllers
{
    public class EntradaController : Controller
    {
        // Iniciar repositorios
        private readonly IEntradaService entradaService;        
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;
        private readonly IProductoService productoService;

        private List<SelectListItem> lstProductos;

        // Constructor
        public EntradaController(IEntradaService entradaService, IMapper mapper, ILibreriaService libreriaService, IProductoService productoService)
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
                    if (result == "Ok")
                    {
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
        //public async Task<IActionResult> Edit(int id)
        //{
        //    LlenarListas();
        //    Producto producto = await productoService.GetById(id);

        //    ProductoViewModel viewModel = new ProductoViewModel();
        //    viewModel.MapToViewModel(ref producto);


        //    //var file = viewModel.File1;

        //    //var fileBytes = System.IO.File.ReadAllBytes(@"C:\Proyectos\Inventario\Inventario\wwwroot\FotosProductos\" + viewModel.PrdFoto1);
        //    //string s = Convert.ToBase64String(fileBytes);
        //    //file = s;

        //    //var stream = new FileStream(@"C:\Proyectos\Inventario\Inventario\wwwroot\FotosProductos\" + viewModel.PrdFoto1, FileMode.Open);

        //    //using (var stream = new FileStream(@"C:\Proyectos\Inventario\Inventario\wwwroot\FotosProductos\" + viewModel.PrdFoto1, FileMode.Open))
        //    //{
        //    //    file.CopyTo(stream);
        //    //}

        //    //using (var fileStream = new FileStream(Path.Combine(@"C:\Proyectos\Inventario\Inventario\wwwroot\FotosProductos\", viewModel.PrdFoto1), FileMode.Open))
        //    //    {
        //    //        await viewModel.File1.CopyToAsync(fileStream);
        //    //    }




        //    // Buscar Ciudad en el combo
        //    //BuscarCiudadId(viewModel.EstadoId, viewModel.CiudadId);
        //    // Buscar Municipios en el combo
        //    //BuscarMunicipioId(viewModel.CiudadId, viewModel.MunicipioId);

        //    return View(viewModel);

        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(ProductoViewModel viewModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            // Mapping
        //            var model = new ProductoModel();
        //            viewModel.MapToModel(ref model);
        //            var result = await productoService.Edit(model);
        //            if (result == "Ok")
        //            {
        //                return RedirectToAction(nameof(Index));
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, result);
        //                LlenarListas();
        //                return View(viewModel);
        //            }
        //        }
        //        else
        //        {

        //            ModelState.AddModelError(string.Empty, "Error en los datos, revise..");

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
        #endregion

        #region Ver
        //public async Task<IActionResult> Details(int id)
        //{
        //    LlenarListas();

        //    Producto producto = await productoService.GetById(id);

        //    ProductoViewModel viewModel = new ProductoViewModel();
        //    viewModel.MapToViewModel(ref producto);

        //    //var viewModel = new SociosViewModel()
        //    //{
        //    //    Id = socios.Id,
        //    //    Cedula = socios.Cedula,
        //    //    Nombre = socios.Nombre,
        //    //    Apellido = socios.Apellido,
        //    //    Direccion = socios.Direccion,
        //    //    EmailPrincipal = socios.EmailPrincipal,
        //    //    EmailSecundario = socios.EmailSecundario,
        //    //    TelefonoMovil = socios.TelefonoMovil,
        //    //    TelefonoFax = socios.TelefonoFax,
        //    //    TelefonoOficina = socios.TelefonoOficina,
        //    //    TelefonoPrivado = socios.TelefonoPrivado,
        //    //    EstatusId = socios.EstatusId.GetValueOrDefault(),
        //    //    EstadoId = socios.EstadoId.GetValueOrDefault(),
        //    //    CiudadId = socios.CiudadId.GetValueOrDefault(),
        //    //    MunicipioId = socios.MunicipioId.GetValueOrDefault(),
        //    //    CargoId = socios.CargoId.GetValueOrDefault(),
        //    //    CodigoPostal = socios.CodigoPostal,
        //    //    FechaNacimiento = socios.FechaNacimiento.GetValueOrDefault(),
        //    //    Sexo = socios.Sexo == 1 ? "M" : "F",  // .ToString(),
        //    //    RolId = (int)socios.RolId,
        //    //    UserName = socios.UserName
        //    //};
        //    // Buscar Ciudad en el combo
        //    //BuscarCiudadId(viewModel.EstadoId, viewModel.CiudadId);
        //    // Buscar Municipios en el combo
        //    //BuscarMunicipioId(viewModel.CiudadId, viewModel.MunicipioId);

        //    return View(viewModel);
        //}
        #endregion

        #region Delete
        // GET
        //public async Task<IActionResult> Delete(int id)
        //{
        //    LlenarListas();
        //    Producto producto = await productoService.GetById(id);
        //    ProductoViewModel viewModel = new ProductoViewModel();
        //    viewModel.MapToViewModel(ref producto);

        //    //Socios socios = await sociosService.GetById(id);
        //    //var viewModel = new SociosViewModel()
        //    //{
        //    //    Id = socios.Id,
        //    //    Cedula = socios.Cedula,
        //    //    Nombre = socios.Nombre,
        //    //    Apellido = socios.Apellido,
        //    //    Direccion = socios.Direccion,
        //    //    EmailPrincipal = socios.EmailPrincipal,
        //    //    EmailSecundario = socios.EmailSecundario,
        //    //    TelefonoMovil = socios.TelefonoMovil,
        //    //    TelefonoFax = socios.TelefonoFax,
        //    //    TelefonoOficina = socios.TelefonoOficina,
        //    //    TelefonoPrivado = socios.TelefonoPrivado,
        //    //    EstatusId = socios.EstatusId.GetValueOrDefault(),
        //    //    EstadoId = socios.EstadoId.GetValueOrDefault(),
        //    //    CiudadId = socios.CiudadId.GetValueOrDefault(),
        //    //    MunicipioId = socios.MunicipioId.GetValueOrDefault(),
        //    //    CargoId = socios.CargoId.GetValueOrDefault(),
        //    //    CodigoPostal = socios.CodigoPostal,
        //    //    FechaNacimiento = socios.FechaNacimiento.GetValueOrDefault(),
        //    //    Sexo = socios.Sexo == 1 ? "M" : "F",  // .ToString(),
        //    //    RolId = (int)socios.RolId,
        //    //    UserName = socios.UserName
        //    //};
        //    //// Buscar Ciudad en el combo
        //    //BuscarCiudadId(viewModel.EstadoId, viewModel.CiudadId);
        //    //// Buscar Municipios en el combo
        //    //BuscarMunicipioId(viewModel.CiudadId, viewModel.MunicipioId);

        //    return View(viewModel);
        //}

        // POST: Delete Alumnos
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(ProductoViewModel viewModel)
        //{
        //    try
        //    {
        //        int id = viewModel.Id;
        //        string estado = await entradaService.Delete(id);

        //        if (estado == "Ok")
        //        {
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

        // Llenar combo
        [HttpPost]
        public IActionResult LlenarCiudad(int estadoid)
        {
            new List<SelectModel>();
            var list = new List<SelectModel>();

            //var model = libreriaService.CiudadesList(estadoid);
            ////var model = libreriaService.CiudadesList();
            //// Llenar modelo
            //foreach (var Item in model)
            //{
            //    list.Add(new SelectModel()
            //    {
            //        name = Item.Text,
            //        id = Item.Value.ToString()
            //    });
            //}

            return Json(list);

        }



        // Este modelo es necesario para devolver la lista correctamente formateada
        public class SelectModel
        {
            public string id { get; set; }
            public string name { get; set; }
        }


        // Buscar Ciudad en el combo
        public void BuscarCiudadId(int estadoId, int ciudadId)
        {
            //lstCiudades = libreriaService.CiudadesList(estadoId);
            //foreach (var item in lstCiudades)
            //{
            //    if (item.Value == ciudadId.ToString())
            //    {
            //        item.Selected = true;
            //        break;
            //    }
            //}
            //ViewBag.Ciudad = lstCiudades;
        }




        #endregion

    }

}
