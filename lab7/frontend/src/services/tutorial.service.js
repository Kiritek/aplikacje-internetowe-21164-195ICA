import http from "../http-common";

class TutorialDataService {
  getAll() {
    return http.get("/TutorialsController");
  }

  get(id) {
    return http.get(`/TutorialsController/${id}`);
  }

  create(data) {
    return http.post("/TutorialsController", data);
  }

  update(id, data) {
    return http.put(`/TutorialsController/${id}`, data);
  }

  delete(id) {
    return http.delete(`/TutorialsController/${id}`);
  }

  deleteAll() {
    return http.delete(`/TutorialsController`);
  }

  findByTitle(title) {
    return http.get(`/TutorialsController?name=${title}`);
  }
}

export default new TutorialDataService();