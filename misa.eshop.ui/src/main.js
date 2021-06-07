import Vue from 'vue'
import App from './App.vue'

// style
import "./assets/fonts/fontawesome-free-5.15.3-web/css/all.css"


Vue.config.productionTip = false
Vue.use(require('vue-shortkey'))

new Vue({
  render: h => h(App),
}).$mount('#app')
