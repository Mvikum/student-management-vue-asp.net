// src/services/studentService.ts
import axios from 'axios'

const API_URL = 'https://localhost:7088/api/Student'

export default {
  async getAll() {
    // const response =  await axios.get(`${API_URL}/list`);
    // return response.data.data.students;
    return await axios.get(`${API_URL}/list`)
  },
  async create(student: any) {
    return await axios.post(`${API_URL}/save`, student)
  },
  async update(id: number, student: any) {
    return await axios.put(`${API_URL}/${id}`, student)
  },
  async delete(id: number) {
    return await axios.delete(`${API_URL}/${id}`)
  },
}
