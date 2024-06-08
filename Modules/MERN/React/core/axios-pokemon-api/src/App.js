import React, { useState } from 'react';
import axios from 'axios';

import { Cards } from './containers';
import './app.css'

const App = () => {
  const [pokemons, setPokemons] = useState([]);

  const fetchAllPokemons = async () => {
    let url = "https://pokeapi.co/api/v2/pokemon?limit=807";
    try {
      const response = await axios.get(url);
      setPokemons(response.data.results);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className='app flex column'>
      <button onClick={fetchAllPokemons} disabled={loading}>
      </button>
      <Cards pokemons={pokemons} />
    </div>
  )
}

export default App
