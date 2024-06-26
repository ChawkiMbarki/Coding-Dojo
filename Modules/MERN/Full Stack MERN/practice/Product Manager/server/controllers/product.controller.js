const Product = require("../models/product.model")

module.exports.create = (req, res) => {
  const { title, price, description } = req.body;
  
  Product.create({ title, price, description })
    .then( newProduct => res.status(200).json({ product: newProduct }) )
    .catch( error => res.status(400).json('Error: ',error))
}
