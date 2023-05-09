function getReporte() {

    $.ajax({
        type: "GET",
        url: UrlReportes,
        async: true,
        data: {
            tipoReporte: document.getElementById("tipoReporte").value,
            fechaInicio: document.getElementById("fechaInicio").value,
            fechaFinal: document.getElementById("fechaFinal").value,
        },
        success: function (data, status) {
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });

    limpiarFormulario();
}

function limpiarFormulario() {
    document.getElementById("tipoReporte").value = "";
    document.getElementById("fechaInicio").value = "";
    document.getElementById("fechaFinal").value = "";
} 