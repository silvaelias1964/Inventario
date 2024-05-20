/// Library for EditProf
var myInput1 = document.getElementById("etNewPassword");
var myInput2 = document.getElementById("etConfirmNewPassword");

var letter = document.getElementById("letter");
var capital = document.getElementById("capital");
var number = document.getElementById("number");
var length = document.getElementById("length");
var charsp = document.getElementById("charsp");
var psmatch = document.getElementById("psmatch");

// When the user clicks on the Password field, show the message box
myInput1.onfocus = function () {
    document.getElementById("message").style.display = "block";
}

// When the user starts to type something inside the etNewPassword field
myInput1.onkeyup = function () {    
    // Validate lowercase letters
    var lowerCaseLetters = /[a-z]/g;
    if (myInput1.value.match(lowerCaseLetters)) {
        letter.classList.remove("text-danger");
        letter.classList.add("text-success");

    } else {
        letter.classList.remove("text-success");
        letter.classList.add("text-danger");
    }

    // Validate capital letters
    var upperCaseLetters = /[A-Z]/g;
    if (myInput1.value.match(upperCaseLetters)) {
        capital.classList.remove("text-danger");
        capital.classList.add("text-success");

    } else {
        capital.classList.remove("text-success");
        capital.classList.add("text-danger");
    }

    // Validate numbers
    var numbers = /[0-9]/g;
    if (myInput1.value.match(numbers)) {
        number.classList.remove("text-danger");
        number.classList.add("text-success");

    } else {
        number.classList.remove("text-success");
        number.classList.add("text-danger");
    }

    // Validate length
    if (myInput1.value.length >= 8 && myInput1.value.length <= 20) {
        length.classList.remove("text-danger");
        length.classList.add("text-success");
    } else {
        length.classList.remove("text-success");
        length.classList.add("text-danger");
    }
   
    // Validate character special        
    var ischarsp = validate_specchar(myInput1.value);
    if (ischarsp == true) {
        charsp.classList.remove("text-danger");
        charsp.classList.add("text-success");
    } else {
        charsp.classList.remove("text-success");
        charsp.classList.add("text-danger");
    }

    if (document.getElementById("etNewPassword").value == document.getElementById("etConfirmNewPassword").value) {
        psmatch.classList.remove("text-danger");
        psmatch.classList.add("text-success");
    } else {
        psmatch.classList.remove("text-success");
        psmatch.classList.add("text-danger");
    }



}

myInput2.onkeyup = function () {    
    if (document.getElementById("etNewPassword").value == document.getElementById("etConfirmNewPassword").value) {
        psmatch.classList.remove("text-danger");
        psmatch.classList.add("text-success");
    } else {
        psmatch.classList.remove("text-success");
        psmatch.classList.add("text-danger");

    }        
}


// Events show/hide password
window.addEventListener("load", function () {
    // icon to be able to interact with the element
    showPassword1 = document.querySelector('.show-password1');
    showPassword2 = document.querySelector('.show-password2');
    showPassword3 = document.querySelector('.show-password3');

    showPassword1.addEventListener('click', () => {
        // input elements of type password
        var password1 = document.querySelector('.password1');

        if (password1.type === "text") {
            password1.type = "password"
            showPassword1.classList.remove('fa-eye-slash');
        } else {
            password1.type = "text"
            showPassword1.classList.toggle("fa-eye-slash");
        }

    })

    showPassword2.addEventListener('click', () => {
        // input elements of type password
        var password2 = document.querySelector('.password2');

        if (password2.type === "text") {
            password2.type = "password"
            showPassword2.classList.remove('fa-eye-slash');
        } else {
            password2.type = "text"
            showPassword2.classList.toggle("fa-eye-slash");
        }

    })

    showPassword3.addEventListener('click', () => {
        // input elements of type password
        var password3 = document.querySelector('.password3');

        if (password3.type === "text") {
            password3.type = "password"
            showPassword3.classList.remove('fa-eye-slash');
        } else {
            password3.type = "text"
            showPassword3.classList.toggle("fa-eye-slash");
        }

    })

});



