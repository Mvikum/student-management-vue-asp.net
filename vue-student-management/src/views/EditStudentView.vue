<!-- src/views/EditStudentView.vue -->
<template>
  <div>
    <h2>Edit Student</h2>
    <form @submit.prevent="handleSubmit">
      <v-text-field v-model="name" label="Name" required></v-text-field>
      <v-text-field v-model="email" label="Email" type="email" required></v-text-field>
      <v-text-field v-model="birthday" label="Birthday" type="date" required></v-text-field>

      <div class="radio-group">
        <label>Choose your gender:</label><br />
        <input type="radio" id="male" value="Male" v-model="gender" />
        <label for="male">Male</label><br />
        <input type="radio" id="female" value="Female" v-model="gender" />
        <label for="female">Female</label><br />
        <input type="radio" id="other" value="Other" v-model="gender" />
        <label for="other">Other</label><br />
      </div>

      <v-btn type="submit" color="primary">Update Student</v-btn>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import studentService from '@/services/studentServices.ts';

export default defineComponent({
  name: 'EditStudentView',
  data() {
    return {
      id: null as number | null,
      name: '',
      email: '',
      birthday: '',
      gender: '',
    };
  },
  async mounted() {
    const route = useRoute();
    const studentId = Number(route.params.id);
    this.id = studentId;

    try {
      const response = await studentService.getAll();
      const student = response.data.data.students.find((s: any) => s.id === studentId);

      if (student) {
        this.name = student.name;
        this.email = student.email;
        this.birthday = student.dob;
        this.gender = student.gender;
      } else {
        alert('Student not found.');
        this.$router.push('/');
      }
    } catch (error) {
      console.error('Failed to load student:', error);
      alert('Error loading student data.');
    }
  },
  methods: {
    async handleSubmit() {
      const updatedStudent = {
        name: this.name,
        email: this.email,
        DOB: this.birthday,
        gender: this.gender,
      };

      try {
        await studentService.update(this.id!, updatedStudent);
        alert('Student updated successfully!');
        this.$router.push('/');
      } catch (error) {
        console.error('Update failed:', error);
        alert('Failed to update student.');
      }
    },
  },
});
</script>

<style scoped>
.radio-group {
  margin-top: 16px;
}
</style>
