import React, { Component } from 'react'
import Utils from './Common/Utils';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Col, Row, Image, Button } from 'react-bootstrap'
import axios from 'axios'
import date from 'date-and-time';

export default class Checkout extends Component {
    constructor(props) {
        super(props)
        this.state = {
            cart: undefined,
            order: '',
            loginId: 1, //Only for testing purpose
        }
    }
    componentDidMount() {
        this.setState({
            cart: JSON.parse(localStorage.getItem('cart'))
        })
    }
    handleAlert = (comment, variant) => {
        this.setState({
            messageComment: comment,
            messageVariant: variant,
        })
        this.timer = setTimeout(() => {
            this.setState({
                comment: '',
                variant: '',
            })
        }, 3000)
    }
    generateOrder() {
        var listObj =
            this.state.cart.map((line) => {
                return (
                    { "quantity": line.amount, "price": line.price, "productId": line.id }
                )
            })
        const now = new Date();
        this.setState({
            order: {
                "loginId": this.state.loginId,
                "orderDate": date.format(now, 'YYYY-MM-DD HH:mm:ss'),
                "orderDetails": listObj
            }
        }, () => this.createOrder())
    }
    createOrder() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/order',
            method: 'POST',
            data: this.state.order
        }).then(response => {
            console.log(response)
            
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error), 'danger')
        })
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
                                    <p>Price: {val.price} ,-</p>
                                </Col>
                                <Col className="col-6">
                                    {val.images.length === 0 ?
                                        <Image src="/Image_coming_soon.png" thumbnail={true}></Image>
                                        :
                                        val.images.map((image, i) => {
                                            return (
                                                <Image key={i} src={image.imagePath} thumbnail={true}></Image>
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