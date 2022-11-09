import React from 'react';
import { Navigate, useRoutes } from 'react-router-dom';
import Context from './components/Context/Context';
import Header from './components/Header/Header';
import Products from './components/Products/Products';
import Basket from './components/Basket/Basket';

function App() {
  let routes = useRoutes([
    { path: '/', element: <Products /> },
    { path: '/basket', element: <Basket /> },
    { path: '*', element: <Navigate to={'/'} /> },
  ]);


  return (
    <div className="App">
    <Context>
        <Header />
        {routes}
    </Context>
    </div>
  );
}

export default App;