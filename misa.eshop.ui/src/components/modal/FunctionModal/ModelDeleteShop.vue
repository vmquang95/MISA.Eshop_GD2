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
              Bạn có chắc chắn muốn xóa
              <span class="store-name-selected">{{
                selectedShop.storeName
              }}</span>
              khỏi danh sách cửa hàng?
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
    selectedShopId: String,
  },
  data() {
    return {
      selectedShop: {
        storeCode: "",
        storeName: "",
        address: "",
        phoneNumber: "",
        storeTaxCode: "",
        countryId: null,
        provinceId: null,
        districtId: null,
        wardId: null,
        status: 0,
      },
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
     * CreatedBy: 16.04.2021
     */
    show() {
      this.$refs.BaseForm.show();
    },

    /**
     *  Lấy thông tin 1 bản ghi theo Id
     * CreatedBy: vmquang 16.04.2021
     */
    getStoreById() {
      axios
        .get("http://localhost:35480/api/v1/stores/" + this.selectedShopId)
        .then((respone) => {
          this.selectedShop = respone.data.data;
        })
        .catch((error) => console.log(error));
    },

    /**
     *  Xóa 1 bản ghi theo id
     *  CreatedBy: vmquang 16.04.2021
     */
    deleteRecord() {
      let alertMessage = "";
      axios
        .delete("http://localhost:35480/api/v1/stores/" + this.selectedShopId)
        .then((respone) => {
          console.log(respone);
          alertMessage = "Xóa bản ghi thành công";
          this.$emit("showAlertDelete", alertMessage);
        })
        .catch((error) => {
          console.log(error);
          alertMessage = "Xóa bản ghi thất bại";
          this.$emit("showAlertDelete", alertMessage);
        });
    },
  },
  watch: {
    selectedShopId() {
      this.getStoreById();
    },
  },
};
</script>

<style>
</style>

