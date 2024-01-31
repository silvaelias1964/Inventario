function CalculoEdad() {
    var dateString = $("#FechaNacimiento").val();
    var now = new Date();
    var recDD = dateString.substr(8, 2);
    var recMM = dateString.substr(5, 2);
    var recYY = dateString.substr(0, 4);
    var dateBirth = new Date(recMM + "/" + recDD + "/" + recYY);
    var age = now.getFullYear() - dateBirth.getFullYear();

    //var difMonths = get_month(now) - get_month(dateBirth);
    var difMonths = now.getMonth() - dateBirth.getMonth();
    if (
        difMonths < 0 ||
        (difMonths === 0 && now.getDate() < dateBirth.getDate())
    ) {
        age--;
    }
    //return age;
    $("#Edad").val(age);
}


function get_month(datecheck) {
    return datecheck.getMonth() + 1;
}

//Calculo total pago
function totalFactura() {
    var montopag = $("#Monto").val();
    var montodes = $("#Descuento").val();
    var montoiva = 0;
    var iva = $("#Iva").val();
    var montotot = 0;
    var montofinal = 0;
    // Si hay descuento
    if (montodes > 0) {
        montotot = montopag - montodes;
    }
    else {
        montotot = montopag;
    }
    // Si hay Iva
    if (iva > 0)
        montoiva = (montotot * (iva * .01));

    montofinal = montotot + montoiva;

    $("#total").val(montofinal);

}

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [day, month, year].join('/');
}

// Desplegar imagenes de producto, solo dos
function MostrarImg(opt) {
    let nomImg = "";
    let pos = 0;
    let nomDef = "";
    if (opt === 1) {
        nomImg = File1.value;
        pos = nomImg.lastIndexOf("\\");
        nomDef = nomImg.substr(pos + 1);
        document.getElementById("foto1").src = "/FotosProductos/" + nomDef;
        $("#PrdFoto1").val(nomDef);
    }
    else if (opt === 2) {
        nomImg = File2.value;
        pos = nomImg.lastIndexOf("\\");
        nomDef = nomImg.substr(pos + 1);
        document.getElementById("foto2").src = "/FotosProductos/" + nomDef;
        $("#PrdFoto2").val(nomDef);
    }
    else {
        nomDef = $("#PrdFoto1").val();
        document.getElementById("foto1").src = "/FotosProductos/" + nomDef;
        nomDef = $("#PrdFoto2").val();
        document.getElementById("foto2").src = "/FotosProductos/" + nomDef;
    }
}

