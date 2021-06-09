<template>
  <BaseModalFormSave ref="BaseForm">
    <div class="dialog-form form-confirm-delete">
      <!-- Begin dialog header -->
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div class="dialog-title" id="dialog-title">Dữ liệu chưa được lưu</div>
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
            <div class="icon-confirm"></div>
            <div class="msg-confirm-delete">
              Dữ liệu đã thay đổi, bạn có muốn lưu không?
            </div>
          </div>
        </div>
        <div class="dialog-footer footer-confirm-delete">
          <div class="dialog-footer-btn" style="margin-left: 120px;">
            
            <button
              class="t-btn d-btn btn-delete-record" style="background-color: #2b3173 !important;"
              id="btn-delete-record"
              tabindex="1"
            >
              <div class="t-icon icon-save"></div>
              <span>Lưu</span>
            </button>
             <button
            style="width: 100px;margin-left:6px;border:1px solid; border-color: #2b3173 !important;"
              class="t-btn d-btn btn-cancel"
              id="btn-cf-cancel"
              tabindex="2"
              @click="hide()"

            >
              <div class="t-icon icon-no-save"></div>
              <span>Không lưu</span>
            </button>
            <button
            style="margin-left:6px"
              class="t-btn d-btn btn-cancel"
              id="btn-cf-cancel"
              tabindex="2"
              @click="hide()"
            >
              <div class="t-icon icon-cancel"></div>
              <span>Hủy bỏ</span>
            </button>
          </div>
        </div>
      </div>
      <!-- End dialog delete -->
    </div>
  </BaseModalFormSave>
</template>

<script>
import BaseModalFormSave from "../../layout/BaseModalFormSave";
export default {
  components: {
    BaseModalFormSave,
  },
  props: {
  },
  data() {
    return {
    };
  },
  created() {
    
  },
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
  watch: {
  },
};
</script>
<style>
.icon-no-save{
   background-image: url('../../../assets/icon/not-save.png') !important;
}
</style>

