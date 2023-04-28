function guardarPrestamo() {

    $.ajax({
        type: "POST",
        url: UrlGuardarPrestamo,
        async: true,
        data: {
            FechaDeSalida: document.getElementById("FechaSalida").value,
            FechaMaximaDeDevolucion: document.getElementById("FechaMaxDev").value,
            FechaDeDevolucion: document.getElementById("FechaDev").value,
            id_Usuario: document.getElementById("idUsuario").value,
            id_TipoDePrestamo: document.getElementById("idTipoPrestamo").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}