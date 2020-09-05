import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios, { AxiosResponse } from "axios";
import buefy from "buefy";
import "@fortawesome/fontawesome-free/css/all.css";
import Token from "./models/token-model";
Vue.config.productionTip = false;
Vue.use(buefy, {
  defaultIconPack: "fas"
});
const axiosConfig = axios.create({
  headers: {
    "content-type": "application/json"
  }
});

axiosConfig.interceptors.request.use(
  config => {
    const token = store.getters.getToken() as Token;
    if (token != null) {
      config.headers.common["Authorization"] = token.tokenString;
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

axiosConfig.interceptors.response.use(
  resp => {
    if (resp.status === 200 || resp.status === 201) {
      return Promise.resolve(resp);
    } else {
      return Promise.reject(resp);
    }
  },
  async error => {
    if (error.response.status) {
      const originalRequest = error.config;
      const refreshToken = store.state.Token?.refreshToken;
      if (
        error.status === 401 &&
        store.state.Token.refreshTokenExpiresAt < new Date()
      ) {
        const tokenReq = (await axiosConfig.post(
          `api/token/refresh/${refreshToken}`
        )) as AxiosResponse<Token>;
        originalRequest._retry = true;
        store.commit("setToken", tokenReq);
        return axiosConfig(originalRequest);
      } else {
        router.push("login");
        return Promise.reject(error);
      }
    }
  }
);
Vue.prototype.$http = axiosConfig;
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
