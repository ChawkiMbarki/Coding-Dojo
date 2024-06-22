const Joke = require('../models/joke.model')

module.exports.createJoke = (req, res) => {
  Joke.create( req.body)
    .then(newJoke => res.status(200).json({ joke: newJoke }))
    .catch(error => res.status(400).json(error))
};

module.exports.findJoke = (req, res) => {
  Joke.findOne({ _id: req.params.id })
    .then(joke => res.status(200).json({ joke: joke }))
    .catch(error => res.status(400).json(error))
}

module.exports.findAllJokes = (req, res) => {
  Joke.find()
  .then(jokes => res.status(200).json({jokes: jokes}))
  .catch(error => res.status(400).json(error))
}

module.exports.updateJoke = (req, res) => {
  Joke.findOneAndUpdate({ _id: req.params.id }, req.body, {new: true, runValidators: true})
    .then(updatedJoke => res.status(200).json({ joke: updatedJoke }))
    .catch(error => res.status(400).json(error))
};

module.exports.deleteJoke = (req, res) => {
  Joke.deleteOne({ _id: req.params.id })
    .then(joke => res.status(200).json({ message: 'Joke deleted successfully' }))
    .catch(error => res.status(400).json(error))
}
