// src/router/index.ts
import { createRouter, createWebHistory } from 'vue-router'
import type { RouteRecordRaw } from 'vue-router'
import HomeView from '@/views/Home.vue'
import AddStudentView from '@/views/AddStudentView.vue'
import EditStudentView from '@/views/EditStudentView.vue'

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/add-student',
    name: 'AddStudent',
    component: AddStudentView,
  },
  {
    path: '/edit/:id',
    name: 'EditStudent',
    component: () => import('@/views/EditStudentView.vue')
  }

]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
