import React, { Component } from 'react';
import { Modal, Button, Table, Image } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


export class OrderDetailsModal extends Component {
    constructor(props) {
        super(props)
        this.state = {

        }
    }

    handleCloseModal = () => {
        this.props.closeModal()
    }
    renderDetails() {
        const orderDetails = this.props.order.orderDetails;
        const order = this.props.order;
        return (
            <div>
                <h5>Customer Email: {order.login.email}</h5>
                <p>Order Date: {order.orderDate}</p>
                <p>Firstname: {order.login.firstName}</p>
                <p>Lastname: {order.login.lastName}</p>
                <p>Shipping address: {order.login.addresses}</p>

                <Table className="table table-striped table-hover table-borderless rounded sortable">
                    <thead className="thead-dark">
                        <tr>
                            <th scope="col" className='text-nowrap'>Product Name</th>
                            <th scope="col" className='text-nowrap'></th>
                            <th scope="col" className='text-nowrap'>Category</th>
                            <th scope="col" className='text-nowrap'>Brand</th>
                            <th scope="col" className='text-nowrap'>Quantity</th>
                            <th scope="col" className='text-nowrap'>Price</th>
                        </tr>
                    </thead>
                    <tbody id="tableRow">
                        {orderDetails.map((orderDetail, i) => {
                            return (
                                <tr key={i} className='font-weight-bold'>
                                    <td>
                                        {orderDetail.product.name}
                                    </td>
                                    <td><div>
                                        {orderDetail.product.images[0] === undefined ?
                                            <Image style={{ width: "40px", height: "40px" }} src='/Image_coming_soon.png' />
                                            :
                                            <Image style={{ width: "40px", height: "40px" }} src={orderDetail.product.images[0].imagePath} />
                                        }
                                    </div>
                                    </td>
                                    <td>
                                        {orderDetail.product.category.name}
                                    </td>
                                    <td>
                                        {orderDetail.product.brand.name}
                                    </td>
                                    <td>
                                        {orderDetail.quantity}
                                    </td>
                                    <td>
                                        {orderDetail.product.price}
                                    </td>

                                </tr>
                            )
                        })}
                    </tbody>

                </Table>
            </div>
        )
    }
    render() {
        const orderDetails = this.props.order.orderDetails
        return (
            <div>
                <Modal
                    show={this.props.show}
                    size="xl"
                    backdrop="static"
                    keyboard={false}
                    animation={false}
                >
                    <Modal.Header>
                        <h5>
                            <FontAwesomeIcon icon='list' fixedWidth />
                        </h5>
                    </Modal.Header>
                    <Modal.Body>
                        {orderDetails === undefined || orderDetails.length === 0 ?
                            <h5 className="title"><p className="badge badge-dark bg-secondary">No Orders</p></h5>
                            :
                            this.renderDetails()
                        }
                    </Modal.Body>
                    <Modal.Footer>
                        <Button
                            variant='dark'
                            onClick={this.handleCloseModal.bind(this)}

                        >
                            <FontAwesomeIcon icon='times' fixedWidth /> Close
                        </Button>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
}

export default OrderDetailsModal
