function guardarInventario() {

    $.ajax({
        type: "POST",
        url: UrlInventario,
        async: true,
        data: {
            Cantidad_de_Libro: document.getElementById("CantLib").value,
            Fecha_Adquisicion: document.getElementById("FechAd").value,
            id_Libro: document.getElementById("idLib").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}