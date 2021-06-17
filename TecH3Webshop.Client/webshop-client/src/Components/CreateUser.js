import axios from 'axios';
import React, { Component } from 'react'
import { Form, Button, Row, Col } from 'react-bootstrap'

export default class CreateUser extends Component {
    static displayName = CreateUser.create;
    constructor(props) {
        super(props)
        this.state = {
            email: '',
            password: '',
            confirmPassword: '',
            newLogin: '',
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
            }, () => this.redirect())
        }, 3000)
    }
    handleChange = e => {
        this.setState({
            [e.target.name]: e.target.value,
        })
    }
    handleClick() {
        if (this.state.email !== '' && (!(/^[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/).test(this.state.email))) {
            console.log('Not a valid e-mail!')
        }
        if(this.state.password.length < 6){
            console.log('Password must be atleast 6 chars long!')
        }
        if(this.state.password !== this.state.confirmPassword){
            console.log('Confirm password must be the same!')
        }
        this.setState({
            newLogin: {
                email: this.state.email,
                password: this.state.password,
                firstName: this.state.firstName,
                lastName: this.state.lastName,
                role: 0
            }
        })
    }
    createUser(){
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/login',
            method: 'POST',
            data: this.state.newLogin
        }).then(response => {
            if (response.status >= 200 && response.status <= 400) {
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
                <Row>
                    <Col className="col-6">
                        <Form>
                            <Form.Group>
                                <Form.Control name='email' type="email" placeholder="Enter email" onChange={this.handleChange.bind()} />
                            </Form.Group>
                            <Form.Group>
                                <Form.Control name='password' type="password" placeholder="Password" onChange={this.handleChange.bind(this)} />
                            </Form.Group>
                            <Form.Group>
                                <Form.Control name='confirmPassword' type="password" placeholder="Confirm Password" onChange={this.handleChange.bind(this)} />
                            </Form.Group>
                            <Button
                                variant="primary"
                                onClick={() => this.handleClick()}
                            >
                                Submit
                            </Button>
                        </Form>
                    </Col>
                </Row>

            </div>
        )
    }
}
