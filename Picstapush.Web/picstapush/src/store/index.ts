import Vue from "vue";
import Vuex from "vuex";
import Token from "@/models/token-model";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    Token: new Token()
  },
  mutations: {
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    setUser: (state: any, token: Token) => {
      state.Token = token;
    }
  },
  getters: {
    getToken: state => {
      return state.Token;
    }
  },
  actions: {},
  modules: {}
});
