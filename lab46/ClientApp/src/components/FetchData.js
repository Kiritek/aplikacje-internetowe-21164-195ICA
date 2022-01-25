import React, { Component } from 'react';
import { Link } from "react-router-dom";
import authService from './api-authorization/AuthorizeService'



export class FetchData extends Component {
    constructor(props) {
        super(props);
        this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
        this.retrievePosts = this.retrievePosts.bind(this);
        this.refreshList = this.refreshList.bind(this);
        this.setActivePost = this.setActivePost.bind(this);
        this.searchTitle = this.searchTitle.bind(this);

        this.state = {
            post: [],
            currentPost: null,
            currentIndex: -1,
            searchTitle: ""
        };
    }

    componentDidMount() {
        this.retrievePosts();
    }

    onChangeSearchTitle(e) {
        const searchTitle = e.target.value;

        this.setState({
            searchTitle: searchTitle
        });
    }

    async retrievePosts() {

        const token = await authService.getAccessToken();
        const response = await fetch('api/posts', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({
            posts: data
        });
        
    }

    refreshList() {
        this.retrievePosts();
        this.setState({
            currentPost: null,
            currentIndex: -1
        });
    }

    setActivePost(post, index) {
        this.setState({
            currentPost: post,
            currentIndex: index
        });
    }


    async searchTitle() {


        this.setState({
            currentPost: null,
            currentIndex: -1
        });
        const token = await authService.getAccessToken();
      
        const response = await fetch(`api/posts?keyWord=${this.state.searchTitle}`, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({
            posts: data
        });


    }

    render() {
        const { searchTitle, posts, currentPost, currentIndex } = this.state;

        return (
            <div className="list row">
                <div className="col-md-8">
                    <div className="input-group mb-3">
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Search by title"
                            value={searchTitle}
                            onChange={this.onChangeSearchTitle}
                        />
                        <div className="input-group-append">
                            <button
                                className="btn btn-outline-secondary"
                                type="button"
                                onClick={this.searchTitle}
                            >
                                Search
                            </button>
                        </div>
                    </div>
                </div>
                <div className="col-md-6">
                    <h4>Posts</h4>

                    <ul className="list-group">
                        {posts &&
                            posts.map((post, index) => (
                                <li
                                    className={
                                        "list-group-item " +
                                        (index === currentIndex ? "active" : "")
                                    }
                                    onClick={() => this.setActivePost(post, index)}
                                    key={index}
                                >
                                    {post.title}
                                </li>
                            ))}
                    </ul>

                  
                </div>
                <div className="col-md-6">
                    {currentPost ? (
                        <div>
                            <h4>Tutorial</h4>
                            <div>
                                <label>
                                    <strong>Title:</strong>
                                </label>{" "}
                                {currentPost.title}
                            </div>
                            <div>
                                <label>
                                    <strong>Description:</strong>
                                </label>{" "}
                                {currentPost.description}
                            </div>
                            <div>
                                <label>
                                    <strong>Category</strong>
                                </label>{" "}
                                {currentPost.category}
                            </div>

                          
                        </div>
                    ) : (
                        <div>
                            <br />
                            <p>Please click on a Post...</p>
                        </div>
                    )}
                </div>
            </div>
        );
    }
}
