// Globals

var toggle = "ventas";
var tableVentas = document.getElementById("reporteVentas");
var tablePrestamos = document.getElementById("reportePrestamos");
var tipoReporte = document.getElementById("tipoReporte");


// Functions

function getReporte() {
    // Sends form info to controller, gets a json data object, and then displays it
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

function toggleReport() {
    // Both reports hidden first
    tableVentas.style.display = "none";
    tablePrestamos.style.display = "none";

    // Show reports as selected by user
    tipoReporte.addEventListener("change", () => {
        toggle = document.getElementById("tipoReporte").value;         
        console.log(toggle);

        if (toggle == "ventas") {
            tableVentas.style.display = "block";
            tablePrestamos.style.display = "none";
        }
        else if (toggle == "prestamos") {
            tableVentas.style.display = "none";
            tablePrestamos.style.display = "block";
        }
        else {
            tableVentas.style.display = "none";
            tablePrestamos.style.display = "none";
        }
    });
}

// Initialize event listener(s)
toggleReport();