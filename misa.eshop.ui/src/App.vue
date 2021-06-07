<template>
  <div id="app">
    <div class="main">
      <TheSidebar/>
      <div class="t-container">
        <TheHeader/>
        <TheShopList/>
      </div>
    </div>
  </div>
</template>

<script>
import TheSidebar from "./components/layout/TheSidebar.vue";
import TheHeader from './components/layout/TheHeader.vue';
import TheShopList from './components/page/shop/TheShopList';
export default {
  name: "App",
  components: {
    TheSidebar,
    TheHeader, 
    TheShopList
  },
};
</script>

<style >
@import "./styles/base/common.css";
@import "./styles/base/main.css";
</style>
