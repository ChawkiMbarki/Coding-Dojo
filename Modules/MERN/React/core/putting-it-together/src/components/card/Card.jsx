import React, { useState } from 'react';

import './card.css'

const Card = (props) => {
  const { firstName, lastName, hairColor } = props.person;
  const [age, setAge] = useState(props.person.age);
  const [isAgeChanged, setIsAgeChanged] = useState(false);

  const onBirthday = () => {
    setIsAgeChanged(true);
    setAge(age + 1);
    setTimeout(() => {
      setIsAgeChanged(false);
    }, 500); // Reset the flag after 1 second
  };

  return (
    <li className='card'>
      <h3>{lastName}, {firstName}</h3>
      <p><b>Age:</b> <span className={isAgeChanged ? 'changed' : ''}>{age}</span></p>
      <p><b>Hair Color:</b> {hairColor}</p>
      <button type='button' onClick={onBirthday}>Birthday Button for {firstName} {lastName}</button>
    </li>
  );
};

export default Card;