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

    handleChange = e => {
        this.setState({
            [e.target.name]: e.target.value,
          })
    }

    handleClick(){
        if(!this.state.password.length < 6){
            console.log('Password must be atleast 6 chars long!')
        }
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
