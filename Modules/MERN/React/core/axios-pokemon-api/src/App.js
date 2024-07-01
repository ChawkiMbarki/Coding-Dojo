import React, { useState } from 'react';
import axios from 'axios';

import { Cards } from './containers';
import './app.css'

const App = () => {
  const [pokemons, setPokemons] = useState([]);
  const [loading, setLoading] = useState(false);

  const fetchAllPokemons = async () => {
    let url = "https://pokeapi.co/api/v2/pokemon?limit=807";
    setLoading(true);
    try {
      const response = await axios.get(url);
      setPokemons(response.data.results);
    } catch (err) {
      console.log(err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className='app flex column'>
      <button onClick={fetchAllPokemons} disabled={loading}>
        {loading ? 'Loading...' : 'Fetch Pokemon'}
      </button>
      <Cards pokemons={pokemons} />
    </div>
  )
}

export default App
