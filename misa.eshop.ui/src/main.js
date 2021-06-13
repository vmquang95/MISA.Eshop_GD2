import Vue from "vue";
import App from "./App.vue";
import { func } from "./common/javascript/mUtils.js";
import { Const } from "./common/javascript/mConsts.js";

// style
import "./assets/fonts/fontawesome-free-5.15.3-web/css/all.css";

Vue.prototype.$fn = func;
Vue.prototype.$Const = Const;
Vue.config.productionTip = false;
Vue.use(require("vue-shortkey"));

new Vue({
  render: (h) => h(App),
}).$mount("#app");
