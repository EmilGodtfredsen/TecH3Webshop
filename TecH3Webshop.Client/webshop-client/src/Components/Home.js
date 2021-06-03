import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (

      <div className="text-uppercase title">
        <div className="p-2 font-weight-bold d-flex"> Welcome to this webshop
              <FontAwesomeIcon icon='door-open' size='lg' className='ml-auto' fixedWidth />
        </div>
      </div>

    );
  }
}
