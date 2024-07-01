import React, { useContext } from 'react';
import { Link } from 'react-router-dom';

import './alink.css';
import { ChangesContext } from '../../CreateContext';

const ALink = ({ text, path }) => {

  const { setErrors } = useContext(ChangesContext);

  return (
    <div className='link flex align'>
      <Link to={ path } onClick={() => setErrors([])} >{ text }</Link>
    </div>
  )
}

export default ALink;
