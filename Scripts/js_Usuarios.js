function guardarUsuarios() {

    $.ajax({
        type: "POST",
        url: UrlGuardarUsuarios,
        async: true,
        data: {
            Nombres: document.getElementById("Nombres").value,
            Apellidos: document.getElementById("Apellidos").value,
            DNI: document.getElementById("DNI").value,
            Domicilio: document.getElementById("Domicilio").value,
            },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}