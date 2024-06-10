import React from 'react'

import './form.css'
import {Input} from '../../components';

const Form = (props) => {


  return (
    <form className='flex column'>
      <Input id='fName' lable='First Name' type='text' />
      <Input id='lName' lable='Last Name' type='text' />
      <Input id='email' lable='Email' type='email' />
      <Input id='pass' lable='Password' type='password' />
      <Input id='passConf' lable='Confirm Password' type='password' />
    </form>
  )
}

export default Form
