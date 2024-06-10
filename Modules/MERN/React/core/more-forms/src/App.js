import React, { useState } from 'react'

import MyContext from './MyContext';
import './app.css'
import {Form} from './containers';

const App = () => {
  const [details, setDetails] = useState({
    fName: '',
    lName: '',
    email: '',
    pass: '',
    passConf: ''
  });

  return (
    <div className='app flex'>
      <div className='container flex column'>
        <MyContext.Provider value={{ details, setDetails }}>
          <Form />
        </MyContext.Provider>
      </div>
    </div>
  )
}

export default App
