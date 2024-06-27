import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const Update = () => {
  const navigate = useNavigate();
  const { id } = useParams();
  const [product, setProduct] = useState({
    title: '',
    price: -1,
    description: ''
  });

  useEffect(() => {
    axios.get(`http://localhost:8000/api/product/${id}`)
      .then(res => {
        setProduct({ ...res.data });
      })
      .catch(err => {
        console.error('An error occurred: ', err);
      });
  }, [id]);

  const handleSubmit = e => {
    e.preventDefault();
    axios.patch(`http://localhost:8000/api/product/${id}`, product)
      .then(res => {
        console.log('Response: ', res)
        navigate('/product')
      })
      .catch(error => console.error('Error: ', error));
  };

  return (
    <center>
      <form className='flex column' onSubmit={handleSubmit}>
        <div className='input flex column'>
          <label>Title: </label>
          <input type='text' value={product.title} onChange={e => setProduct({ ...product, title: e.target.value })} />
        </div>
        <div className='input flex column'>
          <label>Price: </label>
          <input type='number' value={product.price} onChange={e => setProduct({ ...product, price: parseFloat(e.target.value) })}/>
        </div>
        <div className='input flex column'>
          <label>Description: </label>
          <input type='text' value={product.description} onChange={e => setProduct({ ...product, description: e.target.value })}/>
        </div>
        <input type='submit' />
      </form>
    </center>
  );
}

export default Update;