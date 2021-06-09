<template>
  <BaseModalForm ref="BaseForm">
    <div class="dialog-form form-confirm-delete">
      <!-- Begin dialog header -->
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div class="dialog-title" id="dialog-title">Xóa dữ liệu</div>
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
              <span>Bạn có chắc chắn muốn xóa phiếu đặt hàng </span>
              <span class="store-name-selected" style="color:#df4646">{{
                currentObject.refCode
              }}</span>
              không?
            </div>
          </div>
        </div>
        <div class="dialog-footer footer-confirm-delete">
          <div class="dialog-footer-btn">
            <button
              class="t-btn d-btn btn-delete-record"
              id="btn-delete-record"
              tabindex="1"
              @click="deleteRecord()"
            >
              <div class="t-icon icon-delete"></div>
              <span>Xóa</span>
            </button>
            <button
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
  </BaseModalForm>
</template>

<script>
import axios from "axios";
import BaseModalForm from "../../layout/BaseModalForm";
export default {
  components: {
    BaseModalForm,
  },
  props: {
    selectedObjectId: String,
  },
  data() {
    return {
      currentObject: {},
    };
  },
  created() {},
  methods: {
    /**
     * Xóa Object theo id
     */
    deleteRecord() {
      axios
        .delete(
          "http://localhost:35480/api/v1/OrderBills/" + this.selectedObjectId
        )
        .then((respone) => {
          console.log(respone);
          this.$emit("loadData");
        })
        .catch((error) => {
          console.log(error);
        });
      this.$refs.BaseForm.hide();
    },
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
      axios
        .get(
          "http://localhost:35480/api/v1/OrderBills/" + this.selectedObjectId
        )
        .then((respone) => {
          this.currentObject = respone.data.data;
        })
        .catch((error) => console.log(error));
      this.$refs.BaseForm.show();
    },
  },
  watch: {},
};
</script>

<style></style>
