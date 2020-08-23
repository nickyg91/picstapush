import Vue from "vue";
import Vuex from "vuex";
import User from '@/models/user-model';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    User: null
  },
  mutations: {
    setUser: (state: any, user: User) => {
      state.User = user;
    }
  },
  getters: {
    getUser: state => {
      return state.User;
    }
  },
  actions: {},
  modules: {}
});
