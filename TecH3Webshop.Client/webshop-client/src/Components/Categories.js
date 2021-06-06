import React, { Component } from 'react';
import axios from 'axios';
import Utils from './Common/Utils';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Row, Col, ListGroup } from 'react-bootstrap';


export class Categories extends Component {
    static displayName = Categories.categories;
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            categories: undefined,
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
    componentDidMount() {
        this.getCategories()
    }
    getCategories() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category',
            method: 'GET',
        }).then(response => {
            this.setState({
                categories: response.data,
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error), 'danger')
        })
    }
    showProducts = (products) => {
        this.props.handleCallback(products, 'products')
    }
    renderCategories() {
        if (this.state.categories === undefined) {
            return (
                <p className='text-center'>
                    <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
                </p>
            )
        } else if (this.state.categories.length === 0) {
            return (
                <h5 className="title"><p className="badge badge-dark bg-secondary">No Categories</p></h5>
            )
        } else {
            return (
                <ListGroup>
                    {this.state.categories.map((val, i) => {
                        return(
                        <ListGroup.Item key={i} action onClick={() => this.showProducts(val.products)}>
                            {val.name}
                        </ListGroup.Item>
                        )
                    })}
                </ListGroup>
            )
        }
    }
    render() {
        return (
            <>
                <Row>
                    <Col>
                        <div className="text-uppercase title">
                            <div className="p-2 font-weight-bold d-flex"> Categories
                                <FontAwesomeIcon icon='cat' size='lg' className='ml-auto' fixedWidth />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col className='col-6'>
                        {this.renderCategories()}

                    </Col>
                </Row>
            </>
        );
    }
}