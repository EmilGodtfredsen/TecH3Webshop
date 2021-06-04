import React from 'react'
//import Utils from './Components/Common/Utils.js'
import Navigation from './Components/Common/Navigation';


const BASE_URL = 'https://localhost:5001/api/';


export default class App extends React.Component {

  render() {
    return (
      <>
        <Navigation
          baseURL={BASE_URL}
        />
      </>

    )
  }
}