import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


export class CategoriesAdmin extends Component {
    render() {
        if (this.props.categories === undefined) {
            return (
                <p className='text-center'>
                    <FontAwesomeIcon icon='sync-alt' size="lg" spin={true} />
                </p>
            )
        } else if (this.props.categories.length === 0) {
            return (
                <div>
                    <h5 className="title"><p className="badge badge-dark bg-secondary">No Product</p></h5>
                </div>
            )
        }
        else {
            return (
                this.props.categories.map((cat, i) => {
                    return (
                        <p key={i}>{cat.name}</p>
                    )

                })
            )
        }
    }
}

export default CategoriesAdmin
