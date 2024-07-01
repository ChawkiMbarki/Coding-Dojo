import React from 'react';
import './btn.css';

const Btn = ({ type, styl, text, onClick }) => {

  return (
    <div className='flex btn'>
      <button type={type} className={styl} onClick={onClick}>
        {text}
      </button>
    </div>
  );
}

export default Btn;
