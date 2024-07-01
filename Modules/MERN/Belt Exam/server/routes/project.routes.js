const projectController = require('../controllers/project.controller');

module.exports = function(app) {
  app.get('/api/projects', projectController.getAll);
  app.post('/api/projects/new', projectController.create);
  app.delete('/api/projects/:id/delete', projectController.delete);
  app.patch('/api/projects/:id/update', projectController.update);
};
