﻿function guardarTipoLibros() {

    $.ajax({
        type: "POST",
        url: UrlGuardarTipoLibros,
        async: true,
        data: {
            IdTiposLibros: document.getElementById("idTl").value,
            EstanteLibros: document.getElementById("Esta").value,
            TematicaLibros: document.getElementById("Tema").value,

        },
        success: function (data) {
            alert("Registro exitoso");
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}