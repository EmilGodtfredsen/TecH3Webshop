import React from 'react'
import { Col, ListGroup, Row } from 'react-bootstrap';
import { useLocation } from 'react-router'

const Products = () => {
    let location = useLocation();
    if (location.state.products === undefined || location.state.products.length === 0) {
        return (
            <h5 className="title"><p className="badge badge-dark bg-secondary">No Products</p></h5>
        )
    } else {
        return (
            <ListGroup>
                {location.state.products.map((val, i) => {
                    return (
                        <Row>
                            <Col className="col-6">
                                <ListGroup.Item action key={i}>
                                    {val.name}
                                </ListGroup.Item>
                            </Col>
                        </Row>
                    )
                })}
            </ListGroup>
        )
    }
}

export default Products;
