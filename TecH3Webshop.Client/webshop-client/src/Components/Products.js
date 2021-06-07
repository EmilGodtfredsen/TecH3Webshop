import React from 'react'
import { Col, Container, ListGroup, Row } from 'react-bootstrap';
import { useLocation } from 'react-router'
import { Link } from 'react-router-dom';

const Products = () => {
    let location = useLocation();
    if (location.state.products === undefined || location.state.products.length === 0) {
        return (
            <h5 className="title"><p className="badge badge-dark bg-secondary">No Products</p></h5>
        )
    } else {
        return (
            <Container>

                {location.state.products.map((val, i) => {
                    return (
                        <div key={i}>

                            <Col>
                                <Row>
                                    <Col>
                                        <ListGroup.Item as={Link} action to={{ pathname: `/product/${val.id}`, state: val }}>
                                            {val.name}
                                        </ListGroup.Item>
                                    </Col>
                                </Row>
                            </Col>

                        </div>
                    )
                })}
            </Container>
        )
    }
}

export default Products;
