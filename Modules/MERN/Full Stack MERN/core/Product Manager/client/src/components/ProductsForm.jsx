import React, { useState } from 'react';
import axios from 'axios';

const ProductsForm = (props) => {
  
  const [product, setProduct] = useState({
    title: '',
    price: -1,
    description: ''
  })

  const handleSubmit = e => {
    e.preventDefault();
    axios.post('http://localhost:8000/api/product', product)
      .then(res => {
        props.setStatus(true)
        console.log('Response: ',res)
      })
      .catch(error => console.error('Error :', error))
  }
  
  return (
    <form className='flex column' onSubmit={ handleSubmit }>
      <div className='input flex column'>
        <label>Title: </label>
        <input type='text' onChange={ e => setProduct({ ...product, title: e.target.value }) } />
      </div>
      <div className='input flex column'>
        <label>Price: </label>
        <input type='number' onChange={ e => setProduct({ ...product, price: e.target.value }) } />
      </div>
      <div className='input flex column'>
        <label>Description: </label>
        <input type='text' onChange={ e => setProduct({ ...product, description: e.target.value }) } />
      </div>
      <input type='submit' />
    </form>
  )
}

export default ProductsForm
