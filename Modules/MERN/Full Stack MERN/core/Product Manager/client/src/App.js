import React from 'react'
import { Routes, Route } from 'react-router-dom';

import Main from './views/Main'
import Details from './views/Details';
import Update from './views/Update';

const App = () => {
  return (
    <div className="App">
    <Routes>
      <Route element={<Main />} path='/product/' />
      <Route element={<Details />} path='/product/:id' />
      <Route element={<Update />} path='/product/:id/edit' />
    </Routes>
  </div>
  )
}

export default App
