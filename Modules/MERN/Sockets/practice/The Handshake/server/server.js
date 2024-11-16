const express = require("express");
const cors = require("cors");
const { Server } = require("socket.io");

let messages = [];

const app = express();
app.use(cors());

const PORT = 8000;
const server = app.listen(PORT, () => 
  console.log(`The server is all fired up on port ${PORT}`)
);

const io = new Server(server, {
  cors: {
    origin: "http://localhost:3000",
    methods: ["GET", "POST"],
  },
});

io.on("connection", (socket) => {
  console.log(`User connected: ${socket.id}`);
  io.emit("receive_message", { messages });
  
  socket.on("send_message", (data) => {
    messages = [...messages, { message: data.message, userId: data.userId }];
    console.log("messages: ",messages)
    io.emit("receive_message", { messages });
  });
});
