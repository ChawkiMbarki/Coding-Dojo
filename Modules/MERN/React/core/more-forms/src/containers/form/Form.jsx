import React, {useContext} from 'react'

import './form.css'
import MyContext from '../../MyContext';
import {Input, Error} from '../../components';

const Form = (props) => {
  const { details } = useContext(MyContext);

  return (
    <form className='flex column'>
      <Input id='fName' lable='First Name' type='text' />
      <Error error={details.fName !== '' && details.fName.length < 2 ? 'First Name must be at least 2 characters' : ''} />
      <Input id='lName' lable='Last Name' type='text' />
      <Error error={details.lName !== '' && details.lName.length < 2 ? 'Last Name must be at least 2 characters' : ''} />
      <Input id='email' lable='Email' type='email' />
      <Error error={details.email !== '' && details.email.length < 2 ? 'Email must be at least 2 characters' : ''} />
      <Input id='pass' lable='Password' type='password' />
      <Error error={details.pass !== '' && details.pass.length < 8 ? 'Password must be at least 8 characters' : ''} />
      <Input id='passConf' lable='Confirm Password' type='password' />
      <Error error={details.passConf !== '' && details.passConf !== details.pass ? 'Passwords must be match' : ''} />
    </form>
  )
}

export default Form
