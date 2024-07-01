const Project = require("../models/project.model");

module.exports.create = (req, res) => {
  const { name, date } = req.body;
  Project.create({ name, date, status:'Pending' })
    .then(newProject => res.status(200).json(newProject))
    .catch(error => res.status(400).json({ errors: error.errors }));
};

module.exports.getAll = (req, res) => {
  Project.find()
    .then(projects => res.status(200).json(projects))
    .catch(error => res.status(400).json({ errors: error.errors }));
};

module.exports.update = (req, res) => {
  Project.findOneAndUpdate({ _id: req.params.id }, { ...req.body }, { new: true, runValidators: true })
    .then(updatedProject => res.status(200).json(updatedProject))
    .catch(error => res.status(400).json({ errors: error.errors }));
};

module.exports.delete = (req, res) => {
  Project.deleteOne({ _id: req.params.id })
    .then(() => res.status(200).json('Project has been deleted'))
    .catch(error => res.status(400).json({ errors: error.errors }));
};
