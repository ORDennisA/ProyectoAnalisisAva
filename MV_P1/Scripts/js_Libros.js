function guardarLibros() {

    $.ajax({
        type: "POST",
        url: UrlGuardarLibro,
        async: true,
        data: {
            Nombre: document.getElementById("Nomb").value,
            Editorial: document.getElementById("Edit").value,
            Autor: document.getElementById("Aut").value,
            Genero: document.getElementById("Gene").value,
            PaisOrigen: document.getElementById("PaisO").value,
            NoPaginas: document.getElementById("NoPag").value,
            FechaEdicion: document.getElementById("FechaEdi").value,
            Precio: document.getElementById("Prec").value,
            id_TipoLibro: document.getElementById("idTipoLi").value
        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}