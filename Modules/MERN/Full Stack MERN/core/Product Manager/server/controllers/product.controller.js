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
  Product.findOne({ _id: req.params.id })
    .then( product => res.status(200).json(product ) )
    .catch( error => res.status(400).json('Error: ',error))
}

module.exports.update = (req, res) => {
  Product.findOneAndUpdate({ _id: req.params.id }, { ...req.body }, { new: true })
    .then( newProduct => res.status(200).json(newProduct ) )
    .catch( error => res.status(400).json('Error: ',error))
}

module.exports.delete = (req, res) => {
  Product.deleteOne({ _id: req.params.id })
    .then( product => res.status(200).json('Product has been deleted'))
    .catch( error => res.status(400).json('Error: ',error))
}
