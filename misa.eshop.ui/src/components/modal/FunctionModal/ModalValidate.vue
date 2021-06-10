<template>
  <BaseModalValidate ref="BaseForm">
    <div class="dialog-form form-confirm-delete">
      <!-- Begin dialog header -->
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div class="dialog-title" id="dialog-title">
            MISA eShop
          </div>
          <div class="dialog-button">
            <button
              class="t-btn btn-close t-icon"
              id="btn-close"
              @click="hide()"
            ></button>
          </div>
        </div>
      </div>
      <!-- End dialog header -->
      <!-- Begin dialog delete -->
      <div class="dialog-confirm-delete">
        <div class="dialog-content">
          <div class="content-confirm">
            <div class="icon-confirm-validate"></div>
            <div class="msg-confirm-delete">
              {{message}}
            </div>
          </div>
        </div>
        <div class="dialog-footer footer-confirm-delete">
          <div class="dialog-footer-btn" style="margin-left: 313px;">
            <button
              @click="hide()"
              class="t-btn d-btn btn-delete-record"
              style="background-color: #2b3173 !important; width: 75px; padding: 1px 7px 0 18px;"
              id="btn-delete-record"
              tabindex="1"
            >
              <span>Đồng ý</span>
            </button>
          </div>
        </div>
      </div>
      <!-- End dialog delete -->
    </div>
  </BaseModalValidate>
</template>

<script>
import BaseModalValidate from "../../layout/BaseModalValidate";
export default {
  components: {
    BaseModalValidate,
  },
  props: {
    message:String
    },
  data() {
    return {
    };
  },
  created() {},
  methods: {
    /**
     *  Ẩn dialog xác nhận xóa
     *  CreatedBy: vmquang 16.04.2021
     */
    hide() {
      this.$refs.BaseForm.hide();
    },

    /**
     * Hiện dialog xác nhận xóa
     * CreatedBy: vmquang 16.04.2021
     */
    show() {
      this.$refs.BaseForm.show();
    },
  },
  watch: {},
};
</script>
<style>
.icon-no-save {
  background-image: url("../../../assets/icon/not-save.png") !important;
}
</style>
