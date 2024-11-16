import React, { useEffect, useState, useRef } from "react";
import { useNavigate } from "react-router-dom";
import io from "socket.io-client";
import "./Chat.css";

const Chat = ({ name }) => {
  const [socket] = useState(() => io("http://localhost:8000"));

  const [message, setMessage] = useState("");
  const [messages, setMessages] = useState([]);
  const [errors, setErrors] = useState([]);
  const [userId, setUserId] = useState("");
  const msgsEndRef = useRef(null);
  const navigate = useNavigate();

  useEffect(() => {
    msgsEndRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages]);

  useEffect(() => {
    if(!name.trim()) {
      navigate("/")
    }
    setUserId(name);
  }, [name]);

  const sendMessage = () => {
    setErrors([]);
    if (!message.trim()) {
      setErrors([...errors, "Please enter a valid message"]);
    } else {
      socket.emit("send_message", { message, userId });
      setMessage("");
    }
  };

  useEffect(() => {
    const handleMessage = (data) => setMessages(data.messages);
    socket.on("receive_message", handleMessage);

    return () => {
      socket.off("receive_message", handleMessage);
    };
  }, [socket]);

  return (
    <div className="container">
      <div className="msgs-container">
        <div className="msgs">
          {messages.map((msg, index) => (
            <div
              className={`msg ${msg.userId === userId ? "sent" : "received"}`}
              key={index}
            >
              <p className="identety">{msg.userId} Said</p>
              <p>{msg.message}</p>
            </div>
          ))}
          <div ref={msgsEndRef} />
        </div>
      </div>
      <div className="controls">
        <input
          type="text"
          placeholder="Message (Press 'Enter' to Send)"
          value={message}
          onChange={(e) => setMessage(e.target.value)}
          onKeyDown={(e) => {
            if (e.key === "Enter") {
              sendMessage()
            }
          }}
        />
        <button onClick={sendMessage}>Send Message</button>
      </div>
      <div className="errors">
        {errors.map((error, index) => (
          <p key={index} className="error">
            {error}
          </p>
        ))}
      </div>
    </div>
  );
};

export default Chat;
