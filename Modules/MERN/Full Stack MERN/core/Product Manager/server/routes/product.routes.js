const productController = require('../controllers/product.controller');

module.exports = function(app) {
  app.post('/api/product', productController.create);
  app.get('/api/product', productController.findAll);
  app.get('/api/product/:id', productController.find);
  app.patch('/api/product/:id', productController.update);
  app.delete('/api/product/:id', productController.delete);
}
