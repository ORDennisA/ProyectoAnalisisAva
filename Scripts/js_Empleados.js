function guardarEmpleado() {

    $.ajax({
        type: "POST",
        url: UrlGuardarEmpleado,
        async: true,
        data: {
            NombreEmpleado: document.getElementById("nom").value,
            ApellidosEmpleado: document.getElementById("apell").value,
            DNIempleado: document.getElementById("dni").value,
            DomicilioEmpleado: document.getElementById("pre").value,
            FechaDeNacimientoEmpleado: document.getElementById("can").value,
            AntiguedadEmpleado: document.getElementById("ant").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}