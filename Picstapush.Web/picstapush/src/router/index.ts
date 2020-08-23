import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Login from '@/components/Login/Login.vue';
import SignUp from '@/components/Login/SignUp.vue';
Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/login',
    component: Login,
    name: 'login'
  },
  {
    path: '/signup',
    component: SignUp,
    name: 'signup'
  }
];

const router = new VueRouter({
  routes
});

export default router;
