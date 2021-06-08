import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Link } from 'react-router-dom'

export default function Navigation() {

    return (
        <div>
            <div id="sidebar-wrapper">
                <ul className="sidebar-nav">
                    <Link to="/" style={{ textDecoration: "none" }}>
                        <div>
                            <FontAwesomeIcon icon="home" fixedWidth />
                            <span className="d-none d-md-inline"> Home</span>
                        </div>
                    </Link>
                    <Link to="/categories" style={{ textDecoration: "none" }} >
                        <div >
                            <FontAwesomeIcon icon="cat" fixedWidth />
                            <span className="d-none d-md-inline"> Categories</span>
                        </div>
                    </Link>
                    <Link to="/checkout" style={{ textDecoration: "none" }} >
                        <div>
                            <FontAwesomeIcon icon="shopping-cart" fixedWidth />
                            <span className="d-none d-md-inline"> Check-out</span>
                        </div>
                    </Link>
                    <Link to="/create" style={{ textDecoration: "none" }} >
                        <div>
                            <FontAwesomeIcon icon="user" fixedWidth />
                            <span className="d-none d-md-inline"> Create user</span>
                        </div>
                    </Link>
                </ul>
            </div>
        </div>
    )
}
