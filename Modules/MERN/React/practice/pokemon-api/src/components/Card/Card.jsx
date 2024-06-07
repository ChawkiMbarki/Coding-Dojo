import React from 'react'

import './card.css'

const Card = (props) => {

  return (
    <li className='flex'>
      <h3>{props.name}</h3>
    </li>
  )
}

export default Card
