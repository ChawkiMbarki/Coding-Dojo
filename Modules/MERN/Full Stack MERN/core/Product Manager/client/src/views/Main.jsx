import React, { useState, useEffect } from 'react';

import axios from 'axios';

import ProductForm from '../components/ProductsForm';
import ProductsDisplay from '../components/ProductsDisplay';

const Main = () => {
  const [products, setProducts] = useState([])
  const [loaded, setLoaded] = useState(false)
  const [status, setStatus] = useState(false)

  useEffect(() => {
    axios.get("http://localhost:8000/api/product")
      .then(res => {
        setProducts(res.data.products)
        setLoaded(true)
      })
      .catch(error => console.error(error))
    setStatus(false)
  }
  , [status])

  return (
    <div>
      <center>
        <h1>Product Manager</h1><br />
        <ProductForm setStatus={setStatus} />
        <br /><br />
        <hr />
        <br />
        {loaded && <ProductsDisplay setStatus={setStatus} products={ products } />}
        
      </center>
    </div>
  )
}

export default Main
