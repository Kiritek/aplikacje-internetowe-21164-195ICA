import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:62466/api",
  headers: {
    "Content-type": "application/json"
  }
});



