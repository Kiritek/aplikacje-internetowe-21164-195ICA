import React, { Component } from "react";
import authService from './api-authorization/AuthorizeService'

export class Post extends Component {
    constructor(props) {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.onChangeCategory = this.onChangeCategory.bind(this);
        this.getPost = this.getPost.bind(this);
        this.updatePost = this.updatePost.bind(this);
        this.deletePost = this.deletePost.bind(this);

        this.state = {
            currentPost: {
                id: null,
                title: "",
                description: "",
                category: ""
            },
            message: ""
        };
    }

    componentDidMount() {
        this.getPost(this.props.match.params.id);
        Notification.requestPermission();
    }

    onChangeTitle(e) {
        const title = e.target.value;

        this.setState(function (prevState) {
            return {
                currentPost: {
                    ...prevState.currentPost,
                    title: title
                }
            };
        });
    }

    onChangeDescription(e) {
        const description = e.target.value;

        this.setState(prevState => ({
            currentPost: {
                ...prevState.currentPost,
                description: description
            }
        }));
    }
    onChangeCategory(e) {
        const category = e.target.value;

        this.setState(function (prevState) {
            return {
                currentPost: {
                    ...prevState.currentPost,
                    category: category
                }
            };
        });
    }

    async getPost(id) {


        const token = await authService.getAccessToken();
        const response = await fetch(`api/posts/${id}`, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({
            currentPost:data
        });
    }


    async updatePost() {
        const token = await authService.getAccessToken();
        const response = await fetch(`api/posts/${this.state.currentPost.id}`, {
            headers: { 'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json' },
            method: 'put',
            body: JSON.stringify(this.state.currentPost)
        }).catch(new Notification('Error 401 Unauthorized'));
    }

    async deletePost() {
        const token = await authService.getAccessToken();
        const response = await fetch(`api/posts/${this.state.currentPost.id}`, {
            headers: { 'Authorization': `Bearer ${token}` },
            method: 'delete',
        }).catch(new Notification('Error 401 Unauthorized'));
        this.getPost(1);
    }

    render() {
        const { currentPost } = this.state;

        return (
            <div>
                {currentPost ? (
                    <div className="edit-form">
                        <h4>Post</h4>
                        <form>
                            <div className="form-group">
                                <label htmlFor="title">Title</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="title"
                                    value={currentPost.title}
                                    onChange={this.onChangeTitle}
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="description">Description</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="description"
                                    value={currentPost.description}
                                    onChange={this.onChangeDescription}
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="category">Category</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="category"
                                    value={currentPost.category}
                                    onChange={this.onChangeCategory}
                                />
                            </div>
                            
                        </form>

                        <button
                            className="badge badge-danger mr-2"
                            onClick={this.deletePost}
                        >
                            Delete
                        </button>

                        <button
                            type="submit"
                            className="badge badge-success"
                            onClick={this.updatePost}
                        >
                            Update
                        </button>
                        <p>{this.state.message}</p>
                    </div>
                ) : (
                    <div>
                        <br />
                        <p>Please click on a Post...</p>
                    </div>
                )}
            </div>
        );
    }
}

