import React, { Component } from 'react'
import axios from 'axios';
import { Modal, Button, Form, Alert } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class LoginModal extends Component {
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            email: '',
            password: '',
        }
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
    handleChange = e => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }
    validateInput() {
        var userCred = { "userName": '', "password": '' }

        if (this.state.email !== '' && ((/^[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/).test(this.state.email))) {
            userCred.userName = this.state.email
            if (this.state.password !== '') {
                userCred.password = this.state.password
            } else {
                this.handleAlert('Please insert password', 'danger')
            }
            this.setState({
                userCredentials: userCred
            }, () => this.handleLogin())
        } else {
            this.handleAlert('E-mail not valid', 'danger')
        }
    }
    handleLogin(){
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/login/Authenticate',
            method: 'POST',
            data: this.state.userCredentials
        }).then(response => {
            console.log(response)
            if (response.status >= 200 && response.status <= 404) {
                this.handleAlert('Login successfull!', 'success')
                this.props.setToken(response.data)
            }
        }).catch(error => {
            this.handleAlert(error, 'danger')
        })
    }
    render() {
        return (
            <div>
                <Modal
                    show={this.props.show}
                    size="lg"
                    backdrop="static"
                    keyboard={false}
                    animation={false}
                >
                    <Modal.Header>
                        <h5>
                            <FontAwesomeIcon icon='lock' fixedWidth />
                        </h5>
                    </Modal.Header>

                    <Modal.Body>
                        {this.state.messageComment ?
                            <Alert variant={this.state.messageVariant}>
                                <FontAwesomeIcon icon="info-circle" fixedWidth /> {this.state.messageComment}
                            </Alert>
                            :
                            <Form>

                                <h3>Log in</h3>

                                <Form.Group>
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control onChange={this.handleChange.bind(this)} name="email" type="email" placeholder="Enter email" />
                                </Form.Group>

                                <Form.Group>
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control onChange={this.handleChange.bind(this)} name="password" type="password" className="form-control" placeholder="Enter password" />
                                </Form.Group>

                                <Button
                                    variant="dark"
                                    onClick={() => this.validateInput()}
                                >
                                    Sign in
                                </Button>
                                <p className="forgot-password text-right">
                                    Forgot <a href="/login">password?</a>
                                </p>
                            </Form>
                        }
                    </Modal.Body>
                    <Modal.Footer>
                        <Link
                            to="/"
                            className="btn btn-dark"
                            variant='danger'
                        >
                            <FontAwesomeIcon icon='times' fixedWidth /> Cancel
                        </Link>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
}

export default LoginModal
