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

