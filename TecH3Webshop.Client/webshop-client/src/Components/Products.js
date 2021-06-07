import React from 'react'
import { Col, Container, ListGroup, Row } from 'react-bootstrap';
import { useLocation } from 'react-router'
import { Link } from 'react-router-dom';

const Products = () => {

    let location = useLocation();
    const listProducts = location.state.products.map((item) =>
        <div className="card" key={item.id}>
            <div className="card_img">
                {item.images.length === 0 ?
                    <img></img>
                    :
                    <img src={item.images[0].imagePath} />
                }
            </div>
            <div className="card_header">
                <h2>{item.name}</h2>
                <p className="price">{item.price}<span>$</span></p>
                <div className="btn">Add to cart</div>
            </div>
        </div>
    );

    return (
        <div className="main_content">
            {listProducts}
        </div>
    )
    // if (location.state.products === undefined || location.state.products.length === 0) {
    //     return (
    //         <h5 className="title"><p className="badge badge-dark bg-secondary">No Products</p></h5>
    //     )
    // } else {
    //     return (
    //         <Container>

    //             {location.state.products.map((val, i) => {
    //                 return (
    //                     <div key={i}>

    //                         <Col>
    //                             <Row>
    //                                 <Col>
    //                                     <ListGroup.Item as={Link} action to={{ pathname: `/product/${val.id}`, state: val }}>
    //                                         {val.name}
    //                                     </ListGroup.Item>
    //                                 </Col>
    //                             </Row>
    //                         </Col>

    //                     </div>
    //                 )
    //             })}
    //         </Container>
    //     )
    // }
}

export default Products;
