<!-- src/components/StudentTable.vue -->
<template>
  <div>
    <h2>Student List</h2>
    <v-table theme="dark">
      <thead>
      <tr>
        <th class="text-left">Name</th>
        <th class="text-left">Email</th>
        <th class="text-left">Birthday</th>
        <th class="text-left">Gender</th>
        <th class="text-left">Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="student in students" :key="student.id">
        <td>{{ student.name }}</td>
        <td>{{ student.email }}</td>
        <td>{{ student.birthday }}</td>
        <td>{{ student.gender }}</td>
        <td>
          <v-btn color="primary" :to="`/edit/${student.id}`">Edit</v-btn>
          <v-btn color="error" @click="$emit('delete', student.id)">Delete</v-btn>
        </td>
      </tr>
      </tbody>
    </v-table>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Student from '@/helpers/classes/student/Student.ts'

export default defineComponent({
  name: 'StudentTable',
  props: {
    students: {
      type: Array as () => Student[],
      required: true
    }
  },
})
</script>
