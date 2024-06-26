const Product = require("../models/product.model")

module.exports.create = (req, res) => {
  const { title, price, description } = req.body;
  
  Product.create({ title, price, description })
    .then( newProduct => res.status(200).json({ product: newProduct }) )
    .catch( error => res.status(400).json('Error: ',error))
}

module.exports.findAll = (req, res) => {
  Product.find()
    .then( allProducts => res.status(200).json({ products: allProducts }) )
    .catch( error => res.status(400).json('Error: ',error))
}

module.exports.find = (req, res) => {
  Product.find({ _id: req.params.id })
    .then( product => res.status(200).json(product ) )
    .catch( error => res.status(400).json('Error: ',error))
}
