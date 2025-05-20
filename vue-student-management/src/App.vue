<template>
  <div id="app">
    <header>
      <h1>Student Management System</h1>
      <nav>
        <router-link to="/">Home</router-link> |
        <router-link to="/add-student">Add Student</router-link>
<!--        <router-link to="/edit-student">Edit Student</router-link>-->

      </nav>
    </header>

    <main>
      <router-view />
    </main>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'App',
});
</script>

<style scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  padding: 20px;
}

header {
  background-color: #11402a;
  padding: 10px;
  color: white;
}

nav a {
  color: white;
  text-decoration: none;
  margin: 0 8px;
}
</style>
