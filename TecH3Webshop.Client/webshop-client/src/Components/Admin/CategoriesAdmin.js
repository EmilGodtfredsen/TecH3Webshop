import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Form, Button, Col } from 'react-bootstrap';
import BootstrapTable from "react-bootstrap-table-next";
import cellEditFactory from "react-bootstrap-table2-editor";
import _ from 'lodash';
import axios from 'axios';
import Utils from '../Common/Utils';



export class CategoriesAdmin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            newCategory: '',
            categories: '',
        }
    }
    componentDidUpdate(prevProps) {
        if(this.props.categories !== prevProps.categories){
            this.setState({
                categories: this.props.categories
            })
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
            newCategory: e.target.value,
        })
    }
    createNewCategory() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category',
            method: 'POST',
            data: {
                "name": this.state.newCategory,
            }
        }).then(response => {
            this.props.getCategories()
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error), 'danger')
        })
    }
    deleteClicked(id) {
        axios.defaults.baseURL = this.props.baseURL;
        if (window.confirm('Delete category?'))
            axios({
                url: '/category/' + id,
                method: 'DELETE',
            }).then(response => {
                this.props.getCategories()
            }).catch((error) => {
                this.handleAlert(Utils.handleAxiosError(error), 'danger')
            })

    }
    handleUpdate = (newValue, id) => {
        this.setState({
            newCategory: ''
        })
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category/' + id,
            method: 'PUT',
            data: {
                'name': newValue
            }
        }).then(response => {
            if (response.status >= 200 && response.status <= 404) {
                this.handleAlert(response.statusText, 'danger')
                this.props.getCategories()
            }
        }).catch(error => {
            this.handleAlert(error, 'danger')
        })
    }


    render() {
        if (this.state.categories === '' || this.state.categories === undefined) {
            return (
                <div className="text-muted"><FontAwesomeIcon icon="box-open" /> No data yet</div>
            )
        }
        else {
            const data = _.sortBy(this.state.categories, ['name'])
            const cellEdit = cellEditFactory({
                mode: 'click',
                blurToSave: true,
                beforeSaveCell: (oldValue, newValue, row, column) => {
                    if (oldValue !== newValue) {
                        this.handleUpdate(newValue, row.id)
                    }
                }
            })

            const columns = [{
                dataField: 'id',
                text: 'ID',
                hidden: true
            },
            {
                dataField: 'name',
                text: 'Category'
            },
            {
                dataField: "action",
                text: "",
                isDummyField: true,
                editable: false,
                align: 'right',
                formatter: (cellContent, row) => {
                    return (
                        <Button
                            size="sm"
                            variant="danger"
                            onClick={() => this.deleteClicked(row.id)
                            }
                        >
                            <FontAwesomeIcon icon="trash-alt" fixedWidth />
                        </Button>
                    )
                }
            }]

            return (

                <div>
                    <BootstrapTable
                        keyField="id"
                        data={data}
                        columns={columns}
                        cellEdit={cellEdit}
                        classes="table table-striped table-hover table-borderless"
                        headerWrapperClasses="title"
                        condensed
                        noDataIndication={() => <div className="text-muted"><FontAwesomeIcon icon="box-open" /> No data yet</div>}
                    />
                    <Form>
                        <Form.Row>
                            <Form.Group as={Col}>
                                <Form.Control
                                    value={this.state.newCategory}
                                    type="text"
                                    onChange={this.handleChange.bind(this)}
                                    placeholder="Enter New Category">
                                </Form.Control>
                            </Form.Group>
                            <Form.Group as={Col}>
                                <Button
                                    id="addPrefix"
                                    variant="success"
                                    onClick={() => this.createNewCategory()}
                                >
                                    Add <FontAwesomeIcon icon="plus" fixedWidth />
                                </Button>
                            </Form.Group>
                        </Form.Row>
                    </Form>
                </div>

            )

        }
    }
}

export default CategoriesAdmin
