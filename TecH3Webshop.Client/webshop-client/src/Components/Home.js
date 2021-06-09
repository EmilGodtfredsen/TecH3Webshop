import React from 'react';
//import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import { Image } from 'react-bootstrap';


export default function Home({ products }) {

  const listProducts = products.map((item, i) => {
    if (i < 6) {
      return (
        <div className="card" key={item.id}>
          <Link to={{ pathname: `/product/${item.id}`, state: item }} style={{ textDecoration: "none" }}>
            <div className="card_img">
              {item.images.length === 0 ?
                <Image src="/Image_coming_soon.png" />
                :
                <Image src={item.images[0].imagePath} />
              }
            </div>
            <div className="card_header">
              <h2>{item.name}</h2>
            </div>
          </Link>
        </div>
      )
    }
    return null;
  }
  );

  if (products === undefined) {
    return (
      <div>

      </div>
    )
  }
  else if (products.length === 0) {
    return (
      <div>

      </div>
    )
  } else {
    return (
      <div>
        <h1>Our most popular products</h1>
      
      <div className="main_content">
        {listProducts}
      </div>
      </div>
    )
  }
}


