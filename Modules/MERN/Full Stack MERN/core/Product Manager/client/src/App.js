import React from 'react'
import { Routes, Route } from 'react-router-dom';

import Main from './views/Main'
import Details from './views/Details';

const App = () => {
  return (
    <div className="App">
    <Routes>
      <Route element={<Main />} path='/product/' />
      <Route element={<Details />} path='/product/:id' />
    </Routes>
  </div>
  )
}

export default App
