import './App.css';

import { Card } from './components';

function App() {
  const people = [
    {'firstName': 'Chawki', 'lastName': 'Mbarki', 'age': 21, 'hairColor': 'black'},
    {'firstName': 'Ahmed', 'lastName': 'Hajji', 'age': 22, 'hairColor': 'brown'},
    {'firstName': 'Hassen', 'lastName': 'Mbarki', 'age': 25, 'hairColor': 'black'}
  ]
  return (
    <div className="App">
      <ul className='people'>
        {people.map((person) => (
          <Card person={person} />
        ))}
      </ul>
    </div>
  );
}

export default App;
