function guardarPrestamo() {

    $.ajax({
        type: "POST",
        url: urlGuardarPrestamos,
        async: true,
        data: {
            FECHADESALIDA: document.getElementById("fechasalida").value,
            FECHAMAXDEV: document.getElementById("fechamaxdev").value,
            FECHADEV: document.getElementById("fechadedevolucion").value,
            IDUSUER: document.getElementById("idusuario").value,
            IDTP: document.getElementById("idtipop").value
        },
        success: function (data) {
            alert("Registro exitoso");
            window.location.href = "listaPrestamo";

        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}