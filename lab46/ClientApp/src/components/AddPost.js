
import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'


export default class AddPost extends Component {
    constructor(props) {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.onChangeCategory = this.onChangeCategory.bind(this);
        this.savePost = this.savePost.bind(this);
        this.newPost = this.newPost.bind(this);

        this.state = {
            id: null,
            title: "",
            description: "",
            category:""
        };
    }

    onChangeTitle(e) {
        this.setState({
            title: e.target.value
        });
    }

    onChangeDescription(e) {
        this.setState({
            description: e.target.value
        });
    }
    onChangeCategory(e) {
        this.setState({
            category: e.target.value
        });
    }

    async savePost() {
        var data = {
            title: this.state.title,
            description: this.state.description,
            category: this.state.category
        };
        const token = await authService.getAccessToken();

        console.log(data);

        const response = await fetch('api/posts', {
            headers:{ 'Authorization': `Bearer ${token}`,'Content-Type':'application/json' },
            method: 'post',
            body: JSON.stringify(data)
        });
        const dataEx = await response.json();

        console.log(dataEx);
    }

    newPost() {
        this.setState({
            id: null,
            title: "",
            description: ""
        });
    }

    render() {
        return (
            <div className="submit-form">
               
                    <div>
                        <div className="form-group">
                            <label htmlFor="title">Title</label>
                            <input
                                type="text"
                                className="form-control"
                                id="title"
                                required
                                value={this.state.title}
                                onChange={this.onChangeTitle}
                                name="title"
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="description">Description</label>
                            <input
                                type="text"
                                className="form-control"
                                id="description"
                                required
                                value={this.state.description}
                                onChange={this.onChangeDescription}
                                name="description"
                            />
                            </div>

                            <div className="form-grup">
                                <label htmlFor="category">Category</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="description"
                                    required
                                    value={this.state.category}
                                    onChange={this.onChangeCategory}
                                    name="category"
                                />
                            </div>
                        <button onClick={this.savePost} className="btn btn-success">
                            Submit
                        </button>
                    </div>
            </div>
        );
    }
}

