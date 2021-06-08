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
        }

    }

    handleChange = e => {
        this.setState({
            [e.target.name]: e.target.value,
          }, () => this.validateInput())
    }

    handleClick(){
        console.log(this.state.email)
        console.log(this.state.password)
        console.log(this.state.confirmPassword)
    }



    render() {
        return (
            <div>
                <Row>
                    <Col className="col-6">
                        <Form>
                            <Form.Group>
                                <Form.Control name='email' type="email" placeholder="Enter email"  onChange={this.handleChange.bind()}/>
                            </Form.Group>
                            <Form.Group>
                                <Form.Control name='password' type="password" placeholder="Password"  onChange={this.handleChange.bind(this)}/>
                            </Form.Group>
                            <Form.Group>
                                <Form.Control name='confirmPassword' type="password" placeholder="Confirm Password"  onChange={this.handleChange.bind(this)}/>
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
