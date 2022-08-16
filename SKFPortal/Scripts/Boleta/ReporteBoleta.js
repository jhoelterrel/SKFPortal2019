$(document).ready(function () {
    $("#btnGenerarReporteBoleta").click(function () {
        ReportManager.LoadReport();
    });

    $("#Ejercicio").change(function () {
        changeEstado();
    });
});

var ReportManager = {
    LoadReport: function () {

        var serviceUrl = "../Home/GenerarReporteBoleta?cPeriodo=" + $("#Periodo").val() +
            "&cPeriodo_D=" + $("#Periodo option:selected").text()+
            "&cProceso=" + $("#Proceso").val() +
            "&cProceso_D=" + $("#Proceso option:selected").text();

        ReportManager.GetReport(serviceUrl, onFailed);
        function onFailed(error) {
            alert("Found error");
        }

    },
    GetReport: function (serviceUrl, errorCallback) {

        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "GET",
            data: null,
            contentType: "application/json;charset=utf-8",
            success: function () {
                window.open('../Reportes/Boleta/ReporteBoletasViewer.aspx', '_newtab');
            },
            error: errorCallback
        });
    }
}


function changeEstado() {

    let ejercicioid = $("#Ejercicio").val();

    AjaxCall('../Json/ObtenerPeriodo?Ejercicio_Id=' + ejercicioid, null).done(function (response) {
        console.log("ENTRO AL CHAT")
        if (response.length > 0) {
            $('#Periodo').html('');
            var options = '';
       
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + response[i].Periodo_Id + '">' + response[i].Descripcion + '</option>';
            }
            $('#Periodo').append(options);
        }
    }).fail(function (error) {
        alert(error.StatusText);
    });


    console.log("CAMBIO ESTADO");
}

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}