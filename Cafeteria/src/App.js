import React, { useState, useEffect  } from 'react';
import './App.css';
import ProductsContainer from './components/Products/ProductsContainer';
import axios from 'axios';

function App() {
  const [products, setProducts] = useState();
  const [isLoading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      const headers = {
          'Content-Type': 'application/json'
      };

      const response = await axios.get('http://localhost:5000/api/Product/products', { headers: headers });
      setProducts(response.data)
      setLoading(false);
    }
    fetchData()
  }, [])


  return (
    <div className="App">
      <ProductsContainer products={products} isLoading={isLoading}>
        
      </ProductsContainer>
    </div>
  );
}

export default App;