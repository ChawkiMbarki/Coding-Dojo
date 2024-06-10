import React, { useContext } from 'react';
import MyContext from '../../MyContext';
import './input.css';

const Input = (props) => {
  const { setDetails } = useContext(MyContext);

  const handleChange = (event) => {
    setDetails(prevDetails => ({
      ...prevDetails,
      [event.target.id]: event.target.value
    }));
  };

  return (
    <div className='row flex'>
      <label htmlFor={props.id}>{props.lable}</label>
      <input id={props.id} type={props.type} onChange={handleChange} />
    </div>
  );
};

export default Input;