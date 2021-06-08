
import React, { useState, useEffect } from 'react';
import Navigation from './Components/Common/Navigation';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { Home } from './Components/Home';
import { Categories } from './Components/Categories';
import Products from './Components/Products';
import Product from './Components/Product';
import Checkout from './Components/Checkout';
import CreateUser from './Components/CreateUser';


const BASE_URL = 'https://localhost:5001/api/';

function App() {
  const [cart, setCart] = useState([]);

  useEffect(() => {
    localStorage.setItem('cart', JSON.stringify(cart))
  }, [cart])

  const getCartTotal = () => {
    return cart.reduce(
      (sum, { quantity }) => sum + quantity,
      0
    );
  };

  return (
    <div id="wrapper">

      <Router>
        <Navigation
          baseURL={BASE_URL}
        />
        <div id="page-content-wrapper">
          <Switch>
            <Route exact path="/">
              <Home />
            </Route>
            <Route path="/products">
              <Products />
            </Route>
            <Route path="/categories">
              <Categories baseURL={BASE_URL} />
            </Route>
            <Route path="/product">
              <Product cart={cart} setCart={setCart} />
            </Route>
            <Route path="/checkout">
              <Checkout
                getCartTotal={getCartTotal}
                baseURL={BASE_URL}
              />
            </Route>
            <Route path="/create">
              <CreateUser
                baseURL={BASE_URL}
              />
            </Route>
          </Switch>
        </div>
      </Router>
    </div>
  )
}
export default App;