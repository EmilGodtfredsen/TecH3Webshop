import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Button, Table } from 'react-bootstrap';
import axios from 'axios';
import Utils from '../Common/Utils';
import OrderDetailsModal from './OrderDetailsModal';
import ShowMessage from '../Common/ShowMessage';

export class OrdersAdmin extends Component {
    constructor(props){
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            order: '',
            showOrderDetailsModal: false,
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
    getOrderDetails(id){
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/order/' + id,
            method: 'GET',
        }).then(response => {
            console.log(response.data)
            this.setState({
                order: response.data,
                showOrderDetailsModal: true,
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    deleteOrder(id){
        if(window.confirm('Are you sure you wan´t to delete this order?')){
            this.handleDeleteOrder(id)
        }
    }
    handleDeleteOrder(id){
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/order/' + id,
            method: 'DELETE',
        }).then(response => {
            this.props.getOrders()
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    closeModal() {
        this.setState({
            showOrderDetailsModal: false,
        })
    }
    renderAuthorTable = () => {
        if (this.props.orders === undefined) {
          return (
            <p className='text-center'>
              <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
            </p>
          )
        } else if (this.props.orders.length === 0) {
          return (
            <h5 className="title"><p className="badge badge-dark bg-secondary">No Orders</p></h5>
          )
        } else {
          return (
            <Table className="table table-striped table-hover table-borderless rounded sortable">
              <thead className="thead-dark">
                <tr>
                  <th scope="col" className='text-nowrap'>Order Date</th>
                  <th scope="col" className='text-nowrap'></th>
                  <th scope="col" className='text-nowrap'></th>
                </tr>
              </thead>
              <tbody id="tableRow">
                {this.props.orders.map((order, i) => {
    
                  return (
                    <tr key={i} className='font-weight-bold'>
                      <td>
                        {order.orderDate}
                      </td>
                      <td><Button onClick={() => this.getOrderDetails(order.id)} variant='dark'><FontAwesomeIcon icon='book' fixedWidth /> Show Order Details</Button></td>
                      <td>
                        <Button onClick={() => this.deleteOrder(order.id)} variant='danger'><FontAwesomeIcon icon='trash-alt' fixedWidth /> Delete Order</Button>
                      </td>
                    </tr>
                  )
                })}
              </tbody>
    
            </Table>
          )
        }
      }
    render() {
        if(this.state.messageComment){
            return(
                <ShowMessage
                message={this.state.messageComment}
                variant={this.state.messageVariant}
                />
            )
        }
        return (
            <div>
                <OrderDetailsModal
                show={this.state.showOrderDetailsModal}
                order={this.state.order}
                closeModal={this.closeModal.bind(this)}
                />
                {this.renderAuthorTable()}
            </div>
        )
    }
}

export default OrdersAdmin
