function guardarVentaLibros() {

    $.ajax({
        type: "POST",
        url: UrlGuardarVentaLibros,
        async: true,
        data: {
            idLibro: document.getElementById("idLibro").value,
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}
