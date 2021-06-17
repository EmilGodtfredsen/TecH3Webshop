import React, { Component } from 'react'
import Utils from './Common/Utils';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Col, Row, Image, Button, Form } from 'react-bootstrap'
import axios from 'axios'
import { Redirect } from 'react-router-dom';
import date from 'date-and-time';
import ShowMessage from './Common/ShowMessage';

export default class Checkout extends Component {
    constructor(props) {
        super(props)
        this.state = {
            redirect: undefined,
            messageComment: '',
            messageVariant: '',
            cart: undefined,
            order: '',
            loginId: 1, //Only for testing purpose
        }
        this.handleChange = this.handleChange.bind(this);
    }
    componentDidMount() {
        this.setState({
            cart: JSON.parse(localStorage.getItem('cart')),
        }, () => this.parseJwt())
    }
    handleAlert = (comment, variant) => {
        this.setState({
            messageComment: comment,
            messageVariant: variant,
        })
        this.timer = setTimeout(() => {
            this.setState({
                messageComment: '',
                messageVariant: '',
            })
        }, 3000)
    }
    parseJwt() {
        console.log(this.props.token)
    }
    // ++++ Update amount of each item i cart ++++
    handleChange(i, e){ 
        let cart = [...this.state.cart];
        let item = {...cart[i]};
        if(e.target.valueAsNumber <= 0){
            cart.splice(i, 1);
        }
        else{
        item.amount = e.target.valueAsNumber;   
        cart[i] = item;
        }
        this.setState({
            cart: cart
        }, () => this.props.setCart(this.state.cart))
    }
    deleteItemInCart(i){
        let cart = [...this.state.cart];
        cart.splice(i, 1);
        if(window.confirm('Sure you wan´t to delete item(s) from cart?'))
        this.setState({
            cart: cart
        }, () => this.props.setCart(this.state.cart))
    }
    generateOrder() {
        if (this.props.token) {
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
        this.handleAlert('You´re not logged in! Please log in to checkout', 'warning')
        this.setState({
            redirect: '/login'
        })
    }
    createOrder() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/order',
            method: 'POST',
            data: this.state.order
        }).then(response => {
            if (response.status === 200) {
                let newCart = []
                this.setState({
                    messageComment: 'Order created!',
                    messageVariant: 'success'
                }, () => this.props.setCart(newCart))
            } else {
                this.setState({
                    messageComment: response.statusText,
                    messageVariant: 'danger'
                })
            }

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
                                    <Form>
                                        <Form.Group>
                                            <p>Product: {val.name} </p>
                                        </Form.Group>
                                        <Form.Group>
                                            <p>Quantity: 
                                                <Form.Control
                                                    type='number'
                                                    defaultValue={val.amount}
                                                    onChange={this.handleChange.bind(this, i)}>
                                                </Form.Control>             
                                            </p>
                                        </Form.Group>
                                        <Form.Group>
                                            <p>Price: {val.price} ,-</p>
                                        </Form.Group>
                                        <Button variant='danger' onClick={() => this.deleteItemInCart(i)}> <FontAwesomeIcon icon='trash-alt' /> Delete</Button>
                                    </Form>
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
    showContent() {
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
    render() {
        if (this.state.messageComment) {
            return (
                <ShowMessage
                    comment={this.state.messageComment}
                    variant={this.state.messageVariant}
                />
            )
        } else if (this.state.redirect) {
            return (
                <Redirect to={this.state.redirect} />
            )
        } else {
            return (
                this.showContent()
            )
        }


    }
}