"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.

connection.on("rcive", function (message, dat, user) {
    $("#CHAT").append('<div class="Other"><div class="Information"><p>' + user + '</p><p>Time : ' + dat + '</p></div><div class="Message"><h2>' + message +'</h2></div></div>');    
});

connection.start().then(function () {
    var groub = $("#groub").val();
    connection.invoke("joinGroub", groub)
}).catch(function (err) {
    alert(err.toString());
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = $("#user").val();
    var message = $("#MessageText").val();
    if (message.length > 0) {
        var groub = $("#groub").val();
        connection.invoke("SendMessage", user, groub, message).catch(function (err) {
            $("#CHAT").append(' <div class="UserMessage"> <div class="Information"</div><p>Time : ' + new Date().toISOString().slice(0, 10) + '</p><div class="Message"><h2>' + message + '</h2></div></div>');
            return console.error(err.toString());
        });
        event.preventDefault();
    }
    else {
        alert("Must write Mewssage")
    }
    
});