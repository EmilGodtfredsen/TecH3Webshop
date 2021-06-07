import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Col, Row, Image, Button } from 'react-bootstrap'

export default class Checkout extends Component {
    constructor(props) {
        super(props)
        this.state = {
            cart: undefined,
        }
    }
    componentDidMount() {
        this.setState({
            cart: JSON.parse(localStorage.getItem('cart'))
        })

    }
    generateOrder() {
        console.log(this.state.cart)
    }
    renderCart() {
        return (
            this.state.cart.map((val, i) => {
                return (
                    <Row key={i}>
                        <Col className="col-6" >
                            <Row className="mb-5">
                                <Col className="col-3">
                                    <p>Product: {val.name} </p>
                                    <p>Quantity: {val.amount}</p>
                                    <p>Total Price: {val.price * val.amount} ,-</p>
                                </Col>
                                <Col className="col-6">
                                    {val.images.length === 0 ?
                                        <Image src="/Image_coming_soon.png" thumbnail={true}></Image>
                                        :
                                        val.images.map((image, i) => {
                                            return (
                                                <Image src={image}></Image>
                                            )
                                        })
                                    }
                                </Col>
                            </Row>
                        </Col>
                    </Row>
                )
            }
            ))
    }
    render() {
        if (this.state.cart === undefined) {
            return (
                <p className='text-center'>
                    <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
                </p>
            )
        }
        else if (this.state.cart.length === 0) {
            return (
                <h5 className="title"><p className="badge badge-dark bg-secondary">Empty cart</p></h5>
            )

        } else {
            return (
                <div>
                    {this.renderCart()}
                    <Button onClick={() => this.generateOrder()} variant="success">
                        <FontAwesomeIcon icon="shopping-cart" fixedWidth /> Checkout
                    </Button>
                </div>
            )

        }
    }
}