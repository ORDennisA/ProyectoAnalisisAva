function guardarChecadas() {

    $.ajax({
        type: "POST",
        url: UrlGuardarChecadas,
        async: true,
        data: {
            Id: document.getElementById("idCh").value,
            Nombres: document.getElementById("fecha").value,
            Apellidos: document.getElementById("entrada").value,
            DNI: document.getElementById("salida").value,
            Domicilio: document.getElementById("idEM").value,
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}