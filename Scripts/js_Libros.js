function guardarLibros() {

    $.ajax({
        type: "POST",
        url: UrlGuardarLibros,
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
            id_TipoLibro: document.getElementById("idTL").value
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
    document.getElementById("Nomb").value = "";
    document.getElementById("Edit").value = "";
    document.getElementById("Aut").value = "";
    document.getElementById("Gene").value = "";
    document.getElementById("PaisO").value = "";
    document.getElementById("NoPag").value = "";
    document.getElementById("FechaEdi").value = "";
    document.getElementById("Prec").value = "";
    document.getElementById("idTL").value = "";
}