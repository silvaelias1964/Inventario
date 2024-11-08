//*******************************************
// OrdenCompra.js
// Funciones y Metodos propios del módulo de Ordenes de compra
//**************************************************************


// Buscar proveedor
function SearchProv() {
    var Id;
    Id = 0;
    Id = $("#IdProveedor").val();

    if (Id > 0) {
        $.ajax({
            //url: '@Url.Action("BuscaProveedor", "OrdenCompra")',  // En archivo separado no funciona Url.Action
            url: '/OrdenCompra/BuscaProveedor/',
            type: 'POST',
            data: { id: Id },
            success: function (result) {

                $("#NombreProv").val(result.prvNombreCompania);
                $("#DireccionProv").val(result.prvDireccion);
                var telef1;
                var telef2;
                telef1 = (result.prvTelefono1 == null) ? "" : result.prvTelefono1;
                telef2 = (result.prvTelefono2 == null) ? "" : result.prvTelefono2;
                if (telef1 != "" && telef2 != "") {
                    $("#TelefonosProv").val(telef1 + ", " + telef2);
                } else {
                    if (telef1 != "" && telef2 == "") {
                        $("#TelefonosProv").val(telef1);
                    }
                }

                var correo1;
                var correo2;
                correo1 = (result.prvCorreoE1 == null) ? "" : result.prvCorreoE1;
                correo2 = (result.prvCorreoE2 == null) ? "" : result.prvCorreoE2;

                if (correo1 != "" && correo2 != "") {
                    $("#CorreosProv").val(correo1 + ", " + correo2);
                } else {
                    if (correo1 != "" && correo2 == "") {
                        $("#CorreosProv").val(correo1);
                    }
                }


                $("#DatosProv").show();
            },
            error: function (result) {
            }
        });
        direccion = $('#DireccionProv').val();
        telefonos = $('#TelefonosProv').val();
        correos = $('#CorreosProv').val();

    }
}

// Abrir/cerrar los datos del proveedor
$("#BarraTituloProv").on("click", function () {
    $("#DatosProv").toggle();
});

function GetLastChildId(parentElement) {
    return parentElement[0].children[1].children.length;
}

//Delete row
function DeleteRow(object) {
    for (var x = 0; x < 15; x++) {
        if (object.tagName == "TR") {
            break;
        }
        else {
            object = object.parentNode;
        }
    }
    var parentTbody = object.parentNode;

    var itemImporte = object.children[7].textContent;
    var itemSubTotal = object.children[8].textContent;

    var subImporte = $('#SubImporte').val();
    if (subImporte === "")
        subImporte = 0;

    var subSubTot = $('#SubTot').val();
    if (subSubTot === "")
        subSubTot = 0;

    $('#SubImporte').val(currency(Number(subImporte) - Number(itemImporte)));
    $('#SubTot').val(currency(Number(subSubTot) - Number(itemSubTotal)));

    PorcDescuento();
    PorcIva();
    Gastos();

    $(object).remove();
}

// Edit row
function EditRow(object) {
    for (var x = 0; x < 15; x++) {
        if (object.tagName === "TR") {
            break;
        }
        else {
            object = object.parentNode;
        }
    }
    var subtot = 0;
    subtot = TotalizaImp();
    $('#SubImporte').val(FormatoCurr(subtot.toString()));

    id = object.children[0];
    productoid = object.children[1];
    odc = object.children[2];

    codigo = object.children[3].children[0];
    descripcion = object.children[4].children[0]; //object.children[3].firstChild;
    unidadmedida = object.children[5].children[0];

    cantidad = object.children[6].children[0];
    costounitario = object.children[7].children[0]; //object.children[6].firstChild;

    $("#ProductoId_1").val(productoid.value).trigger('change.select');
    $("#Cantidad_1").val(cantidad.value);   //cantidad.textContent.trim()

    $("#jcodigo1").val(codigo.value);

    $("#jcantPorUnidad1").val(unidadmedida.value);
    $("#jprecioUnidad1").val(costounitario.value);

    var row = object.children[0].name;
    var ini = row.indexOf("[");
    var fin = row.lastIndexOf("]");

    idrow = row.substring(ini + 1, fin);

    $("#modalEditRow").modal('show');
}

// Editar
$('#editRowTable').on('click', function () {

    productoid.value = $("#ProductoId_1 option:selected").val();
    codigo.value = $("#jcodigo1").val();

    descripcion.value = $("#ProductoId_1 option:selected").text();

    unidadmedida.value = $("#jcantPorUnidad1").val();

    cantidad.value = $("#Cantidad_1").val();  // Valor interno

    costounitario.value = FormatoCurr($("#jprecioUnidad1").val());

    var subtotimp = 0;
    subtotimp = Number(cantidad.value) * Number(costounitario.value);  //costounitario.textContent);           
    document.getElementById("tablaDetalle").children[1].children[idrow].children[8].innerText = FormatoCurr(subtotimp.toString());

    var subtot = 0;
    subtot = TotalizaImp();
    $('#SubImporte').val(FormatoCurr(subtot.toString()));

    PorcDescuento();
    PorcIva();
    Gastos();

    CleanModalAdd();
});

// Limpiar campos modal form
function CleanModalAdd() {
    $("#ProductoId").val('0').trigger('change');
    $("#Cantidad").val('');
}

// Buscar datos adicionales del producto seleccionado
function BuscaProducto(opc) {
    var Id;
    Id = 0;
    if (opc === 1) {
        Id = $("#ProductoId").val();
    }
    else {
        Id = $("#ProductoId_1").val();
    }

    if (Id === "") {
        Id = $("#ProductoInicial").val();
    }
    $.ajax({
        //url: '@Url.Action("BuscaProducto", "OrdenCompra")',
        url: '/OrdenCompra/BuscaProducto/',
        type: 'POST',
        data: { id: Id },
        success: function (result) {
            if (opc == 1) {
                $("#jcodigo").val(result.jcodigo);
                $("#jnombre").val(result.jnombre);
                $("#jcantPorUnidad").val(result.jcantPorUnidad);
                $("#jprecioUnidad").val(result.jprecioUnidad);
                $("#jstockMinimo").val(result.jstockMinimo);
                $("#jstock").val(result.jstock);
            } else {
                $("#jcodigo1").val(result.jcodigo);
                $("#jnombre1").val(result.jnombre);
                $("#jcantPorUnidad1").val(result.jcantPorUnidad);
                $("#jprecioUnidad1").val(result.jprecioUnidad);
                $("#jstockMinimo1").val(result.jstockMinimo);
                $("#jstock1").val(result.jstock);
            }

        },
        error: function (result) {
        }
    });
}

// Calculo de descuento, por Porcentaje
function PorcDescuento() {
    var porcImpCtr = $('#Descuento').val();
    var porcentaje = Number(FormatoCurr(porcImpCtr));
    var importeCtr = $('#SubImporte').val();
    var importe = Number(FormatoCurr(importeCtr));
    var calcImporte = importe - ((porcentaje * 0.01) * importe);
    $('#TotDescuento').val(calcImporte.toFixed(2));
    TotalizaODC();
}

// Calculo del IVA, por porcentaje
function PorcIva() {
    var porcIva = $('#Iva').val();
    var porcentaje = Number(FormatoCurr(porcIva));
    var descuentoCtr = $('#TotDescuento').val();
    var descuento = Number(FormatoCurr(descuentoCtr));
    var calcIva = descuento * (porcentaje * 0.01);
    $('#TotIva').val(calcIva.toFixed(2));
    TotalizaODC();
}

// Calculo de gastos
function Gastos() {
    var mtoGasto = $('#Gasto').val();
    var gasto = Number(FormatoCurr(mtoGasto));
    if (gasto >= 0) {
        TotalizaODC();
        return true;
    } else {
        return false;
    }
}

// Totalizar la ODC
function TotalizaODC() {
    var subDescuento = $('#TotDescuento').val();
    var iva = $('#TotIva').val();
    var gasto = $('#Gasto').val();

    var tDescuento = 0;
    if (subDescuento != "")
        tDescuento = Number(subDescuento);

    var tIva = 0;
    if (iva != 0)
        tIva = Number(iva);

    var tGasto = 0;
    if (gasto != 0)
        tGasto = Number(gasto);

    var total = 0;
    total = tDescuento + tIva + tGasto;

    var totalFmt = FormatoCurr(total.toString());

    $('#TotalODC').val(totalFmt);

}

// Validar cantidad
function ValidaCantidad() {
    var valor = $('#Cantidad').val();
    var vcantidad = Number(valor);
    if (vcantidad > 0) {
        return true;
    } else {
        if (vcantidad == 0) {
            $('#Cantidad').val(1);
        } else {
            return false;
        }
    }

}

// Check de misma direccion
$('#OccMismaDireccion').on('change', function () {
    var valor = document.getElementById('OccMismaDireccion').checked;
    if (valor === false) {
        document.getElementById('DireccionProv').readOnly = false;
        document.getElementById('TelefonosProv').readOnly = false;
        document.getElementById('CorreosProv').readOnly = false;
        if (confirm("¿ Borra el contenido de la dirección, teléfonos y correos electrónicos ? ")) {
            direccion = $('#DireccionProv').val();
            telefonos = $('#TelefonosProv').val();
            correos = $('#CorreosProv').val();

            $('#DireccionProv').val('');
            $('#TelefonosProv').val('');
            $('#CorreosProv').val('');

        }

    } else {
        document.getElementById('DireccionProv').readOnly = true;
        document.getElementById('TelefonosProv').readOnly = true;
        document.getElementById('CorreosProv').readOnly = true;
        $('#DireccionProv').val(direccion);
        $('#TelefonosProv').val(telefonos);
        $('#CorreosProv').val(correos);

    }

});

// Seteo de direccion
function ChangeMismaDireccion() {
    var valor = document.getElementById('OccMismaDireccion').checked;
    if (valor === false) {
        $.ajax({
            success: function () {
                $('#DireccionProv').val($("#OccDireccion").val());
                $('#TelefonosProv').val($("#OccTelefonos").val());
                $('#CorreosProv').val($("#OccCorreosElec").val());
                document.getElementById('DireccionProv').readOnly = false;
                document.getElementById('TelefonosProv').readOnly = false;
                document.getElementById('CorreosProv').readOnly = false;
            }
        });
    }
}

// Totalizar los items
function TotalizaImp() {
    var subtotal = 0;
    var montorow = 0;
    for (var y = 0; y < document.getElementById("tablaDetalle").children[1].children.length; y++) {
        montorow = document.getElementById("tablaDetalle").children[1].children[y].children[8].firstChild.textContent;   //document.getElementById("tablaDetalle").children[1].children[y].children[7].innerText;
        if (montorow !== "") {
            subtotal = subtotal + Number(montorow);
        }
    }
    return subtotal;
}


function Cancel() {
    window.location.href = "/OrdenCompra/Index";
}

// Agregar linea a la tabla
$('#addRowTable').on('click', function () {

    var IdProd;
    IdProd = $("#ProductoId").val();
    var CodProd;
    CodProd = $("#jcodigo").val();
    if (IdProd !== "" && CodProd == "") {
        BuscaProducto(1);
    }
    if (IdProd !== null) {
        var idNumber = GetLastChildId($('#tablaDetalle'));
        var table = $('#tablaDetalle')[0].children[1];

        var codigorow = $('#jcodigo').val();
        var nombre = $('#jnombre').val();
        var cantidad = $('#Cantidad').val();
        if (cantidad.search(',') != -1) {
            cantidad = cantidad.replace(',', '.');
        }
        if (cantidad == "")
            cantidad = 1;
        var unidadMedida = $('#jcantPorUnidad').val();
        var precioUnidad = $('#jprecioUnidad').val();
        if (precioUnidad.search(',') != -1) {
            precioUnidad = precioUnidad.replace(',', '.');
        }
        var importe = Number(precioUnidad) * Number(cantidad);  //parseFloat(precioUnidad)*parseFloat(cantidad);
        importe = importe.toFixed(2);
        var montoIva = importe * 0.12;
        montoIva = montoIva.toFixed(2);
        var subTotal = Number(importe); //+ Number(montoIva);
        subTotal = Number(subTotal);
        subTotal = subTotal.toFixed(2);

        var importeCtr = $('#SubImporte').val();
        importeCtr = Number(FormatoCurr(importeCtr));
        var montoRes = Number(importe) + importeCtr;
        //FormateaNum(montoRes);
        //$('#SubImporte').val(SINFP(montoRes).format());
        $('#SubImporte').val(currency(montoRes));

        //$('#SubImporte').val(Number(importe) + importeCtr);

        var subTotCtr = $('#SubTot').val();
        subTotCtr = Number(FormatoCurr(subTotCtr));
        var subTotRes = Number(subTotal) + subTotCtr;
        $('#SubTot').val(currency(subTotRes));

        PorcDescuento();
        PorcIva();
        Gastos();
        if (codigo !== "") {
            $(table).append(
                '<tr role="row" class="odd">' +
                '<input data-val="true" data-val-required="The Id field is required." id="OrdenCompraDetalleModels_' + idNumber + '__Id" name="OrdenCompraDetalleModels[' + idNumber + '].Id" type = "hidden" value="0">' +
                '<input data-val="true" data-val-required="The ProductoId field is required." id="OrdenCompraDetalleModels_' + idNumber + '__ProductoId" name="OrdenCompraDetalleModels[' + idNumber + '].ProductoId" type="hidden" value="' + $('#ProductoId').val() + '">' +
                '<input data-val="true" data-val-required="The OrdenCompraId field is required." id="OrdenCompraDetalleModels_' + idNumber + '__OrdenCompraId" name="OrdenCompraDetalleModels[' + idNumber + '].OrdenCompraId" type = "hidden" value="' + $('#Id').val() + '">"' +
                '<td style="color:black;font-size:small">' +
                '<input class="input-lg"  data-val-maxlength-max="15" id="OrdenCompraDetalleModels_' + idNumber + '__Producto_PrdCodigo" maxlength="15" name="OrdenCompraDetalleModels[' + idNumber + '].Producto.PrdCodigo" readonly="readonly" style="border:transparent;background:transparent;outline:none;" type="text" value="' + codigorow + '" size="15">' +
                '</td>' +
                '<td style="color:black;font-size:small">' +
                '<input class="input-lg" data-val-maxlength-max="100" id="OrdenCompraDetalleModels_' + idNumber + '__Producto_PrdNombre" maxlength="100" name="OrdenCompraDetalleModels[' + idNumber + '].Producto.PrdNombre" readonly="readonly" style="border:transparent;background:transparent;outline:none;" type="text" value="' + nombre + '">' +
                '</td>' +
                '<td style="color:black;font-size:small">' +
                '<input class="input-lg" id="OrdenCompraDetalleModels_' + idNumber + '__Producto_PrdCantPorUnidad" maxlength="20" name="OrdenCompraDetalleModels[' + idNumber + '].Producto.PrdCantPorUnidad" readonly="readonly" style="border:transparent;background:transparent;outline:none;" type="text" value="' + unidadMedida + '">' +
                '</td>' +
                '<td style="text-align:right;color:black;font-size:small">' +
                '<input class="input-lg" id="OrdenCompraDetalleModels_' + idNumber + '__OcdCantidad" name="OrdenCompraDetalleModels[' + idNumber + '].OcdCantidad" readonly="readonly" style="border:transparent;background:transparent;outline:none;text-align:right;" type="text" value="' + cantidad + '" size="10">' +
                '</td>' +
                '<td style="text-align:right;color:black;font-size:small">' +
                '<input class="input-lg" id="OrdenCompraDetalleModels_' + idNumber + '__Producto_PrdPrecioUnidad" name="OrdenCompraDetalleModels[' + idNumber + '].Producto.PrdPrecioUnidad" readonly="readonly" style="border:transparent;background:transparent;outline:none;text-align:right;" type="text" value="' + precioUnidad + '" size="10">' +
                '</td>' +
                '<td style="text-align:right;color:black;font-size:small">' +
                importe +
                '</td>' +
                //'<td style="text-align:right;color:black;">' +
                //montoIva +
                //'</td>' +
                //'<td style="text-align:right;color:black;">' +
                //subTotal +
                //'</td>' +

                '<td style="text-align:center;color:black;font-size:small">' +
                '<a onclick="EditRow(this);"><i class="icon-pencil7"></i></a>  ' +
                '<a onclick="DeleteRow(this);"><i class="icon-trash"></i></a>' +
                '</td>' +
                '</tr>'
            );

            CleanModalAdd();
        }
    }
});

