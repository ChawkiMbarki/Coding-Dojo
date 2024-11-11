import React, { useEffect } from "react";
import io from "socket.io-client";

const socket = io("http://localhost:8000");

const Chat = () => {
    useEffect(() => {
        socket.on("welcome", (message) => {
            console.log(message);
        });

        return () => socket.off("welcome");
    }, []);

    return <div>Welcome to the Chat</div>;
};

export default Chat;
