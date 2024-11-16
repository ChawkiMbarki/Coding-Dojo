import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Home.css";

const Home = ({ name, setName }) => {
  const [errors, setErrors] = useState([]);
  const navigate = useNavigate();

  const handleStartChat = () => {
    if (!name.trim()) {
      setErrors(["Please enter a valid name"]);
    } else {
      setErrors([]);
      navigate("/Chat");
    }
  };

  return (
    <div className="intro">
      <h1>Your Name</h1>
      <input
        type="text"
        name="name"
        id="name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <button onClick={handleStartChat}>Start Chatting</button>
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

export default Home;
