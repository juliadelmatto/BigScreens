// Open and connect input socket
let socket = io();

// Listen for confirmation of connection
socket.on('connect', function () {
  console.log("Connected");
});

// Input field
let input;


function setup() {
  noCanvas();

  // Listen for changes to input field
  input = select('#input');
  input.input(inputChanged);


  // Listen for texts from partners
  socket.on('text', function (message) {
    let id = message.id;
    let txt = message.word;
    let p;
     try{
       p = select('#' + id).html(txt);
       p.elt.className = '';
       if(p.timeout) clearTimeout(p.timeout);
       p.timeout = setTimeout(()=>p.addClass('fade'), 100);
       console.log("SENDING CREATE BALL");
       connection.send("create-fire-texts");
     }
      // Otherwise craete a new on
      catch{
        p = createP(txt).id(id);
        p.addClass('fade');
        console.log("SENDING TEXTS ON THE BIG SCREENS");
        connection.send("create-fire-texts", input.value);
      }
  });

  // Remove disconnected users
  // Display "User left" message
  socket.on('leave room', function (id) {
    createP('(someone left...)').addClass('fade');
  });
}

// Send user input as they type it.
function inputChanged() {
  socket.emit('text', this.value());
}

// Listen for line breaks to clear input field
function keyPressed() {
  if(keyCode == ENTER) {
    input.value('');
  }
}

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
    // connect.send("something");
});
connection.onDisconnect(() => {
    console.log("DISCONNECTED");
});
connection.onError(err => {
    console.error("CONNECTION ERROR:", err);
});

connection.onOtherConnect((id, type) => {
    console.log(`OTHER CONNECTED: ${id}, ${type}`);
});
connection.onOtherDisconnect((id, type) => {
    console.log(`OTHER DISCONNECTED: ${id}, ${type}`);
});

////////////////////////////////////////
// UI
////////////////////////////////////////
// const button = document.getElementById("button");
// button.onclick = () => {
//     console.log("SENDING CREATE BALL");
//     connection.send("create-ball");
// };
