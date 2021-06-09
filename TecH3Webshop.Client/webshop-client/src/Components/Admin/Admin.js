import React, { Component } from 'react';
import axios from 'axios';
import { Card, Col, Row } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Utils from '../Common/Utils';
import CategoriesAdmin from './CategoriesAdmin';

export class Admin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            products: undefined,
            categories: undefined,
            logins: undefined,
            orders: undefined,
        }
    }
    componentDidMount(){
        this.getAllProducts()
        // this.getAllCategories()
        // this.getAllLogins()
        // this.getAllOrders()
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
    getAllProducts(){
        axios.defaults.baseURL = this.props.baseURL;
        axios({
          url: '/category',
          method: 'GET',
        }).then(response => {
          this.setState({
              categories: response.data
          })
        }).catch((error) => {
          this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }

    render() {
        return (
            <div>
                <Row className='mb-3'>
                    <Col className='col-6'>
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
                                />
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col className='col-6'>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Logins
                                          <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>

                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
                <Row>
                    <Col className='col-6'>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Products
                                          <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>

                            </Card.Body>
                        </Card>
                    </Col>
                    <Col className='col-6'>
                        <Card>
                            <Card.Header className="text-uppercase title">
                                <div className="p-2 font-weight-bold d-flex"> Orders
                                          <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                                </div>
                            </Card.Header>
                            <Card.Body>

                            </Card.Body>
                        </Card>
                    </Col>
                </Row>

            </div>
        )
    }
}

export default Admin