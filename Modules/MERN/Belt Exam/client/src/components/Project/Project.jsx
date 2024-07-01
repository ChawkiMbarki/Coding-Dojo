import React, { useContext } from 'react';
import axios from'axios';

import './project.css';
import { Btn } from '../../components';
import { ChangesContext } from '../../CreateContext';

const Project = ({ project }) => {

  const { changes, setChanges } = useContext(ChangesContext);
  
  const handleStart = (id) => {
    axios.patch(`http://localhost:8000/api/projects/${id}/update`, {status: 'In Progress'})
      .then(() => {
        console.log('Project In Progress')
        setChanges(changes + 1)
      })
      .catch(err => console.error(err))
  }
  
  const handleComplete = (id) => {
    axios.patch(`http://localhost:8000/api/projects/${id}/update`, {status: 'Completed'})
      .then(() => {
        console.log('Project Completed')
        setChanges(changes + 1)
      })
      .catch(err => console.error(err))
  }

  const handleDelete = (id) => {
    axios.delete(`http://localhost:8000/api/projects/${id}/delete`)
      .then(() => {
        console.log('Project Deleted Successfuly')
        setChanges(changes + 1)
      })
      .catch(err => console.error(err))
  }
  
  const currentDate = new Date();
  const dateObject = new Date(project.date);
  const mm = String(dateObject.getMonth() + 1).padStart(2, '0');
  const dd = String(dateObject.getDate()).padStart(2, '0');
  const yy = String(dateObject.getFullYear()).slice(-2);
  
  const formattedDate = `${mm}/${dd}/${yy}`;
  
  let button;
  switch (project.status) {
    case 'Pending':
      button = <Btn type={'button'} styl={'warning'} text={'Start Project'} onClick={() =>handleStart(project._id)} />;
      break;
    case 'In Progress':
      button = <Btn type={'button'} styl={'success'} text={'Move to Completed'} onClick={() =>handleComplete(project._id)} />;
      break;
    case 'Completed':
      button = <Btn type={'button'} styl={'danger'} text={'Remove Project'} onClick={() =>handleDelete(project._id)} />;
      break;
    default:
      button = null;
      break;
  }
  
  return (
    <li className='project'>
      <h4>{project.name}</h4>
      <p className={currentDate > dateObject ? 'deadline' : ''}><b>Due: </b>{formattedDate}</p>
      {button}
    </li>
  );
};

export default Project;
