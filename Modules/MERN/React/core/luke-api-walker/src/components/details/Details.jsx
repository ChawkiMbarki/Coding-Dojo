import React, { useEffect, useState } from 'react';
import { useParams } from "react-router";
import axios from 'axios';

import './details.css';

const Details = () => {
  const { category , id } = useParams();
  const [info, setInfo] = useState({})

  useEffect(() => {
    axios.get(`https://swapi.dev/api/${category}/${id}`)
      .then(response=>{
        setInfo(response.data)
    })
  }, [id, category])

  return (
    <div className='details flex column'>
      <h2>{info.name}</h2>
      <br />
      <p><b>Height:</b> {info.height} cm</p>
      <p><b>Mass:</b> {info.mass} kg</p>
      <p><b>Hair Color:</b> {info.hair_color}</p>
      <p><b>Skin Color:</b> {info.skin_color}</p>
    </div>
  )
}

export default Details
