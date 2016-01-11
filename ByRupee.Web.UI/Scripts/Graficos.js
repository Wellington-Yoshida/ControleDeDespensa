$(documet).ready(function () {
    $("#btnGraficos").on("click", function () {
        var grafico = {
            url: "/Graficos/RetornaGraficos/",
            method: "GET",
            dataType: "Json",
            contentType: "application/Json; charset=utf-8"
        };

        var request = $.ajax(grafico);

        request.done(function (data) {

        });
    });
});