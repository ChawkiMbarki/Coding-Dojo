import React from 'react'

const TodosList = () => (
  <>
    <li>Learn React</li>
    <li>Climn Mt. Everest</li>
    <li>Run a marathon</li>
    <li>feed the dogs</li>
  </>
);

const Todos = () => {
  return (
    <div>
      <h2>Things I need to do:</h2>
      <ul>
        <TodosList />
      </ul>
    </div>
  )
}

export default Todos
