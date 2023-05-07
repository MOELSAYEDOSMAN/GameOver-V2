"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.

connection.on("rcive", function (message, dat, user) {

        $("#CHAT").append('<div class="Other"><div class="Information"><p>' + user + '</p><p>Time : ' + dat + '</p></div><div class="Message"><h2>' + message + '</h2></div></div>');     
});

connection.start().then(function () {
    var groub = $("#groub").val();
    connection.invoke("joinGroub", groub)
    alert("start");
}).catch(function (err) {
    alert(err.toString());
});


    function sendMessage() {
        let message = $("#MessageText").val();
        if (message.length > 0) {
            let groub = $("#groub").val();
            let user = $("#user").val();

            connection.invoke("SendMessage", user, groub, message).catch(function (err) {
                return console.error();
            });
            $("#CHAT").append(' <div class="UserMessage"> <div class="Information"</div><p>Time : ' + Date.now().toString() + '</p><div class="Message"><h2>' + message + '</h2></div></div>');

        }
        else {
            alert("Must write Mewssage")
        }
    }

