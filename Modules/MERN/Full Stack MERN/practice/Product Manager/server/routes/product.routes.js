const productController = require('../controllers/product.controller');

module.exports = function(app) {
  app.post('/api/product', productController.create)
}
