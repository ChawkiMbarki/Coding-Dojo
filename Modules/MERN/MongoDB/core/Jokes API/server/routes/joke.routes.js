const JokeController = require('../controllers/joke.controller');

module.exports = app => {
  app.post('/api/jokes', JokeController.createJoke);
  app.get('/api/jokes/:id', JokeController.findJoke);
  app.get('/api/jokes', JokeController.findAllJokes);
  app.patch('/api/jokes/:id', JokeController.updateJoke);
  app.delete('/api/jokes/:id', JokeController.deleteJoke);
}
