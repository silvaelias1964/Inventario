
// Validate password special character
function validate_specchar(strpassw) {
    var specialCharacter = false;
    
    for (var i = 0; i < strpassw.length; i++) {
    
        if (strpassw.charCodeAt(i) == 33) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) >= 35 && strpassw.charCodeAt(i) <= 38) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) >= 40 && strpassw.charCodeAt(i) <= 43) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) == 45 ) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) >= 60 && strpassw.charCodeAt(i) <= 64) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) == 91) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) >= 93 && strpassw.charCodeAt(i) <= 95) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) >= 123 && strpassw.charCodeAt(i) <= 126) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) == 161) {
            specialCharacter = true;
        }
        else if (strpassw.charCodeAt(i) == 191) {
            specialCharacter = true;
        }
    }

        
    return specialCharacter;
        

}

// Show/Hide Password
function showPassword(mode) {
    var cambio = (mode == 1) ? document.getElementById("Password") : document.getElementById("ConfirmPassword");
    if (cambio.type == "password") {
        cambio.type = "text";
        $('.icon').removeClass('icon-eye2').addClass('icon-eye-blocked2');
    } else {
        cambio.type = "password";
        $('.icon').removeClass('icon-eye-blocked2').addClass('icon-eye2');
    }
}



