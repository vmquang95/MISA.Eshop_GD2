<template>
  <div class="alert-modal">
    <div class="info-icon"><img class = "info-icon-img" src="../../assets/icon/infomationRed.png" alt=""></div>
    <div class="alert-form">
      <div class="alert-text">{{alertMessage}}</div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    visible: Boolean,
    alertMessage: String,
  },
  data() {
    return {};
  },
  methods: {
    /**
     * Sự kiện ẩn thông báo
     * CreatedBy: vmquang 19.04.2021
     */
    hide() {
      this.visible = false;
    },

    /**
     * Sự kiện hiện form thông báo
     * CreatedBy: vmquang 19.04.2021
     */
    show() {
      this.visible = true;
    },
  },
};
</script>

<style scoped>
@import url('../../styles/base/alertForm.css');
</style>