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
            // helper local variables
            var dateTemp = '';
            var timeTemp = '';

            // Create rows for report
            var rows = [];

            for (var i = 0; i < data.length; i++) {
                // Fill rows array with same number of rows in received data
                rows.push($('<tr>'));
            }

            // Parse received data object and store each row
            for (var i = 0; i < rows.length; i++) {
                // first normalize date and time data to simple strings, makes it easier to display
                dateTemp = jsonToJSDate(data[i].Fecha);
                timeTemp = jsonToStringTime(data[i].Hora);

                rows[i].append($('<td>').html(data[i].id_Venta));
                rows[i].append($('<td>').html(data[i].Total));
                rows[i].append($('<td>').html(dateTemp));
                rows[i].append($('<td>').html(timeTemp));
                rows[i].append($('<td>').html(data[i].id_Empleado));
            }

            // Append rows to report view, depending on toggle state
            if (toggle == 'ventas') {
                for (var i = 0; i < rows.length; i++) {
                    $('#tableVentas').append(rows[i]);
                }
            }
            else if (toggle == 'prestamos') {
                for (var i = 0; i < rows.length; i++) {
                    $('#tablePrestamos').append(rows[i]);
                }
            }
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

function jsonToJSDate(date) {
    var convertedDate = new Date(parseInt(date.substr(6)));
    return convertedDate.toISOString().slice(0,10);
}

function jsonToStringTime(time) {
    var hh = String(time.Hours).padStart(2, '0');
    var mm = String(time.Minutes).padStart(2, '0');

    return hh + ':' + mm;
}

// Initialize event listener(s)
toggleReport();