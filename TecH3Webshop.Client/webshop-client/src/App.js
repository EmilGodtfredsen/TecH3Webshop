import React from 'react'
//import Utils from './Components/Common/Utils.js'
import Navigation from './Components/Common/Navigation';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

const BASE_URL = 'https://localhost:5001/api/';


export default class App extends React.Component {

  render() {
    return (
      <>
        <div className="nav-bar">
          <Navigation
            baseURL={BASE_URL}
          />
        </div>
        <div className="content">
          <Router>
              
          </Router>
        </div>

      </>

    )
  }
}