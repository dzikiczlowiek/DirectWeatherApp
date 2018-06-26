import Vue from 'vue'
import App from './App'
import BootstrapVue from "bootstrap-vue"
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import axios from 'axios'
import VueAxios from 'vue-axios'
import moment from 'vue-moment';

Vue.use(BootstrapVue)
Vue.use(VueAxios, axios)
Vue.use(moment)

new Vue({
  el: '#app',
  template: '<App/>',
  render: h => h(App)
});

axios.defaults.baseURL = 'http://localhost/DirectWeather.Api';
