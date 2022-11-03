import React, { useState, useEffect  } from 'react';
import axios from 'axios';
import Card from './Card';

function Products(props) {
    const [products, setProducts] = useState();
    const [isLoading, setLoading] = useState(true);

    useEffect(() => {
      const fetchData = async () => {
        const headers = {
            'Content-Type': 'application/json'
        };

        const response = await axios.get('http://localhost:5000/api/Product/products', { headers: headers });
        console.log(response);
        setProducts(response.data)
        setLoading(false);
      }
      fetchData()
    }, [])

    if(isLoading) { return <div> Loading ... </div> };
    return (
        <div className="products">
            <h1>Products</h1>
            <div className="products-container">
                {products.map((product) => (
                <Card
                    key={product.id}
                    id={product.id}
                    name={product.name}
                    image={product.image}
                    quantity={product.quantity}
                    price={product.price}
                />
                ))}
            </div>
        </div>
    );
}

export default Products;