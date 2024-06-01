import React, { useState, useEffect } from 'react';

import Header from './components/header/Header';
import NewTodo from './components/new-todo/NewTodo';
import DisplayTodos from './components/display-todos/DisplayTodos';
import './app.css';

export default function App() {
  const storedTodos = JSON.parse(localStorage.getItem('todos')) || [];
  const [todos, setTodos] = useState(storedTodos);

  useEffect(() => {
    localStorage.setItem('todos', JSON.stringify(todos));
  }, [todos]);

  const addNewTask = (task) => {
    setTodos([...todos, { id: Date.now(), ...task }]);
  };

  const toggleStatus = (check, id) => {
    const updatedTodos = todos.map(todo => {
      if (todo.id === id) {
        return { ...todo, checked: !check };
      }
      return todo;
    });
    setTodos(updatedTodos);
  };

  const deleteTodo = (id) => {
    setTodos(todos.filter(todo => todo.id !== id));
  };

  return (
    <div className='app'>
      <Header />
      <NewTodo addNewTask={addNewTask} />
      <p className="controls">Check the box for completed tasks<br />Completed tasks can be deleted by clicking on the trash can icon <br />!!! (The trash can icon only appears next to completed tasks) !!!</p>
      <DisplayTodos todos={todos} toggleStatus={toggleStatus} deleteTodo={deleteTodo} />
    </div>
  );
}
