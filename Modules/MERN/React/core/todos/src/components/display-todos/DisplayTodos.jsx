import React from 'react';
import './displayTodos.css';

const DisplayTodos = (props) => {
  return (
    <ul className="todos" id="todos">
      {props.todos.map((todo) => (
        <li key={todo.id} className={todo.checked ? 'todo checked' : 'todo'}>
          {todo.checked 
            ? <input type="checkbox" className='status' onClick={(e) => props.toggleStatus(todo.checked, todo.id)} checked/>
            : <input type="checkbox" className='status' onClick={(e) => props.toggleStatus(todo.checked, todo.id)}/>
          }
          <p>{todo.value}</p>
          <div className={todo.checked ? 'dragRemoveContainer display' : 'dragRemoveContainer hide'}>
            <i className='fa-solid fa-trash-can' onClick={(e) => props.deleteTodo(todo.id)} />
          </div>
        </li>
      ))}
    </ul>
  );
};

export default DisplayTodos;

