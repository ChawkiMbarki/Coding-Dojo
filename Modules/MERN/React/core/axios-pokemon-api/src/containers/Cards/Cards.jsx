import React from 'react';

import Card from "../../components/Card/Card";
import './cards.css';

const Cards = (props) => {

  return (
    <ul className='flex'>
      {props.pokemons.map(pokemon => (
        <Card name={pokemon.name} />
      ))}
    </ul>
  );
}

export default Cards;
