//Show dialog to confirm delete.
function confirmDialog(title, message, url, id) {
    bootbox.confirm({
        title: title,
        message: message,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Cancel'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Confirm'
            }
        },
        callback: function (value) {
            if (value) {
                window.location.replace(url + '?=' + id);
            }
        }
    });
}

function showWarningDialog(title, message) {

    // Solid warning
    new PNotify({
        delay: 2000,
        title: title,
        text: message,
        addclass: 'bg-warning-600',
        icon: 'icon-warning22'
    });
}


function showSuccessDialog(title, message) {

    // Info notification
    new PNotify({
        delay: 2000,
        title: title,
        text: message,
        icon: 'icon-floppy-disk',
        type: 'info',
        addclass: 'bg-success-600'
    });
}

function showFailedDialog(title, message) {
    // Solid warning
    new PNotify({
        delay: 2000,
        title: title,
        text: message,
        addclass: 'bg-danger-600',
        icon: 'icon-blocked'
    });
}

function confirmOut(DCTitle, DCText, DCConfirmButtonText, DCCancelButtonText) {

    swal({
        title: DCTitle,
        text: DCText,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#4CAF50",
        confirmButtonText: DCConfirmButtonText,
        cancelButtonText: DCCancelButtonText,
        cancelButtonColor: "#EF5350",
        closeOnConfirm: true,
        closeOnCancel: true
    },
        function (isConfirm) {
            if (isConfirm) {
                Cancel();
            }
        });
}

function showProcessDialog(title, message) {

    // Info notification
    new PNotify({
        delay: 4000,
        title: title,
        text: message,
        icon: 'icon-file-check',
        type: 'info',
        addclass: 'bg-success-600'
    });
}

// Display error messages
function MsgError(msg) {
    swal({
        title: "Error!",
        text: msg,
        confirmButtonColor: "#546E7A"
    });
}