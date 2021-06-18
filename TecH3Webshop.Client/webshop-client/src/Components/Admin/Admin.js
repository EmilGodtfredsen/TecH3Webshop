import React, { Component } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router';
import { Card, Col, Row } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Utils from '../Common/Utils';
import CategoriesAdmin from './CategoriesAdmin';
import { ProductsAdmin } from './ProductsAdmin';
import OrdersAdmin from './OrdersAdmin';
import LoginsAdmin from './LoginsAdmin';

export class Admin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            categories: undefined,
            products: undefined,
            logins: undefined,
            orders: undefined,
            brands: undefined,
            productImagesId: '',
            product: '',
            redirect: '',
        }

    }
    componentDidMount() {
        console.log(this.props.token)
        if (this.props.token) {
            this.getAllProducts()
            this.getAllCategories()
            this.getAllLogins()
            this.getAllOrders()
        }
        else{
        this.setState({
            redirect: '/login'
        })
    }
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
    getAllCategories() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category',
            method: 'GET',
        }).then(response => {
            this.setState({
                categories: response.data
            }, () => this.props.setCategories(response.data))
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    getAllProducts() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/product',
            method: 'GET',
        }).then(response => {
            this.setState({
                products: response.data
            }, () => this.props.setProducts(response.data))
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    getAllOrders() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/order',
            method: 'GET',
        }).then(response => {
            this.setState({
                orders: response.data
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    getAllLogins() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/login',
            method: 'GET',
           headers: { Authorization: `Bearer ${this.props.token}` }
        }).then(response => {
            console.log(response.data)
            this.setState({
                logins: response.data
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    getProductImages(id) {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/product/' + id,
            method: 'GET',
        }).then(response => {
            this.setState({
                product: response.data
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    render() {
        if (this.state.redirect) {
            return (
                <Redirect to={this.state.redirect} />
            )
        }
        return (
            <div>
                <Row className='mb-3'>
                    <Col>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Categories
                                    <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>
                                <CategoriesAdmin
                                    baseURL={this.props.baseURL}
                                    categories={this.state.categories}
                                    getCategories={this.getAllCategories.bind(this)}
                                />
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
                <Row className='mb-3'>
                    <Col>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Products
                                    <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>
                                <ProductsAdmin
                                    baseURL={this.props.baseURL}
                                    products={this.state.products}
                                    getProducts={this.getAllProducts.bind(this)}
                                    getCategories={this.getAllCategories.bind(this)}
                                    getProductImages={this.getProductImages.bind(this)}
                                    brands={this.state.brands}
                                    categories={this.state.categories}
                                    product={this.state.product}
                                />
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
                <Row className='mb-3'>
                    <Col>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Logins
                                    <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>
                                <LoginsAdmin
                                    baseURL={this.props.baseURL}
                                    logins={this.state.logins}
                                    getLogins={this.getAllLogins.bind(this)}
                                />
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
                <Row className='mb-3'>
                    <Col>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Orders
                                    <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>
                                <OrdersAdmin
                                    baseURL={this.props.baseURL}
                                    orders={this.state.orders}
                                    getOrders={this.getAllOrders.bind(this)}
                                />
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>

            </div>
        )
    }
}

export default Admin
