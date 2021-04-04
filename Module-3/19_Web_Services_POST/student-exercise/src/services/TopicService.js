import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  list() {
    return http.get('/topics');
  },

  get(id) {
    return http.get(`/topics/${id}`);
  },
  post(topic) {
    return http.post(`/topics`, topic)
  },
  put(id, topic){
    return http.put(`/topics/${id}`, topic)
  },
  delete(id){
    return http.delete(`/topics/${id}`)
  }
}
