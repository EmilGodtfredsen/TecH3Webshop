import React from 'react'
//import Utils from './Components/Common/Utils.js'
import Navigation from './Components/Common/Navigation';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { Home } from './Components/Home';
import { Categories } from './Components/Categories';
import  Products from './Components/Products';

const BASE_URL = 'https://localhost:5001/api/';


export default class App extends React.Component {

  render() {
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
                <Products baseURL={BASE_URL} />
              </Route>
              <Route path="/categories">
                <Categories baseURL={BASE_URL} />
              </Route>
            </Switch>


          </div>
        </Router>

      </div>
    )
  }
}