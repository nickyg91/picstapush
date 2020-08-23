import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import axios from 'axios';
import buefy from 'buefy'
import '@fortawesome/fontawesome-free/css/all.css'
Vue.config.productionTip = false;
Vue.use(buefy, {
  defaultIconPack: 'fas'
});
const axiosConfig = axios.create({
  headers: {
    'content-type': 'application/json'
  }
})
Vue.prototype.$http = axiosConfig;
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
