import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Home } from '../Home';
import { Categories } from '../Categories';

export default class Navigation extends Component {
    constructor(props) {
        super(props)
        this.state = {
            menuItem: '',
        }
    }

    setMenuItem = (menuItem) => {
        this.setState({
            menuItem: menuItem,
        });
    }

    content() {
        switch (this.state.menuItem) {
            default:
            case 'home':
                return (
                    <Home
                    baseURL={this.props.baseURL}
                    />
                );
                case 'categories':
                return (
                    <Categories
                    baseURL={this.props.baseURL}
                    />
                );
        }
    }

    render() {
        return (
            <div id="wrapper">
                <div id="sidebar-wrapper">
                    <ul className="sidebar-nav">
                        <li className="nav-item">
                            <div onClick={() => this.setMenuItem('home')}>
                                <FontAwesomeIcon icon="home" fixedWidth />
                                <span className="d-none d-md-inline"> Home</span>
                            </div>
                        </li>
                        <li className="nav-item">
                            <div onClick={() => this.setMenuItem('categories')}>
                                <FontAwesomeIcon icon="glass-martini-alt" fixedWidth />
                                <span className="d-none d-md-inline"> Categories</span>
                            </div>
                        </li>
                        <li className="nav-item">
                            <div onClick={() => this.setMenuItem('home')}>
                                <FontAwesomeIcon icon="shopping-cart" fixedWidth />
                                <span className="d-none d-md-inline"> Check-out</span>
                            </div>
                        </li>
                        <li className="nav-item">
                            <div onClick={() => this.setMenuItem('home')}>
                                <FontAwesomeIcon icon="user" fixedWidth />
                                <span className="d-none d-md-inline"> Create user</span>
                            </div>
                        </li>
                    </ul>
                </div>
                <div id="page-content-wrapper">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-lg-12">
                                <div id="includedContent">
                                    {this.content()}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
