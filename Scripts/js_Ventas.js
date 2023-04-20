function guardarVentas() {

    $.ajax({
        type: "POST",
        url: UrlGuardarVentas,
        async: true,
        data: {
            Total: document.getElementById("Total").value,
            Fecha: document.getElementById("Fecha").value,
            Hora: document.getElementById("Hora").value,
            idEmpleado: document.getElementById("idEmpleado").value,
            idVentaLibro: document.getElementById("IdLibro").value,
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}