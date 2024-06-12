import React from 'react';

import './error.css';

const Error = (props) => {
  return (
    <p className='error flex'>
      ! {props.error} !
    </p>
  )
}

export default Error
