import React from 'react'

import './error.css';

const Error = (props) => {
  return (
    <div className='error flex'>
      {props.error}
    </div>
  )
}

export default Error
