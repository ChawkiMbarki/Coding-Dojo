import React from 'react';
import { useNavigate } from 'react-router-dom';

import './search.css';

const Search = (props) => {
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    const category = e.target.category.value;
    const id = e.target.id.value;

    if (!id) {
      props.setError('you must set an ID');
    } else if(!category) {
      props.setError('You must select a category');
    }else {
      props.setError('');
      navigate(`/${category}/${id}`);
    }};

  return (
    <form className='search flex' onSubmit={handleSubmit}>
      <div className="input">
        <label htmlFor="search-bar">Search for: </label>
        <select name="category" id='search-bar'>
          <option value="people">People</option>
          <option value="planets">Planets</option>
          <option value="starships">Starships</option>
        </select>
      </div>
      
      <div className="input">
        <label htmlFor="id">ID: </label>
        <input type="number" id='id' name='id' />
      </div>

      <button type='submit'>Search</button>
    </form>
  )
}

export default Search
