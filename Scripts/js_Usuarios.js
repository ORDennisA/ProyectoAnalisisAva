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
            FechaNacimiento: document.getElementById("FechaNac").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });

    limpiarFormulario();
    // console.log(document.getElementById("FechaNac").value);
}

function limpiarFormulario() {
    document.getElementById("Nombres").value = "";
    document.getElementById("Apellidos").value = "";
    document.getElementById("DNI").value = "";
    document.getElementById("Domicilio").value = "";
    document.getElementById("FechaNac").value = "";

}