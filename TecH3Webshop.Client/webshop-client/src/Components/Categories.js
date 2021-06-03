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
    componentDidMount(){
        this.getCategories()
    }
    getCategories(){
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category',
            method: 'GET',
        }).then(response => {
           console.log(response.data)
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error), 'danger')
        })
    }
    renderCategories(){

    }
    render() {
        return (
            <>
                <Row>
                    <Col>
                        <div className="text-uppercase title">
                            <div className="p-2 font-weight-bold d-flex"> Categories
                                <FontAwesomeIcon icon='cog' size='lg' className='ml-auto' fixedWidth />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col className='col-6'>
                        <ListGroup>
                            <ListGroup.Item action>Cras justo odio</ListGroup.Item>
                            <ListGroup.Item action>Dapibus ac facilisis in</ListGroup.Item>
                            <ListGroup.Item action>Morbi leo risus</ListGroup.Item>
                            <ListGroup.Item action>Porta ac consectetur ac</ListGroup.Item>
                        </ListGroup>
                    </Col>
                </Row>
            </>
        );
    }
}
