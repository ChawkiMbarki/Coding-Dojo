import React from 'react'
import { Route, Routes } from 'react-router-dom';

import './app.css'

import { ChangesProvider } from './CreateContext'
import { Header } from './components'
import { Projects, NewProject, Errs } from './views';

const App = () => {
  return (
    <ChangesProvider>
      <div className='flex column center'>
          <div className='container'>
            <Header />
            <Routes>
              <Route path='/' element={<Projects />} />
              <Route path='/projects/new' element={<NewProject />} />
            </Routes>
          </div>
          <Errs />
        </div>
    </ChangesProvider>
  )
}

export default App
