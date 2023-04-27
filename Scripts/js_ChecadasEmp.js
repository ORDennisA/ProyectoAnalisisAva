function guardarChecadas() {

    $.ajax({
        type: "POST",
        url: UrlGuardarChecadas,
        async: true,
        data: {
            Fecha: document.getElementById("fecha").value,
            Entrada: document.getElementById("entrada").value,
            Salida: document.getElementById("salida").value,
            id_Empleados: document.getElementById("idEM").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });

    limpiarFormulario();
}

function limpiarFormulario() {
    document.getElementById("fecha").value = "";
    document.getElementById("entrada").value = "";
    document.getElementById("salida").value = "";
    document.getElementById("idEM").value = "";
} 