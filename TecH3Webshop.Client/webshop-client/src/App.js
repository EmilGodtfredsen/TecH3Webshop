
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Navigation from './Components/Common/Navigation';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './Components/Home';
import Products from './Components/Products';
import Product from './Components/Product';
import Checkout from './Components/Checkout';
import CreateUser from './Components/CreateUser';
import Admin from './Components/Admin/Admin';

const BASE_URL = 'https://localhost:5001/api/';


function App() {
  const [cart, setCart] = useState([]);
  const [categories, setCategories] = useState([]);
  const [products, setProducts] = useState([]);


  useEffect(() => {
    localStorage.setItem('cart', JSON.stringify(cart));
  }, [cart])

  const getCartTotal = () => {
    return cart.reduce(
      (sum, { quantity }) => sum + quantity,
      0
    );
  };

  useEffect(() => {
    // ++++ GET ALL CATEGORIES ++++
    axios.defaults.baseURL = BASE_URL;
    axios({
      url: '/category',
      method: 'GET',
    }).then(response => {
      setCategories(response.data)
    }).catch((error) => {
      console.log(error)
    })
    // ++++ GET ALL PRODUCTS ++++
    axios.defaults.baseURL = BASE_URL;
    axios({
      url: '/product',
      method: 'GET',
    }).then(response => {
      setProducts(response.data)
    }).catch((error) => {
      console.log(error)
    })

  }, [products]);

  return (
    <div id="wrapper">
      <Router>
        <Navigation
          baseURL={BASE_URL}
          categories={categories}
        />
        <div id="page-content-wrapper">
          <Switch>
            <Route exact path="/">
              <Home
                products={products}
              />
            </Route>
            <Route path="/products">
              <Products />
            </Route>
            <Route path="/product">
              <Product cart={cart} setCart={setCart} />
            </Route>
            <Route path="/checkout">
              <Checkout
                getCartTotal={getCartTotal}
                baseURL={BASE_URL}
                setCart={setCart}
                cart={cart}
              />
            </Route>
            <Route path="/create">
              <CreateUser
                baseURL={BASE_URL}
              />
            </Route>
            <Route path="/admin">
              <Admin 
                baseURL={BASE_URL}
                setCategories={setCategories}
                setProducts={setProducts}
              />
            </Route>
          </Switch>
        </div>
      </Router>
    </div>
  )
}
export default App;