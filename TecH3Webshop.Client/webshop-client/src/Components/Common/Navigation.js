import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Link } from 'react-router-dom'

export default function Navigation({ categories, adminview , setAdmin}) {

    return (
        <div>
            <div id="sidebar-wrapper">
                        <ul className="sidebar-nav">
                            <Link to="/" style={{ textDecoration: "none" }}>
                                <div>
                                    <FontAwesomeIcon icon="home" fixedWidth />
                                    <span className="d-none d-md-inline"> HOME</span>
                                </div>
                            </Link>
                            {categories === undefined ?
                                null
                                :
                                categories.map((item, i) => {
                                    return (
                                        <Link key={i} to={{ pathname: `/products/category/${item.id}`, state: item }} style={{ textDecoration: "none" }}>
                                            <div>
                                                <FontAwesomeIcon icon="tag" fixedWidth />
                                                {item.name.toUpperCase()}
                                            </div>
                                        </Link>
                                    )
                                })
                            }
                            <Link to="/checkout" style={{ textDecoration: "none" }} >
                                <div>
                                    <FontAwesomeIcon icon="shopping-cart" fixedWidth />
                                    <span className="d-none d-md-inline"> CHECK-OUT</span>
                                </div>
                            </Link>
                            <Link to="/create" style={{ textDecoration: "none" }} >
                                <div>
                                    <FontAwesomeIcon icon="user" fixedWidth />
                                    <span className="d-none d-md-inline"> CREATE USER</span>
                                </div>
                            </Link>
                            <Link to="/admin" style={{ textDecoration: "none" }} >
                                <div>
                                    <FontAwesomeIcon icon="cogs" fixedWidth />
                                    <span className="d-none d-md-inline"> ADMIN</span>
                                </div>
                            </Link>
                        </ul>        
            </div>
        </div>
    )
}
