import React from 'react'
import { Image } from 'react-bootstrap';
import { useLocation } from 'react-router'
import { Link } from 'react-router-dom';

const Products = () => {
    let location = useLocation();
    const listProducts = location.state.products.map((item) =>
        <div className="card" key={item.id}> 
         <Link to={{ pathname: `/product/${item.id}`, state: item }} style={{textDecoration: "none"}}>           
         <div className="card_img">
                    {item.images.length === 0 ?
                        <Image src="/Image_coming_soon.png"/>
                        :
                        <Image src={item.images[0].imagePath} />
                    }
            </div>
            <div className="card_header">
                <h2>{item.name}</h2>
            </div>
            </Link>   
        </div>
    );

    return (
        <div className="main_content">
            {listProducts}
        </div>
    )
}

export default Products;
