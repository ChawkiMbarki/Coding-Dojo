import React from 'react';

import './card.css'

const Card = (props) => {
  const { firstName, lastName, age, hairColor } = props.person;

  return (
    <li className='card'>
      <h3>{lastName}, {firstName}</h3>
      <p><b>Age:</b> {age}</p>
      <p><b>Hair Color:</b> {hairColor}</p>
      <button type='button'>Birthday Button for {firstName} {lastName}</button>
    </li>
  );
};

export default Card;