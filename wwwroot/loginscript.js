var obj;
$(document).ready(function () { 

    $("#login").click(function () {
        var options = {};
        options.url = "/api/admin/login";
        options.type = "POST";

        var obj = {};

        obj.Username = $('#username').val();
        obj.Password = $('#password').val();

        options.data = JSON.stringify(obj);
        options.contentType = "application/json";
        options.dataType = "json";

        options.success = function (obj) {
            sessionStorage.setItem("token", obj.token);
            $("#response").html("<h2>User successfully logged in.</h2 > "); 
            window.location.href = "show.html";
        };
        options.error = function () {
            $("#response").html("<h2>Error while calling the Web API!</h2 > ");
        };
        $.ajax(options);
    });


    $("#showData").click(function () {
        var options = {};
        options.url = "/api/Products";
        options.type = "GET";
        options.beforeSend = function (request) {
            request.setRequestHeader("Authorization",
                "Bearer " + sessionStorage.getItem("token"));
        };
        options.dataType = "json";
        options.success = function (data) {
            //var table = "<table border='1' cellpadding='10'>";
            //data.forEach(function (element) {
            //    var row = "<tr>";
            //    row += "<td>";
            //    row += element.productId;
            //    row += "</td>";
            //    row += "<td>";
            //    row += element.name;
            //    row += "</td>";
            //    row += "<td>";
            //    row += element.category;
            //    row += "</td>";
            //    row += "<td>";
            //    row += element.color;
            //    row += "</td>";
            //    row += "<td>";
            //    row += element.unitPrice;
            //    row += "</td>";
            //    row += "<td>";
            //    row += element.availableQuantity;
            //    row += "</td>";
            //    row += "</tr>";
            //    table += row;
            //});
            //table += "</table>";
            //$("#response").append(table);

            window.location.href = "crud.html";
        };
        options.error = function (a, b, c) {
            $("#response").html("<h2>Error while calling the Web API!(" + b + " - " + c + ")</h2 > ");
        };
        $.ajax(options);
    });

    $("#logout").click(function () {
        sessionStorage.removeItem("token");
        $("#response").html("<h2>User successfully logged out.</h2 > ");
    });

});


