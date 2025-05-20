<script lang="ts">
import { defineComponent } from 'vue'
import studentService from '@/services/studentServices.ts'

export default defineComponent({
  name: 'StudentAddForm',
  props: {
    student :{
      type : Object,
      default : null
    }
  },
  data(){
    return{
      name: '',
      email: '',
      birthday: '',
      gender: '',
    }
  },
  methods:{
    async handleSubmit(){
      const student = {
        name: this.name,
        email: this.email,
        DOB: this.birthday,
        gender: this.gender
      }
      console.log(student)

      try {
        const response = await studentService.create(student)
        console.log('Student added successfully:', response.data)
        console.log(response.data)

        // Optionally reset form
        this.name = ''
        this.email = ''
        this.birthday = ''
        this.gender = ''

        // Optionally show a message to the user
        alert('Student added successfully!')

      } catch (error) {
        console.error('Error adding student:', error)
        alert('Failed to add student.')
      }
    }
  }
})
</script>

<template>
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

    <v-btn type="submit" color="success">Add Student</v-btn>
  </form>
</template>

<style scoped>

</style>
