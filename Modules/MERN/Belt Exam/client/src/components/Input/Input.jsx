import React from 'react';
import './input.css';

const Input = ({ type, ID, label, placeholder, value, onChange }) => {
  return (
    <div className='input flex'>
      <label htmlFor={ID}>{label}</label>
      <input type={type} id={ID} placeholder={placeholder} onChange={onChange} value={value} />
    </div>
  )
}

export default Input;
