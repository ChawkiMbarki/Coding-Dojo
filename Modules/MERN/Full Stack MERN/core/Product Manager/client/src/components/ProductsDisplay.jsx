import React from 'react';
import { Link, useNavigate } from 'react-router-dom'
import axios from 'axios';

const ProductsDisplay = (props) => {

  const navigate = useNavigate()

  const handleDelete = (id) => {
    axios.delete(`http://localhost:8000/api/product/${id}`)
      .then( res => console.log(res.data))
      .catch( error => console.error(error))
    
    props.setStatus(true)
  }

  return (
    <div>
      <h2>All products</h2>
      <ul className='flex column'>
        {props.products.map((product, i) => (
          <li key={i} className='flex'>
            <Link className='link'  to={'/product/'+ product._id}>{product.title}</Link>
            <div className="buttons flex">
              <button className='delete' onClick={() => handleDelete(product._id)}>Delete</button>
              <button className='update' onClick={() => navigate(`/product/${product._id}/edit`)}>Update</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  )
}

export default ProductsDisplay
