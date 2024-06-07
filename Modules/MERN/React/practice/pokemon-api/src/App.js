import React, { useState, useEffect } from 'react';

import { Cards } from './containers';
import './app.css'

const App = () => {

  const [pokemons, setPokemons] = useState([]);

  const fetchAllPokemons = async () => {
    let url = "https://pokeapi.co/api/v2/pokemon?limit=807";
    try {
      const response = await fetch(url);
      const data = await response.json();
      setPokemons(data.results); 
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className='app flex column'>
      <button onClick={fetchAllPokemons}>Fetch Pokemon</button>
      <Cards pokemons={pokemons} />
    </div>
  )
}

export default App
