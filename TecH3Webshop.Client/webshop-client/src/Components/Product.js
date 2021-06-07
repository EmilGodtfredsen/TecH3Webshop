import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { Col, Row, Image, Button } from 'react-bootstrap';
import { useLocation } from 'react-router';


export default function Product({ setCart, cart }) {
    let location = useLocation();

    const addToCart = (product) => {
        let newCart = [...cart];
        let itemInCart = newCart.find(
            (item) => product.name === item.name
        );
        if (itemInCart) {
            itemInCart.amount++;
        } else {
            itemInCart = {
                ...product,
                amount: 1,
            };
            newCart.push(itemInCart);
        }
        setCart(newCart);
    };


  
    if (location.state === undefined) {
        return (
            <h5 className="title"><p className="badge badge-dark bg-secondary">No Product</p></h5>
        )
    } else {
        return (
            <>
                <Row className="mb-5">
                    <Col className="col-3">
                        <p>Product: {location.state.name}</p>
                        <p>Brand: {location.state.brand.name}</p>
                        <p>Price: {location.state.price} ,-</p>
                    </Col>
                    <Col className="col-6">
                        {location.state.images.length === 0 ?
                            <Image src="/Image_coming_soon.png" thumbnail={true}></Image>
                            :
                            location.state.images.map((image, i) => {
                                return (
                                    <Image src={image}></Image>
                                )
                            })
                        }
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Button onClick={() => addToCart(location.state)} variant='dark'>
                            <FontAwesomeIcon icon='shopping-cart' fixedWidth /> Add to Cart
                    </Button>
                    </Col>
                </Row>



            </>

        )

    }
}
