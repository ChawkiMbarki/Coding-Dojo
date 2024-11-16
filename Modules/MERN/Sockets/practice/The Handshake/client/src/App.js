import "./App.css";

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { useState } from "react";

import Chat from "./components/Chat";
import Home from "./components/Home";

function App() {
  const [name, setName] = useState("");

  return (
    <Router>
      <Routes>
        <Route
          path="/"
          element={<Home name={name} setName={setName} />}
        />
        <Route
          path="/Chat"
          element={<Chat name={name} />}
        />
      </Routes>
    </Router>
  );
}

export default App;
