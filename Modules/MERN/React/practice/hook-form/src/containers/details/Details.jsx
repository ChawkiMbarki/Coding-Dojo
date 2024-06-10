import React, {useContext} from 'react'

import './details.css'
import MyContext from '../../MyContext';

const Details = () => {
  const { details } = useContext(MyContext);

  return (
    <div className='details flex column'>
      <div className='flex'>
        <p>First Name : </p><p className='info'>{details.fName}</p>
      </div>
      <div className='flex'>
      <p>Last Name : </p><p className='info'>{details.lName}</p>
      </div>
      <div className='flex'>
        <p>Email : </p><p className='info'>{details.email}</p>
      </div>
      <div className='flex'>
        <p>Password : </p><p className='info'>{details.pass}</p>
      </div>
      <div className='flex'>
        <p>Confirm Password : </p><p className='info'>{details.passConf}</p>
      </div>
    </div>
  )
}

export default Details
