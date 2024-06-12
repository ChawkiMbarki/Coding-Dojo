import React, { useState } from 'react';
import { Routes, Route } from 'react-router-dom';

import { Search, Details, Error } from './components';
import './app.css';

const App = () => {
  const [error, setError] = useState('');

  return (
    <div className='app flex column'>
      <Search setError={setError} />
      {error
        ? (<Error error={error} />)
        : (<Routes><Route path="/:category/:id" element={<Details setError={setError} />} /></Routes>)
      }
    </div>
  );
};

export default App;
