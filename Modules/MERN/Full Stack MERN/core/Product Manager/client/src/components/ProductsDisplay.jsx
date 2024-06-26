import React from 'react';

const ProductsDisplay = (props) => {

  return (
    <div>
      <h2>All products</h2>
      <ul>
        {props.products.map((product, i) => (
          <li key={i}><a href={'/product/'+ product._id}>{product.title}</a></li>
        ))}
      </ul>
    </div>
  )
}

export default ProductsDisplay
