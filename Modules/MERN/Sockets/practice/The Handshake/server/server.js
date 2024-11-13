const express = require("express");
const app = express();
const cors = require("cors");
const { Server } = require("socket.io");

app.use(cors());

const server = app.listen(8000, () =>
  console.log("The server is all fired up on port 8000")
);

const io = new Server(server, {
  cors: {
    origin: "http://localhost:3000",
    methods: ["GET", "POST"]
  }
});

io.on("connection", (socket) => {
  console.log("Nice to meet you. (shake hand)");
  socket.emit("welcome", "Welcome to the chat!");
});
