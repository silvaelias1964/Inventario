/// Library for ResetPassword
var myInput1 = document.getElementById("Password");
var myInput2 = document.getElementById("ConfirmPassword");

var letter = document.getElementById("letter");
var capital = document.getElementById("capital");
var number = document.getElementById("number");
var length = document.getElementById("length");
var charsp = document.getElementById("charsp");
var psmatch = document.getElementById("psmatch");

// When the user clicks on the password field, show the message box
myInput1.onfocus = function () {
    document.getElementById("message").style.display = "block";
}


// When the user starts to type something inside the password field
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

    if (document.getElementById("Password").value == document.getElementById("ConfirmPassword").value) {
        psmatch.classList.remove("text-danger");
        psmatch.classList.add("text-success");
    } else {
        psmatch.classList.remove("text-success");
        psmatch.classList.add("text-danger");
    }


}

myInput2.onkeyup = function () {      
    if (document.getElementById("Password").value == document.getElementById("ConfirmPassword").value) {
        psmatch.classList.remove("text-danger");
        psmatch.classList.add("text-success");
    } else {
        psmatch.classList.remove("text-success");
        psmatch.classList.add("text-danger");
    }
}

// Check password match
function submitMatchPassword() {

    var newPassword = $('#Password').val();
    var confirmNewPassword = $('#ConfirmPassword').val();

    if (newPassword != "" && confirmNewPassword != "") {

        if (newPassword == confirmNewPassword) {
            document.getElementById("message").style.display = "none";
            return true;

        }
        else {
            document.getElementById("message").style.display = "block";
            return false;
        }
    }
    else {
        return false;

    }
}