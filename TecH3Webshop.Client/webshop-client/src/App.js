import React from 'react'
//import Utils from './Components/Common/Utils.js'
import Navigation from './Components/Common/Navigation';


const BASE_URL = '';


export default class App extends React.Component {

  render() {
    return (

      <>
          <title>{this.title}</title>
          <html className="" />
          <body className="bg-secondary" />
        <Navigation
          baseURL={BASE_URL}
        />
      </>

    )
  }
}