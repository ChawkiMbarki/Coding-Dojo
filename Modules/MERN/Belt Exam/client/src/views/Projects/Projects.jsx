import React, { useContext, useEffect, useState } from 'react'
import axios from 'axios';

import './projects.css'
import { ChangesContext } from '../../CreateContext';
import  { Project, ALink } from '../../components';

const Projects = () => {

  const { changes } = useContext(ChangesContext);
  const [projects, setProjects] = useState([]);

  const [pendingProjects, setPendingProjects] = useState([]);
  const [inProgressProjects, setInProgressProjects] = useState([]);
  const [completedProjects, setCompletedProjects] = useState([]);
  
  useEffect(() => {
    let sortedProjects = [];
    axios.get('http://localhost:8000/api/projects')
      .then(res => {
        sortedProjects = res.data;
        sortedProjects.sort((project1, project2) => {
          const date1 = new Date(project1.date);
          const date2 = new Date(project2.date);
          return date1 - date2;
        });
        setProjects(sortedProjects);
      })
      .catch(err => console.log('error: ', err));
  }, [changes]);
  
  useEffect(() => {
    const pending = [];
    const inProgress = [];
    const completed = [];
  
    projects.forEach(project => {
      switch(project.status){
        case 'Pending': pending.push(project); break;
        case 'In Progress': inProgress.push(project); break;
        case 'Completed': completed.push(project); break;
        default: break;
      }
    });
  
    setPendingProjects(pending);
    setInProgressProjects(inProgress);
    setCompletedProjects(completed);
  }, [projects]);

  return (
    <div className='Projects flex column center'>
      <ALink path='/projects/new' text={'Add New Project'} />
      <div className="projectsContainer flex justify">
  
        <div className="pending projectsWrapper">
          <h3 className="title">Backlog</h3>
          <ul className="projects-list flex column align">
            {pendingProjects.map((project, i) => (
              <Project key={i} project={project} />
            ))}
          </ul>
        </div>
  
        <div className="inProgress projectsWrapper">
          <h3 className="title">In Progress</h3>
          <ul className="projects-list flex column align">
            {inProgressProjects.map((project, i) => (
                <Project key={i} project={project} />
            ))}
          </ul>
        </div>
  
        <div className="completed projectsWrapper">
          <h3 className="title">Compelted</h3>
          <ul className="projects-list flex column align">
            {completedProjects.map((project, i) => (
              <Project key={i} project={project} />
            ))}
          </ul>
        </div>
      </div>
    </div>
  )
}

export default Projects
