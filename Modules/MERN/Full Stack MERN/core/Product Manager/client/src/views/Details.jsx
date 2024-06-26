import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { useParams } from "react-router-dom";

const Details = (props) => {
  const [product, setProduct] = useState({})
  const { id } = useParams();
  
  useEffect(() => {
      axios.get('http://localhost:8000/api/product/' +id)
        .then(res => setProduct(res.data[0]))
        .catch(err => console.error(err));
    }, []);
    
  return (
    <div>
        <center>
            <h2>{product.title}</h2>
            <p><b>Price: </b>{product.price}</p>
            <p><b>Descrition: </b>{product.description}</p>
        </center>
    </div>
  )
}

export default Details;
