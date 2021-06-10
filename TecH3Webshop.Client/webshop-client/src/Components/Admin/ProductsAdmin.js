import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Button, Dropdown } from 'react-bootstrap';
import BootstrapTable from "react-bootstrap-table-next";
import cellEditFactory from "react-bootstrap-table2-editor";
import _ from 'lodash';
import axios from 'axios';
import Utils from '../Common/Utils';


export class ProductsAdmin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            messageComment: '',
            messageVariant: '',
            productId: '',
            name: '',
            description: '',
            price: '',
            images: '',
            categories: '',
            tempObj: '',
        }
    }

    componentDidMount() {
        this.getAllBrands()
        this.getAllCategories()
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
    getAllBrands() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/brand',
            method: 'GET',
        }).then(response => {
            this.setState({
                brands: response.data
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }
    getAllCategories() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category',
            method: 'GET',
        }).then(response => {
            this.setState({
                categories: response.data
            })
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error, 'danger'))
        })
    }

    handleChange = e => {
        console.log(e.target.value)
        this.setState({
            [e.target.name]: e.target.value,
        })
    }
    createNewProduct() {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/product',
            method: 'POST',
            data: {
                "name": this.state.newProductName,
                "description": this.state.ProductDescription,
                "price": this.state.newProductPrice,
                "images": this.state.newProductImages,
            }
        }).then(response => {
            console.log(response.data)
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error), 'danger')
        })
    }
    deleteClicked(id) {
        axios.defaults.baseURL = this.props.baseURL;
        axios({
            url: '/category/' + id,
            method: 'DELETE',
        }).then(response => {
            this.props.getCategories()
        }).catch((error) => {
            this.handleAlert(Utils.handleAxiosError(error), 'danger')
        })

    }
    handleUpdate = (obj, id) => {
        this.setState({
            newobj: obj
        }, () => 
        axios({
            url: '/product/' + id,
            method: 'PUT',
            data: this.state.newobj
        }).then(response => {
            if (response.status >= 200 && response.status <= 404) {
                this.handleAlert(response.statusText, 'danger')
                this.getAllBrands()
                this.getAllCategories()
                this.props.getProducts()
            }
        }).catch(error => {
            this.handleAlert(error, 'danger')
        }))
    }
    changeBrand(obj, id, prod) {
        prod.brandId = obj.id;
        prod.brand = obj;
        this.setState({
            tempObj: prod,
        }, () =>  this.handleUpdate(this.state.tempObj, id))
         
    }
    changeCategory(obj, id, prod) {
        prod.categoryId = obj.id;
        prod.category = obj;
        this.setState({
            tempObj: prod,
        }, () => this.handleUpdate(this.state.tempObj, id))
    }

    showImages(id) {
        console.log('Show images with productID: ' + id)
    }

    render() {
        const data = _.sortBy(this.props.products, ['name'])
        const cellEdit = cellEditFactory({
            mode: 'click',
            blurToSave: true,
            beforeSaveCell: (oldValue, newValue, row, column) => {
                if (oldValue !== newValue) {
                    this.handleUpdate(row, row.id)
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
            text: 'Product'
        },
        {
            dataField: "brand.name",
            text: "Brand",
            editable: false,
            align: 'right',
            formatter: (cellContent, row) => {
                if (this.state.brands === undefined) {
                    return (
                        <p className='text-center'>
                            <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
                        </p>
                    )
                } else {
                    return (
                        <Dropdown>
                            <Dropdown.Toggle
                                size="sm"
                                variant="dark"
                            >
                                {row.brand.name}
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                {this.state.brands.map((b, i) => {
                                    return (
                                        <Dropdown.Item
                                            key={i}
                                            onSelect={() => this.changeBrand(b, row.id, row)}
                                        >
                                            {b.name}
                                        </Dropdown.Item>
                                    )
                                })}
                            </Dropdown.Menu>
                        </Dropdown>
                    )
                }
            }
        },
        {
            dataField: "category.name",
            text: "Category",
            isDummyField: true,
            editable: false,
            align: 'right',
            formatter: (cellContent, row) => {
                if (this.state.categories === undefined || this.state.categories === '') {
                    return (
                        <p className='text-center'>
                            <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
                        </p>
                    )
                } else {
                    return (
                        <Dropdown>
                            <Dropdown.Toggle
                                size="sm"
                                variant="dark"
                            >
                                {row.category.name}
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                {this.state.categories.map((c, i) => {
                                    return (
                                        <Dropdown.Item
                                            key={i}
                                            onSelect={() => this.changeCategory(c, row.id, row)}
                                        >
                                            {c.name}
                                        </Dropdown.Item>
                                    )
                                })}
                            </Dropdown.Menu>
                        </Dropdown>
                    )
                }
            }
        },
        {
            dataField: 'description',
            text: 'Description'
        },
        {
            dataField: 'price',
            text: 'Unit Price'
        },
        {
            dataField: 'quantity',
            text: 'In Stock'
        },
        {
            dataField: "images",
            text: "",
            isDummyField: true,
            editable: false,
            align: 'right',
            formatter: (cellContent, row) => {
                return (
                    <Button
                        size="sm"
                        variant="info"
                        onClick={() => this.showImages(row.id)
                        }
                    >
                        <FontAwesomeIcon icon="images" fixedWidth />
                    </Button>
                )
            }
        },
        {
            dataField: "delete",
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

                <Button
                    id="addPrefix"
                    variant="success"
                    type="submit"
                >
                    Add <FontAwesomeIcon icon="plus" fixedWidth />
                </Button>
            </div>

        )

    }
}

export default ProductsAdmin
