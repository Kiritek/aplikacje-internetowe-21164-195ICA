import React, { Component } from "react";
import Modal from "./components/Modal";
import axios from "axios";
import PriorityHighIcon from '@mui/icons-material/PriorityHigh';
import LowPriorityIcon from '@mui/icons-material/LowPriority';
import CheckIcon from '@mui/icons-material/Check';


class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      viewCompleted: false,
      todoList: [],
      modal: false,
      activeItem: {
        title: "",
        description: "",
        completed: false,
        priority: ""
      },
    };
  }

  ErrorNotificationHander(err) {
    let notificationText = "";
    if (err.Title !== undefined) {
      notificationText += err.Title;
    }
    if (err.Description !== undefined) {
      notificationText += err.Description;
    }
    if (err.TodoTitleDescription !== undefined) {
      notificationText += err.TodoTitleDescription;
    }
    new Notification(notificationText)
  }


  componentDidMount() {
    this.refreshList();
    Notification.requestPermission();
  }

  refreshList = () => {
    axios
      .get("/api/todos/")
      .then((res) => this.setState({ todoList: res.data }))
      .catch((err) => console.log(err));
  };

  
  toggle = () => {
    this.setState({ modal: !this.state.modal });
  };

  handleSubmit = (item) => {
    this.toggle();
    if (item.id) {
      axios
        .put(`/api/todos/${item.id}/`, item)
        .then((res) => this.refreshList())
        .catch((err) => this.ErrorNotificationHander(err.response.data.errors));
      return;
    }
    axios
      .post("/api/todos/", item)
      .then((res) => this.refreshList())
      .catch((err) => this.ErrorNotificationHander(err.response.data.errors));
  };
  RenderIcon = ({ itemPriority,itemCompleted }) => {
    if (itemCompleted){
      return (<CheckIcon />);
    }
    if (itemPriority === "high") {
      return (<PriorityHighIcon />);
    }
    if (itemPriority === "low") {
      return (<LowPriorityIcon />);
    }
    else {
      return null;
    }
  };

  handleDelete = (item) => {
    axios
      .delete(`/api/todos/${item.id}/`)
      .then((res) => this.refreshList());
  };

  createItem = () => {

    const item = { title: "", description: "", completed: false, priority: "" };

    this.setState({ activeItem: item, modal: !this.state.modal });
  };

  editItem = (item) => {
    this.setState({ activeItem: item, modal: !this.state.modal });
  };

  displayCompleted = (status) => {
    this.setState({ viewCompleted: status })
  };

  renderTabList = () => {
    return (
      <div className="nav nav-tabs">
        <span
          onClick={() => this.displayCompleted(true)}
          className={this.state.viewCompleted ? "nav-link active" : "nav-link"}
        >
          Complete
        </span>
        <span
          onClick={() => this.displayCompleted(false)}
          className={this.state.viewCompleted ? "nav-link" : "nav-link active"}
        >
          Incomplete
        </span>
      </div>
    );
  };
  renderItems = () => {
    const { viewCompleted } = this.state;
    const newItems = this.state.todoList.filter(
      (item) => item.completed === viewCompleted
    );

    return newItems.map((item) => (
      <li
        key={item.id}
        className="list-group-item d-flex justify-content-between align-items-center"
      >
        <span
          className={`todo-title mr-2 ${this.state.viewCompleted ? "completed-todo" : ""
            }`}
          title={item.description}
        >
          <this.RenderIcon
            itemPriority={item.priority}
            itemCompleted={item.completed}
          />
          {item.title}
        </span>
        <span>
          <button
            className="btn btn-secondary mr-2"
            onClick={() => this.editItem(item)}
          >
            Edit
          </button>
          <button
            className="btn btn-danger"
            onClick={() => this.handleDelete(item)}
          >
            Delete
          </button>
        </span>
      </li>
    ));
  };

  render() {
    return (
      <main className="container">
        <h1 className="text-white text-uppercase text-center my-4">Todo app</h1>
        <div className="row">
          <div className="col-md-6 col-sm-10 mx-auto p-0">
            <div className="card p-3">
              <div className="mb-4">
                <button
                  className="btn btn-primary"
                  onClick={this.createItem}
                >
                  Add task
                </button>
              </div>
              {this.renderTabList()}
              <ul className="list-group list-group-flush border-top-0">
                {this.renderItems()}
              </ul>
            </div>
          </div>
        </div>
        {this.state.modal ? (
          <Modal
            activeItem={this.state.activeItem}
            toggle={this.toggle}
            onSave={this.handleSubmit}
          />
        ) : null}
      </main>
    );
  }
}

export default App;

