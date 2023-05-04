function guardarPrestamo() {

    $.ajax({
        type: "POST",
        url: UrlGuardarPrestamo,
        async: true,
        data: {
            FechaSal: document.getElementById("FechaSal").value,
            FechaMaxDev: document.getElementById("FechaMaxDev").value,
            FechaDev: document.getElementById("FechaDev").value,
            idUsuario: document.getElementById("idUsuario").value,
            idTipoPrestamo: document.getElementById("idTipoPrestamo").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });

    limpiarFormulario();
}

function limpiarFormulario() {
    document.getElementById("FechaSal").value = "";
    document.getElementById("FechaMaxDev").value = "";
    document.getElementById("FechaDev").value = "";
    document.getElementById("idUsuario").value = "";
    document.getElementById("idTipoPrestamo").value = "";
}