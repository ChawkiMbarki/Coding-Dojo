import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { useParams, Link, useNavigate } from "react-router-dom";

const Details = (props) => {
  const [product, setProduct] = useState({})
  const { id } = useParams();
  const navigate = useNavigate();
  
  useEffect(() => {
      axios.get('http://localhost:8000/api/product/' +id)
        .then(res => setProduct(res.data))
        .catch(err => console.error(err));
    }, []);
  
    const handleDelete = (id) => {
      axios.delete(`http://localhost:8000/api/product/${id}`)
        .then( res => {
          console.log(res.data)
          navigate("/product")
        })
        .catch( error => console.error(error))
    }
  
  return (
    <div className='flex column details'>
      <h2>{product.title}</h2>
      <p><b>Price: </b>{product.price}</p>
      <p><b>Descrition: </b>{product.description}</p>
      <br />
      <div className="buttons flex">
        <button className='delete' onClick={() => handleDelete(product._id)}>Delete</button>
        <button className='update' onClick={() => navigate(`/product/${product._id}/edit`)}>Update</button>
      </div>
      <br />
      <Link className='link' to="/product/">Home</Link>
    </div>
  )
}

export default Details;
