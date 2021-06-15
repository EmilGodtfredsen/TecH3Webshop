import React, { Component } from 'react';
import axios from 'axios';
import { Modal, Button, Form, Row, Col, Image } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


export class ProductImagesAdmin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            imagePath: undefined,
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
    handleChange = e => {
        this.setState({
            imagePath: e.target.value,
        })
    }
    addImageToProduct() {
        this.props.product.images.push({ 'imagePath': this.state.imagePath, 'productId': this.props.product.id })
        this.setState({
            tempObj: this.props.product,
        }, () => this.handleUpdate(this.state.tempObj, this.props.product.id))
    }
    handleUpdate(obj, id) {
        axios.defaults.baseURL = this.props.baseURL;
        this.setState({
            newObj: obj
        }, () => axios({
            url: '/product/' + id,
            method: 'PUT',
            data: obj
        }).then(response => {
            if (response.status >= 200 && response.status <= 404) {
                this.handleAlert(response.statusText, 'success')
                this.props.getProducts()
            }
        }).catch(error => {
            this.handleAlert(error, 'danger')
        }))

    }
    handleCloseModal = () => {
        this.setState({
            images: undefined,
        })
        this.props.closeModal()
    }
    deleteImage(index){
        this.props.product.images.splice(index, 1)
        console.log(this.props.product)
        this.setState({
            tempObj: this.props.product
        }, () => this.handleUpdate(this.state.tempObj, this.props.product.id))
        console.log(this.props.product.images)
        
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
                            <FontAwesomeIcon icon='images' fixedWidth />
                        </h5>
                    </Modal.Header>
                    <Modal.Body>
                        {this.props.product.images === undefined || this.props.product.images.length === 0 ?
                            <div className="text-muted"><FontAwesomeIcon icon="box-open" /> No images</div>
                            :
                            <div>
                                {this.props.product.images.map((img, i) => {
                                    return (
                                        <Row key={i}>
                                            <div style={{ width: "171px", height: "180px"}}>
                                                <Image
                                                    src={img.imagePath}
                                                    thumbnail={true}
                                                >
                                                </Image>
                                            </div>
                                            <Button
                                                variant="danger"
                                                type="submit"
                                                onClick={() => this.deleteImage(i)}
                                            >
                                                Delete <FontAwesomeIcon icon="trash-alt" fixedWidth />
                                            </Button>
                                        </Row>
                                    )
                                })}
                            </div>
                        }
                        <Form className='mt-3'>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Control
                                        value={this.state.newCategory}
                                        type="text"
                                        onChange={this.handleChange.bind(this)}
                                        placeholder="Insert image path">
                                    </Form.Control>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Button
                                        variant="success"
                                        onClick={() => this.addImageToProduct()}
                                    >
                                        Add <FontAwesomeIcon icon="plus" fixedWidth />
                                    </Button>
                                </Form.Group>
                            </Form.Row>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>

                        <Button
                            variant='dark'
                        >
                            <FontAwesomeIcon icon='check' fixedWidth /> Done
                                </Button>
                        <Button
                            variant='danger'
                            onClick={this.handleCloseModal.bind(this)}

                        >
                            <FontAwesomeIcon icon='times' fixedWidth /> Cancel
                                </Button>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
}

export default ProductImagesAdmin
