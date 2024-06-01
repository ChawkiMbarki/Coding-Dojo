import React from 'react'
import './newTodo.css'

const NewTodo = (props) => {

  const addTodo = (e) => {
    if (e.key == "Enter"){
        const todo_value = e.target.value;
        props.addNewTask({'value': todo_value, 'checked': false})
    }
  }

  return (
    <div className='new-todo'>
      <input type="text" id="todo" placeholder="ENTER what you wanna do?"  onKeyUp={addTodo}></input>
    </div>
  )
}

export default NewTodo
