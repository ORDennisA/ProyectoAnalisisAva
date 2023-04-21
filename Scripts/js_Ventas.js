function guardarVentas() {

    $.ajax({
        type: "POST",
        url: UrlGuardarVentas,
        async: true,
        data: {
            // idVentaLibro: document.getElementById("idVentaLibro").value,
            Total: document.getElementById("Total").value,
            Fecha: document.getElementById("Fecha").value,
            Hora: document.getElementById("Hora").value,
            idEmpleado: document.getElementById("idEmpleado").value,
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
    document.getElementById("Total").value = "";
    document.getElementById("Fecha").value = "";
    document.getElementById("Hora").value = "";
    document.getElementById("idEmpleado").value = "";
}