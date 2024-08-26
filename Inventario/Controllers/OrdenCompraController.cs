using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Interfaces.Services;
using CoreInventario.Application.Models;
using CoreInventario.Application.Services;
using CoreInventario.Domain.Entities;
using Inventario.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static Inventario.Controllers.ProductoController;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Resources;
using CoreInventario.Transversal.Commons;
using static System.Net.Mime.MediaTypeNames;

//using QuestPDF.Fluent;
//using QuestPDF.Helpers;
//using QuestPDF.Infrastructure;
//using QuestPDF.Previewer;

namespace Inventario.Controllers
{
    [Authorize]
    public class OrdenCompraController : Controller
    {
        // Repositorios
        private readonly IOrdenCompraService ordenCompraService;
        private readonly IMapper mapper;
        private readonly ILibreriaService libreriaService;
        private readonly IProveedorService proveedorService;
        private readonly IProductoService productoService;
        private readonly IPathConfiguration pathConfiguration;

        private List<SelectListItem> lstEstatusOcc;
        private List<SelectListItem> lstProductos;
        private List<SelectListItem> lstUnidadesMedida;

        // Constructor
        public OrdenCompraController(
            IOrdenCompraService ordenCompraService, 
            IMapper mapper, 
            ILibreriaService libreriaService, 
            IProveedorService proveedorService,
            IProductoService productoService,
            IPathConfiguration pathConfiguration)
        {
            this.ordenCompraService = ordenCompraService;
            this.mapper = mapper;
            this.libreriaService = libreriaService;                
            this.proveedorService = proveedorService;
            this.productoService = productoService;
            this.pathConfiguration = pathConfiguration;
        }

        // Listado inicial
        public async Task<IActionResult> Index()
        {
            var entities = await ordenCompraService.GetAll();
            return View(entities);
        }

        #region Create
        // GET: Create
        public IActionResult Create()
        {

            LlenarListas();
            OrdenCompraViewModel data = new OrdenCompraViewModel();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdenCompraViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Mapping
                    var model = new OrdenCompraModel();
                    viewModel.MapToModel(ref model);
                    var result = await ordenCompraService.Add(model);
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
            OrdenCompraModel ordencompra = await ordenCompraService.GetById(id);

            OrdenCompraViewModel viewModel = new OrdenCompraViewModel();
            viewModel.MapToViewModel(ref ordencompra);

            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrdenCompraViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Mapping
                    var model = new OrdenCompraModel();
                    viewModel.MapToModel(ref model);
                    var result = await ordenCompraService.Edit(model);
                    if (result == "Ok")
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
            OrdenCompraModel ordencompra = await ordenCompraService.GetById(id);

            OrdenCompraViewModel viewModel = new OrdenCompraViewModel();
            viewModel.MapToViewModel(ref ordencompra);

            return View(viewModel);
        }
        #endregion

        #region Delete
        // GET
        public async Task<IActionResult> Delete(int id)
        {
            LlenarListas();
            OrdenCompraModel ordencompra = await ordenCompraService.GetById(id);
            OrdenCompraViewModel viewModel = new OrdenCompraViewModel();
            viewModel.MapToViewModel(ref ordencompra);
            return View(viewModel);
        }

        // POST: Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(OrdenCompraViewModel viewModel)
        {
            try
            {
                int id = viewModel.Id;
                string estado = await ordenCompraService.Delete(id);

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


        #region Imprimir
        public async Task<IActionResult> ImprimirODC(int id)
        {
            LlenarListas();
            OrdenCompraModel ordencompra = await ordenCompraService.GetById(id);

            OrdenCompraViewModel viewModel = new OrdenCompraViewModel();
            viewModel.MapToViewModel(ref ordencompra);

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Imprimir(int Id, string NombreProv, string DireccionProv, string TelefonosProv,
            string Descuento, string TotDescuento, string Iva, string TotIva, string Gasto, string TotalODC)
        {

            Descuento = Descuento==null ? "0": Descuento;
            TotDescuento = TotDescuento == null ? "0" : TotDescuento;

            Iva = Iva == null ? "0" : Iva;
            TotIva = TotIva == null ? "0" : TotIva;

            Gasto = Gasto == null ? "0" : Gasto;
            TotalODC = TotalODC == null ? "0" : TotalODC;


            OrdenCompraModel ordencompra = await ordenCompraService.GetById(Id);
            OrdenCompraViewModel odc = new OrdenCompraViewModel();
            odc.MapToViewModel(ref ordencompra);

            //string FilePath =  @"C:\Proyectos\Inventario\Inventario\Resource\OrdenCompra_0.html";
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", pathConfiguration.PathArchivos, "OrdenCompra_0.html");
            string PaginaHTML_Texto;
            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                PaginaHTML_Texto = streamReader.ReadToEnd();
            }


            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MIEMPRESA", "Elias Silva Sistemas");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ODC", odc.OccNroOrden);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", odc.OccFechaEmision);    //DateTime.Now.ToString("dd/MM/yyyy")
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOMICILIO", "Urb. La Hacienda, Sector UD3, Caricuao, Caracas");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PROVEEDOR", NombreProv);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOMICPRV", DireccionProv);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CIUDAD", "Caracas");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CONTACTO", "Jose Gonzalez");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TELEFONO", TelefonosProv);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ENTREGA", "Domicilio");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PLAZO", "30 días");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PAGO", "Contado");

            string filas = string.Empty;
            decimal total = 0;

            decimal importe = 0;
            string importeFmt;
            decimal montoIva = 0;
            string montoIvaFmt;
            decimal subTotal = 0;
            string subTotalFmt;
            string codigo;
            string nombre;
            long cantidad;
            string unidadMedida;
            decimal precioUnidad;
            string precioUnidadFmt;
            cantidad = 0;
            precioUnidad = 0;
            decimal totImporte;
            totImporte = 0;
            string totImporteFmt; 

            for (int i = 0; i < odc.OrdenCompraDetalleModels.Count; i++)
            {
                cantidad = odc.OrdenCompraDetalleModels[i].OcdCantidad;
                precioUnidad = odc.OrdenCompraDetalleModels[i].Producto.PrdPrecioUnidad;
                precioUnidadFmt = odc.OrdenCompraDetalleModels[i].Producto.PrdPrecioUnidad.ToString().Replace(",", ".");
                importe = cantidad * precioUnidad;
                importeFmt = importe.ToString().Replace(",", ".");
                
                totImporte = totImporte + importe;
                //totImporteFmt = totImporte.ToString().Replace(",", ".");
                filas += "<tr>";
                filas += "<td>" + odc.OrdenCompraDetalleModels[i].Producto.PrdCodigo + "</td>";
                filas += "<td>" + odc.OrdenCompraDetalleModels[i].Producto.PrdNombre + "</td>";
                filas += "<td align='right'>" + odc.OrdenCompraDetalleModels[i].OcdCantidad.ToString() + "</td>";
                filas += "<td align='right'>" + precioUnidadFmt + "</td>";
                filas += "<td align='right'>" + importeFmt + "</td>";
                filas += "</tr>";
            }

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

            totImporteFmt = totImporte.ToString().Replace(",", ".");
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SUBTOTAL", totImporteFmt);


            // Decimal Gasto, Decimal TotalODC


            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PORDES", Descuento.Replace(",", "."));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DESCUENTO", TotDescuento.Replace(",","."));

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PORIVA", Iva.Replace(",", "."));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@IVA", TotIva.Replace(",", "."));

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@GASTO", Gasto.Replace(",", "."));

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", TotalODC.Replace(",", "."));


            string nameFile;
            // Date today
            DateTime toDay;
            toDay = DateTime.Now;
            string strTYear = "";
            string strTMonth = "";
            string strTSecond = "";
            strTYear = toDay.Year.ToString().Trim();
            strTYear = strTYear.Substring(2, 2);
            strTMonth = toDay.Month.ToString().Trim();
            strTMonth = strTMonth.Length == 1 ? "0" + strTMonth : strTMonth;
            strTSecond = toDay.Second.ToString().Trim();
            nameFile = "ODC" + strTYear + strTMonth + strTSecond;
            string pathRootStr = AppDomain.CurrentDomain.BaseDirectory.Substring(0, 2) + "\\" + pathConfiguration.PathSalidas + "\\" + nameFile + ".pdf";


            FileStream stream = new FileStream(@pathRootStr, FileMode.Create, FileAccess.Write, FileShare.None);
            
            //Creamos un nuevo documento y lo definimos como PDF
            Document pdfDoc = new Document(PageSize.LETTER, 25, 25, 25, 25);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();
            pdfDoc.Add(new Phrase(""));

            //Agregamos la imagen del banner al documento
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.shop, System.Drawing.Imaging.ImageFormat.Png);
            //img.ScaleToFit(60, 60);
            //img.Alignment = iTextSharp.text.Image.UNDERLYING;

            ////img.SetAbsolutePosition(10,100);
            //img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
            //pdfDoc.Add(img);


            //pdfDoc.Add(new Phrase("Hola Mundo"));
            using (StringReader sr = new StringReader(PaginaHTML_Texto))
            {
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            }

            pdfDoc.Close();
            stream.Close();




            //FileStream fWrite = new FileStream(@"c:\proyectos\Textfile.txt",
            //         FileMode.Create, FileAccess.Write, FileShare.None);

            //Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

            //// Store the text in the variable text
            //var text = "This is some text written to the textfile " +
            //               "named Textfile using FileStream class.";

            //// Store the text in a byte array with
            //// UTF8 encoding (8-bit Unicode 
            //// Transformation Format)
            //byte[] writeArr = Encoding.UTF8.GetBytes(text);

            //// Using the Write method write
            //// the encoded byte array to
            //// the textfile
            //fWrite.Write(writeArr, 0, text.Length);

            //// Close the FileStream object
            //fWrite.Close();



            //string FilePath = @"C:\Proyectos\Inventario\Inventario\Resource\OrdenCompra_0.html";

            ////Create a string variable to hold the file data
            //string data;
            ////Create an Instance of FileStream Class By specifying the File Path, File Mode, FileAccess
            ////FileMode is going to be Open as we are going to read the data from the file
            ////To Read the File, we are providing Read Access
            //FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            ////Create an Instance of StreamReader Object to Read the Data from the Stream
            ////To the Constructor of StreamReader, pass the fileStream Object i.e. the stream to be read.
            //using (StreamReader streamReader = new StreamReader(fileStream))
            //{
            //    //ReadToEnd method reads all characters from the current position to the end of the stream. 
            //    //It will return the rest of the stream as a string, from the current position to the end. 
            //    //If the current position is at the end of the stream, returns an empty string ("").
            //    data = streamReader.ReadToEnd();
            //}





            //if (savefile.ShowDialog() == DialogResult.OK)
            //{
            //using (FileStream stream = new FileStream(savefile.FileName, FileAccess.Write))

            //using (FileStream stream = new FileStream("Test.pdf", FileAccess.Write))
            //    {
            //        //Creamos un nuevo documento y lo definimos como PDF
            //        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

            //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            //        pdfDoc.Open();
            //        pdfDoc.Add(new Phrase(""));

            //        //Agregamos la imagen del banner al documento
            //        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.shop, System.Drawing.Imaging.ImageFormat.Png);
            //        img.ScaleToFit(60, 60);
            //        img.Alignment = iTextSharp.text.Image.UNDERLYING;

            //        //img.SetAbsolutePosition(10,100);
            //        img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
            //        pdfDoc.Add(img);


            //        //pdfDoc.Add(new Phrase("Hola Mundo"));
            //        using (StringReader sr = new StringReader(PaginaHTML_Texto))
            //        {
            //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //        }

            //        pdfDoc.Close();
            //        stream.Close();
            //    }

            //}

            var response = new
            {
                impresion = "Ok"
            };
            return Json(response);


        }

        #endregion



        #region Others

        /// <summary>
        /// Llenar listas de combos
        /// </summary>
        public void LlenarListas()
        {
            // Lista Estatus orden de compra
            lstEstatusOcc = libreriaService.EstatusOdcList();
            lstEstatusOcc[0].Selected = true;
            ViewBag.Estatus = lstEstatusOcc;

            // Lista productos
            lstProductos = libreriaService.ProductosList();
            lstProductos[0].Selected = true;
            ViewBag.Productos = lstProductos;

            // Lista unidades de medida
            lstUnidadesMedida = libreriaService.UnidadMedidaList();
            lstUnidadesMedida[0].Selected = true;
            ViewBag.UnidadesMedida = lstUnidadesMedida;

            ViewBag.IVA = libreriaService.ValParametros("IVA");

        }

        /// <summary>
        /// Llenado de grid de consulta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult _Proveedores() 
        {
            List<ProveedorModel> lista = (List<ProveedorModel>)proveedorService.GetAllByStatus();            
            return PartialView("_Proveedores",lista);
        }

        /// <summary>
        /// Buscar proveedor
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BuscaProveedor(int Id)
        {
            //new List<ProveedorModel>();
            //var list = new List<ProveedorModel>();

            Proveedor proveedor = proveedorService.GetByIdNoAsync(Id);
            
            // Llenar modelo
            //foreach (var Item in lista)
            //{

            //    list.Add(new ProveedorModel()
            //    {
            //        //Id = Item.
            //        //name = Item.Text,
            //        //id = Item.Value.ToString()
            //    });
            //}
            
            return Json(proveedor);

        }

        /// <summary>
        /// Buscar un producto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BuscaProducto(int Id) 
        {
            Producto producto= await productoService.GetById(Id);            
            string codigo="";
            string nombre="";
            string cantPorUnidad = "";
            decimal precioUnidad=0;
            int stockMinimo=0;
            int stock = 0;
            
            if (producto != null)
            {                
                codigo = producto.PrdCodigo;
                nombre = producto.PrdNombre;
                cantPorUnidad = producto.PrdCantPorUnidad;
                precioUnidad = producto.PrdPrecioUnidad;
                stockMinimo = producto.PrdStockMinimo;
                stock = producto.PrdStock;
            }
            var response = new
            {
                jcodigo = codigo,
                jnombre = nombre,
                jcantPorUnidad = cantPorUnidad,
                jprecioUnidad = precioUnidad.ToString(),
                jstockMinimo = stockMinimo.ToString(),
                jstock = stock.ToString()
            };
            return Json(response);

        
        }

        [HttpPost]
        public IActionResult BuscaProductoNA(int Id) 
        {
            var response = new
            {
                jcodigo = "1",
                jnombre = "2",
                jcantPorUnidad = "3",
                jprecioUnidad = "4",
                jstockMinimo = "5",
                jstock = "6"
            };
            return Json(response);

        }


        #endregion


    }
}
