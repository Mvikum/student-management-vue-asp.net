<template>
  <div>
    <StudentTable :students="students" @delete="deleteStudent" @edit="startEdit"/>
  </div>
  <v-container>
  </v-container>

</template>

<script lang="ts">
import { defineComponent } from 'vue';
import StudentTable from '@/components/StudentTable.vue'; // Import StudentTable component
import type Student from '@/helpers/classes/student/Student.ts'; // Type for students
import studentService from '@/services/studentServices'; // Import studentService

export default defineComponent({
  name: 'HomeView',
  components: {
    StudentTable, // Register StudentTable component
  },
  data() {
    return {
      students: [] as Student[],
      selectedStudent:  null as Student | null // Declare the students array to hold the student data
    };
  },
  methods: {
    async loadStudents() {
      try {
        const response = await studentService.getAll();
        // this.students = await studentService.getAll();
        // Map API data to match Student class structure
        this.students = response.data.data.students.map((s: any) => ({
          id: s.id,
          name: s.name,
          email: s.email,
          birthday: s.dob,  // ✅ map `dob` to `birthday`
          gender: s.gender,
        }));
      } catch (error) {
        console.error('Failed to fetch students:', error);
      }
    },
    async deleteStudent(id: number) {
      if (confirm('Are you sure you want to delete this student ? ')) {
        try {
          await studentService.delete(id)
          this.students = this.students.filter(s => s.id !== id)
        } catch (err) {
          console.error('Error deleting student', err)
        }
      }
    },
    startEdit(student: Student) {
      this.selectedStudent = { ...student } // Make a copy to avoid mutating directly
    },
    cancelEdit() {
      this.selectedStudent = null
    },
    async onFormSubmitted() {
      this.selectedStudent = null
      await this.loadStudents()
    }
  },
  // Fetch students when the component is mounted
  mounted() {
    this.loadStudents();
  },
});
</script>
