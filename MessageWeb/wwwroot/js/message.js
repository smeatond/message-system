"use strict";
var allmessages = "/api/message";

var connection = new signalR.HubConnectionBuilder().withUrl("/message").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, datetime) {
    var p = document.createElement("p");
    document.getElementById("messagesList").appendChild(p);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    p.innerHTML = `${message} <span class="user">${user}</span> <span>${datetime}</span>`;
});

connection.start().then(async function () {
    const response = await fetch(allmessages);
    var data = await response.json();
    data.forEach((ele) => {
        var p = document.createElement("p");
        document.getElementById("messagesList").appendChild(p);
        p.innerHTML = `Message: ${ele.messageText} <br /> User: ${ele.username} </br>${ele.dateTime}`;
    });
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});