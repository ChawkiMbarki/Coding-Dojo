import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

import { ChangesContext } from '../../CreateContext';
import { Input, Btn, ALink } from '../../components';
import './newProject.css';

const NewProject = () => {
  const { changes, setChanges, setErrors } = useContext(ChangesContext);
  const navigate = useNavigate();
  const [project, setProject] = useState({
    name: '',
    date: ''
  });

  const handleInputChange = (e) => {
    setProject(prevProject => ({
      ...prevProject,
      [e.target.id]: e.target.value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post('http://localhost:8000/api/projects/new', {
      name: project.name,
      date: project.date
    })
      .then(() => {
        console.log('Project Created Successfully');
        setChanges(changes + 1);
        setErrors([]);
        navigate('/');
      })
      .catch(err => {
        if (err.response && err.response.data && err.response.data.errors) {
          const errorResponse = err.response.data.errors;
          const errorArr = [];
          for (const key of Object.keys(errorResponse)) {
            errorArr.push(errorResponse[key].message);
          }
          setErrors(errorArr);
        } else {
          console.error('Error:', err);
          setErrors(['An error occurred. Please try again later.']);
        }
      });
  };

  return (
    <div className="form flex column center">
      <ALink className='link' path='/' text={'Back To Dashboard'} />
      <form onSubmit={handleSubmit} className='flex column center'>
        <Input 
          ID='name'
          type='text' 
          label='Name' 
          placeholder='Project Name Here...'
          onChange={handleInputChange}
        />
        <Input 
          ID='date'
          type='date' 
          label='Date' 
          onChange={handleInputChange}
        />
        <p>↓</p>
        <div className="btns flex">
          <Btn type='submit' styl={'success'} text={'Create (+)'}/>
        </div>
      </form>
    </div>
  );
};

export default NewProject;
