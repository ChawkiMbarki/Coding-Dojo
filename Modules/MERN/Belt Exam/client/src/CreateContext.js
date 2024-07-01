import React, { createContext, useState } from 'react';

const ChangesContext = createContext();

const ChangesProvider  = ({ children }) => {
  const [changes, setChanges] = useState(0);
  const [errors, setErrors] = useState([]); 

  return (
    <ChangesContext.Provider value={{ changes, setChanges, errors, setErrors }}>
      {children}
    </ChangesContext.Provider>
  );
};

export { ChangesContext, ChangesProvider  };
