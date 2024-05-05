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

//Validacion para solo letras
function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key === especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

// Validacion de solo numeros
function soloNumeros(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "1234567890";
    especiales = "8-37-39-46";

    if (letras.indexOf(tecla) === -1) {
        return false;
    }
}

// Validacion de solo numeros de tlf
function soloNumerosTlf(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " 1234567890-+";
    especiales = "8-37-39-46";

    if (letras.indexOf(tecla) === -1) {
        return false;
    }
}

// Validacion de solo numeros de Id
function soloNumerosId(e) {
    if ($("#psTipo").val() === "P" || $("#psTipo").val() === "E") {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = "1234567890abcdefghijklmnñopqrstuvwxyz";
        especiales = "8-37-39-46";

        if (letras.indexOf(tecla) === -1) {
            return false;
        }
    } else {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = "1234567890";
        especiales = "8-37-39-46";

        if (letras.indexOf(tecla) === -1) {
            return false;
        }
    }
}

// Validacion de telefono
function CheckTlf(carac) {
    cadena = document.getElementById("Telef").value;
    numCar = cadena.length;
    var cadenach = "";
    cadenach = cadena;
    var repeticiones = 0;
    if (carac == "+") {
        pos = cadenach.indexOf("+");
        if (pos > 0) {
            return false;
        }
    }

    if (carac == " ") {
        pos = cadenach.indexOf(" ");
        if (pos == -1) {
            return false;
        }
    }

    //if (carac == "-") {
    //    pos = cadenach.indexOf("-");
    //    if (pos == -1) {
    //        return false;
    //    }
    //}

    while (true) {
        pos = cadenach.indexOf(carac);
        if (pos >= 0) {
            cadenach = cadenach.substr(pos + 1);
            repeticiones = repeticiones + 1;
        }
        else {
            break;
        }
    }
    if (repeticiones > 1) {
        // Formato incorrecto, el formato debe ser 9999-9999999 
        return false;
    } else {
        return true;
    }
}

// Validacion de CI/RIF
function ValidarCIRIF(str, tipo) {
    let caracteres = [... new Set(str.toLowerCase())]
    let msg = "";
    for (var i = 0; i < caracteres.length; i++) {
        let arreglo = []
        str.split('').map(n => {
            if (n.toLowerCase() === caracteres[i]) {
                arreglo.push(n)
            }
        })
        if (caracteres[i] == tipo.toLowerCase() && arreglo.length > 1) {
            msg = "Error";
        }
    }
    return msg;
}

// Validación de Email
function validarEmail(email) {
    var x = email;
    var atposition = x.indexOf(String.fromCharCode(64));
    var dotposition = x.lastIndexOf(".");
    if (atposition < 1 || dotposition < atposition + 2 || dotposition + 2 >= x.length) {
        return false;
    }
    else {
        return true;
    }
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

// Formateo de monto a pagar
function Formato(monto) {
    let montoimp = 0;
    let montostr = "";
    montostr = monto;
    montoimp = Number(montostr);
    montoimp = montoimp.toFixed(2);
    // Dolares
    const totalPrecioUsd = new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
    }).format(montoimp)

    // Euros
    //const totalPrecioEur = new Intl.NumberFormat("es-ES", {
    //    style: "currency",
    //    currency: "EUR",
    //}).format(montoimp)

    //$("#montoformatdl").val(totalPrecioUsd);
    //$("#montoformateu").val(totalPrecioEur);
    return totalPrecioUsd;
}

// Formateo de monto currency
function FormatoCurr(monto) {
    let montoimp = 0;
    let montostr = "";
    montostr = monto;
    montoimp = Number(montostr);
    montoimp = montoimp.toFixed(2);

    return montoimp;
}

// Determine the correct month, this is for a bug in function javascript getMonth()
function get_month(dtmNow) {
    var mthReturn = 0;
    var dt = dtmNow.toString();
    var monthNames = [
        "Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul",
        "Aug", "Sep", "Oct",
        "Nov", "Dec"
    ];
    var i;
    var pos = 0;
    for (i = 0; i <= 11; i++) {
        pos = dt.indexOf(monthNames[i]);
        if (pos > 0) {
            mthReturn = i + 1;
            break;
        }
    }
    return mthReturn;
}

//make disble input
function SetDisableInput(inputId) {
    var input = document.getElementById(inputId);
    if (input != undefined) {
        input.disabled = true;
    }
}

//make enable input
function SetEnableInput(inputId) {
    var input = document.getElementById(inputId);
    if (input != undefined) {
        input.disabled = false;
    }
}

// Check and format decimals
$('.decimales').on('input', function () {    
    this.value = this.value.replace(/[^0-9,.]/g, '').replace(/,/g, '.');    
    var str = this.value;
    // integer
    var n = str.indexOf(".");
    var res = "";
    if (n > 0) {
        res = str.substring(0, n);
    }
    else {
        res = str;
    }

    // decimal
    var dec = "";
    if (n > 0) {
        dec = str.substring(n + 1);
        if (dec.length > 10) {
            dec = dec.slice(0, 10);
        }
    }
    if (res.length > 18) {
        res = res.slice(0, 18);
    }
    if (n > 0) {
        this.value = res + str.substring(n, n + 1) + dec;
    }
    else {
        this.value = res;
    }

});



// Check and format percentage
$('.porcentajes').on('input', function () {
    this.value = this.value.replace(/[^0-9,.]/g, '').replace(/,/g, '.');
    if (this.value.length > 5)
        this.value = this.value.slice(0, 5);

    var str = this.value;
    // integer
    var n = str.indexOf(".");
    var res = "";
    if (n > 0) {
        res = str.substring(0, n);
    }
    else {
        res = str;
    }

    if (res.length >= 4) {
        this.value = res.slice(0, 3);
    }

    if (this.value > 100) {
        this.value = "100";
    }

});


$('.decimal-value').on('input', function () {
    this.value = this.value.replace(/[^0-9,.]/g, '').replace(/,/g, '.');
    if (this.value.length > 9)
        this.value = this.value.slice(0, 9);

    var str = this.value;
    // integer
    var n = str.indexOf(".");
    var res = "";
    if (n > 0) {
        res = str.substring(0, n);
    }
    else {
        res = str;
    }
    if (res.length >= 9) {
        this.value = res.slice(0, 8);
    }
    if (this.value > 99999999) {
        this.value = "99999999";
    }
});


// Check and format integer
$('.enteros').on('input', function () {
    this.value = this.value.replace(/[^0-9,.]/g, '');
    if (this.value.length >= 10)
        this.value = this.value.slice(0, 9);
});

// Display error messages
function MsgError(msg) {
    swal({
        title: "Error!",
        text: msg,
        confirmButtonColor: "#546E7A"
    });
}

// Check time correct
function ValidateHour(dtmRecDate, dtmRecTime) {
    try {
        // Time now
        var dtmNow = new Date();
        var nowYY = dtmNow.getFullYear();
        var nowMM = get_month(dtmNow);
        var nowDD = dtmNow.getDate();
        var nowTHH = dtmNow.getHours();
        var nowTMM = dtmNow.getMinutes();
        var dateNow = new Date(nowYY, nowMM, nowDD, nowTHH, nowTMM, 0);

        // Date/Time record
        var recDD = dtmRecDate.substr(0, 2);
        var recMM = dtmRecDate.substr(3, 2);
        var recYY = dtmRecDate.substr(6, 4);
        var recTHH = dtmRecTime.substr(0, 2);
        var recTMM = dtmRecTime.substr(3, 2);
        //new Date(Year, Month, Date, Hr, Min, Sec);    

        var dateRec = new Date(recYY, recMM, recDD, recTHH, recTMM, 0);

        if (dateRec < dateNow) {
            return false;
        } else {
            return true;
        }

    } catch (exception) {
        //console.log(exception.message);
        //console.log(exception.name);
    }
}

