////////////////////////////////////////
// CONNECTION
////////////////////////////////////////
const connection = new Connection(
    "Balls",
    "player",
    "https://bigscreens.herokuapp.com"
);

connection.onConnect(() => {
    console.log("CONNECTED");
});
connection.onDisconnect(() => {
    console.log("DISCONNECTED");
});
connection.onError(err => {
    console.error("CONNECTION ERROR:", err);
});

connection.on("text", function(data) {
  console.log("got text", data);
});

connection.on("somethingelse", function(data) {
  // do something in unity
});

connection.onOtherConnect((id, type) => {
    console.log(`OTHER CONNECTED: ${id}, ${type}`);
});
connection.onOtherDisconnect((id, type) => {
    console.log(`OTHER DISCONNECTED: ${id}, ${type}`);
});

// connection.send('text', this.value());

////////////////////////////////////////
// UI
////////////////////////////////////////
const button = document.getElementById("button");
button.onclick = () => {
    console.log("SENDING CREATE BALL");
    connection.send("create-ball");
};
