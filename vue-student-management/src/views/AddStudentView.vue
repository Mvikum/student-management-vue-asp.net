<script lang="ts">
import { defineComponent } from 'vue'
import StudentAddForm from '@/components/StudentAddForm.vue'

export default defineComponent({
  name: 'AddStudentView',
  components : {StudentAddForm},
})
</script>

<template>
<StudentAddForm/>
</template>

<style scoped>

</style>
