import React, { useContext } from 'react'

import './errsContainer.css'
import { Errr } from '../../components'
import { ChangesContext } from '../../CreateContext';

const ErrsContainer = () => {

  const { errors } = useContext(ChangesContext);

  if (errors.length > 0) {
    return (
      <div className='errsContainer container flex column center'>
        <h2>Errors</h2>
        <ul className='flex column center'>
          {errors.map((error, index) => <Errr key={index} error={error} />)}
        </ul>
      </div>
  )}
}

export default ErrsContainer
