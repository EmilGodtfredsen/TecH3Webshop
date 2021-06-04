import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Row, Col, ListGroup } from 'react-bootstrap';

export class Products extends Component {
    static displayName = Products.products;
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            products: undefined,
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
        this.setState({
            products: this.props.products,
        })
    }
    renderProducts() {
        if (this.state.products === undefined) {
            return (
                <p className='text-center'>
                    <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
                </p>
            )
        } else if (this.state.products.length === 0) {
            return (
                <h5 className="title"><p className="badge badge-dark bg-secondary">No Products</p></h5>
            )
        } else {
            return (
                <ListGroup>
                    {this.state.products.map((val, i) => {
                        return (
                            <ListGroup.Item key={i} action>
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
                            <div className="p-2 font-weight-bold d-flex"> Products
                        <FontAwesomeIcon icon='anchor' size='lg' className='ml-auto' fixedWidth />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col className='col-6'>
                        {this.renderProducts()}

                    </Col>
                </Row>
            </>
        )
    }
}