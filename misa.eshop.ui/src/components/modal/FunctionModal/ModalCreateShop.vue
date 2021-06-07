<template>
  <BaseModalForm ref="BaseForm_ref">
    <div class="dialog-form form-add-edit">
      <!-- header -->
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div
            v-if="formMode == 'insert'"
            class="dialog-title"
            id="dialog-title"
          >
            Thêm mới Phiếu đặt hàng
          </div>
          <div
            v-else-if="formMode == 'update'"
            class="dialog-title"
            id="dialog-title"
          >
            Sửa Phiếu đặt hàng
          </div>
          <div v-else class="dialog-title" id="dialog-title">
            Phiếu đặt hàng
          </div>
          <div class="dialog-button">
            <button
              title="Đóng"
              class="t-btn btn-close t-icon"
              id="btn-close"
              v-shortkey="['esc']"
              @shortkey="hide()"
              @click="hide()"
            ></button>
          </div>
        </div>
      </div>
      <!-- toolbar 1 -->
      <div class="tool-bar" style="height:32px">
        <div class="tool-bar-btn div-btn-add">
          <button class="t-btn btn-add click-outside isActive" id="btn-add">
            <i class="t-icon t-icon-prev"></i>
            <span>Trước</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-replication ">
          <button
            disabled
            class="t-btn btn-replication t-btn-disable isActive"
            id="btn-replication"
          >
            <span>Sau</span>
            <i class="t-icon t-icon-next"></i>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-edit">
          <button
            disabled
            class="t-btn btn-edit t-btn-disable isActive"
            id="btn-edit"
          >
            <i class="t-icon t-icon-add"></i>
            <span>Thêm mới</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-edit">
          <button
            disabled
            class="t-btn btn-edit t-btn-disable isActive"
            id="btn-edit"
          >
            <i class="t-icon t-icon-edit"></i>
            <span>Sửa</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-delete">
          <button
            disabled
            class="t-btn btn-delete t-btn-disable isActive"
            id="btn-delete"
          >
            <i class="t-icon t-icon-save"></i>
            <span>Lưu</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load isActive" id="btn-load">
            <i class="t-icon t-icon-delete"></i>
            <span>Xóa</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load isActive" id="btn-load">
            <i class="t-icon t-icon-pause"></i>
            <span>Hoãn</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load isActive" id="btn-load">
            <i class="t-icon t-icon-print"></i>
            <span>In</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load isActive" id="btn-load">
            <i class="t-icon t-icon-export"></i>
            <span>Xuất Khẩu</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load isActive" id="btn-load">
            <i class="t-icon t-icon-help"></i>
            <span>Trợ giúp</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load isActive" id="btn-load" @click="hide()">
            <i class="t-icon t-icon-exit"></i>
            <span>Đóng</span>
          </button>
        </div>
      </div>
      <!-- toolbar2 -->
      <div class="toobar-filter-date toolbar-create">
        <button class="btn-quang btn-chose">
          <span>Chọn phiếu báo hàng</span>
        </button>
      </div>
      <!-- info order bill -->
      <div class="info-bill">
        <div class="info-bill-left">
          <label class="titile-left">THÔNG TIN CHUNG</label>
          <div class="row-side">
            <span style="margin-right: 15px;">Nhà cung cấp</span>
            <input
              v-if="isReadOnlyInput"
              readonly
              class="input-create"
              type="text"
              v-model="currentObject.supplierCode"
              style="background-color: #e5e6eb;"
            />
            <input
              v-else
              class="input-create"
              type="text"
              v-model="currentObject.supplierCode"
            />
            <input
              v-if="isReadOnlyInput"
              readonly
              class="input-create"
              type="text"
              style="background-color: #e5e6eb; width:390px"
              v-model="currentObject.supplierName"
            />
            <input
              v-else
              class="input-create"
              type="text"
              style="width:390px"
              v-model="currentObject.supplierName"
            />
          </div>
          <div class="row-side row-side-2">
            <span style="margin-right: 37px;">Người đặt</span>
            <input
              v-if="!isReadOnlyInput"
              class="input-create"
              type="text"
              v-model="currentObject.customerCode"
            />
            <input
              v-else
              class="input-create"
              type="text"
              v-model="currentObject.customerCode"
              readonly
              style="background-color: #e5e6eb;"
            />
            <input
              v-if="!isReadOnlyInput"
              class="input-create"
              type="text"
              style="width:390px"
              v-model="currentObject.customerName"
            />
            <input
              v-else
              class="input-create"
              type="text"
              style="width:390px; background-color: #e5e6eb;"
              v-model="currentObject.customerName"
              readonly
            />
          </div>
          <div class="row-side row-side-2">
            <span style="margin-right: 47px;">Diễn dải</span>
            <input
              v-if="!isReadOnlyInput"
              class="input-create"
              type="text"
              style="width:590px"
              v-model="currentObject.description"
            />
            <input
              v-else
              readonly
              class="input-create"
              type="text"
              style="width:590px; background-color: #e5e6eb;"
              v-model="currentObject.description"
            />
          </div>
          <div class="row-side" style="margin-top: 17px">
            <span>Tham chiếu</span>
          </div>
        </div>
        <div class="info-bill-right">
          <label class="titile-left">CHỨNG TỪ</label>
          <div class="row-side row-side-2" style="margin-top:10px">
            <span style=" margin-right: 39px;">Số phiếu</span>
            <input
              v-if="!isReadOnlyInput"
              class="input-create"
              type="text"
              style="width:135px;"
              v-model="currentObject.refCode"
            />
            <input
              v-else
              readonly
              class="input-create"
              type="text"
              style="width:135px; background-color: #e5e6eb;"
              v-model="currentObject.refCode"
            />
          </div>
          <div class="row-side" style="margin-top:8px;">
            <span style="margin-right: 6px;">Ngày đặt hàng</span>
            <input
              v-if="!isReadOnlyInput"
              type="date"
              class="date-pick-create"
              v-model="currentObject.orderDate"
            />
            <input
              v-else
              readonly
              type="date"
              class="date-pick-create"
              v-model="currentObject.orderDate"
              style="background-color: #e5e6eb;"
            />
          </div>
          <div class="row-side" style="margin-top:8px">
            <span style="margin-right: 32px;">Trạng thái</span>
            <select
              v-if="!isReadOnlyInput"
              class="select-datetime-create"
            >
              <option v-for="element in arrayStatus" :key="element.value">{{
                element.text
              }}</option>
            </select>
            <select
              v-else
              disabled
              class="select-datetime-create"
              style="background-color: #e5e6eb;"
            >
              <option v-for="element in arrayStatus" :key="element.value">{{
                element.text
              }}</option>
            </select>
          </div>
        </div>
      </div>

      <!-- action-table -->
      <div class="action-table">
        <label> CHI TIẾT</label>
        <i class="t-icon t-icon-add-col-table"></i>
      </div>

      <!-- grid -->
      <div class="t-grid t-grid-create">
        <table id="tbl-list-store" cellspacing="0" cellpadding="0" width="100%">
          <thead>
            <tr>
              <th class="col-15">
                <div class="thead-text">Mã SKU</div>
                <div class="thead-filter order-date-input">
                  <button class="t-btn condition">*</button>
                  <input type="text" class="t-input filter-text" />
                  <!-- <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-shop-code"
                  /> -->
                </div>
              </th>
              <th class="col-15" fieldName="shopCode">
                <div class="thead-text">Tên hàng hóa</div>
                <div class="thead-filter order-bill-id-input">
                  <button class="t-btn condition">*</button>
                  <input type="text" class="t-input filter-text" />
                  <!-- <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-shop-code"
                  /> -->
                </div>
              </th>
              <th class="col-12" fieldName="status">
                <div class="thead-text">Đơn vị tính</div>
                <div class="thead-filter">
                  <select type="text" class="filter-select" id="filter-status">
                    <option>
                      Cái
                    </option>
                  </select>
                </div>
              </th>
              <th class="col-21" fieldName="shopName">
                <div class="thead-text">Số lượng đặt</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <input type="text" class="t-input filter-text" />
                  <!-- <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-shop-name"
                  /> -->
                </div>
              </th>
              <th class="col-42" fieldName="address">
                <div class="thead-text">Số lượng nhập</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <!-- <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-address"
                  /> -->
                  <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-address"
                  />
                </div>
              </th>

              <th class="col-10" fieldName="phoneNumber">
                <div class="thead-text">Đơn giá</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <input type="text" class="t-input filter-text" />
                  <!-- <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-phone-number"
                  /> -->
                </div>
              </th>

              <th class="col-42" fieldName="address">
                <div class="thead-text">Thành tiền</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <input type="text" class="t-input filter-text" />
                  <!-- <input
                    type="text"
                    class="t-input filter-text"
                    id="filter-address"
                  /> -->
                </div>
              </th>
              <th class="col-15"></th>
            </tr>
          </thead>

          <tbody class="tbl-scroll">
            <tr
              class="row-data"
              v-for="element in this.arrayDetail"
              :key="element.sku"
            >
              <td class="col-15">{{ element.sku }}</td>
              <td class="col-15">{{ element.name }}</td>
              <td class="col-21">{{ element.unit }}</td>
              <td class="col-42 txt-money">{{ element.quality }}</td>
              <td class="col-10 txt-total txt-money">0</td>
              <td class="col-12 txt-money">
                {{ element.prince | formatMoney }}
              </td>
              <td class="col-42 txt-money">
                {{ (element.prince * element.quality) | formatMoney }}
              </td>
              <td class="col-15">
                <div class="icon-delete-table"></div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="totalfooter create-footer">
        <div class="total-content">
          <div style="margin-right: 370px;">
            <span style="margin-right:15px">Số dòng</span>
            <span>0</span>
          </div>
          <div style="margin-right:30px">
            <span style="margin-right:15px"> Tổng số lương</span>
            <span>0</span>
          </div>
          <div>
            <span style="margin-right:15px"> Thành tiền</span>
            <span>0</span>
          </div>
        </div>
      </div>
    </div>
  </BaseModalForm>
</template>

<script>
import moment from "moment";
import axios from "axios";
import BaseModalForm from "../../layout/BaseModalForm";
export default {
  components: {
    BaseModalForm,
  },
  props: {
    selectedObjectId: String,
    formMode: String,
  },
  data() {
    return {
      isReadOnlyInput: false,
      object: "",
      currentObject: {},
      arrayDetail: [],
      arrayStatus: [
        { value: 0, text: "Chưa thực hiện" },
        { value: 1, text: "Đang thực hiện" },
        { value: 2, text: "Đã thực hiện" },
      ],
    };
  },
  watch: {},
  created() {},
  filters: {
    fnFormatDate: function(dateInput) {
      return moment(String(dateInput)).format("DD/MM/YYYY");
    },
    formatMoney: function(money) {
      if (money != null)
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
      else return "0";
      return num;
    },
  },
  methods: {
    fnFormatDate: function(dateInput) {
      return moment(String(dateInput)).format("DD/MM/YYYY");
    },
    reSetform() {
      this.currentObject = {};
      this.arrayDetail = [];
      this.isReadOnlyInput = false;
    },
    hide() {
      this.$refs.BaseForm_ref.hide();
      this.reSetform();
    },
    show() {
      if (this.formMode == "update" || this.formMode == "watch") {
        if (this.formMode == "watch") {
          this.isReadOnlyInput = true;
        }
        axios
          .get(
            "http://localhost:35480/api/v1/OrderBills/" + this.selectedObjectId
          )
          .then((respone) => {
            this.currentObject = respone.data.data;
            if (this.currentObject.detail) {
              this.arrayDetail = JSON.parse(
                JSON.parse(this.currentObject.detail)
              );
            }
            this.currentObject.orderDate = this.fnFormatDate(
              this.currentObject.orderDate
            );
            //  console.log(this.currentObject.orderDate);
          })
          .catch((error) => console.log(error));
      }
      this.$refs.BaseForm_ref.show();
    },
  },
};
</script>

<style>
@import url("../../../styles/base/formCreate.css");
@import "../../../styles/layout/toolbar.css";
.totalfooter {
  position: absolute;
  bottom: 3px;
  width: 100%;
  height: 29px;
  padding-right: 100px;
}
.totalfooter span {
  font-weight: 700;
  font-size: 12px;
  color: #212121;
}
.total-content {
  display: flex;
  top: 7px;
  position: absolute;
}

.create-footer {
  background-color: #ccc;
  left: 8px;
  bottom: 8px;
  height: 40px;
  right: 8px;
  width: 88%;
}
.t-grid-create {
  top: 391px !important;
  left: 8px !important;
  right: 8px !important;
  width: 959px !important;
  height: 279px !important;
}
.icon-delete-table {
  background-image: url(/img/common-icon.6cf6ba71.png);
  background-repeat: no-repeat;
  height: 16px;
  background-position: -2px -2px;
}
.icon-delete-table :hover {
  background-image: url(/img/common-icon.6cf6ba71.png);
  background-repeat: no-repeat;
  height: 16px;
  background-position: -232px -322px;
}
.toolbar-create {
  top: 74px !important;
}
.btn-chose {
  width: 200px !important;
  padding-left: 40px;
  top: 9px !important;
  left: 15px !important;
  font-size: 11px !important;
}

.action-table {
  position: absolute;
  top: 360px;
  width: 96%;
  height: 30px;
  padding: 10px 0px 0px 16px;
}
.action-table label {
  font: 600 15px Roboto !important;
  color: #757575;
  text-transform: uppercase;
}
.t-icon-add-col-table {
  position: absolute;
  background-position-y: -127px;
  background-position-x: -23px;
  cursor: pointer;
  right: 0px;
}
.info-bill {
  display: flex;
  position: absolute;
  top: 127px;
  width: 100%;
  height: 220px;
  padding: 8px 0px 0px 18px;
}
.info-bill label {
  font: 600 15px Roboto !important;
  color: #757575;
  text-transform: uppercase;
}
.input-create {
  border-radius: 4px;
  height: 35px;
  font-size: 13px;
  border: 1px solid #bbbbbb;
  padding-left: 12px;
  box-sizing: border-box;
  outline: none;
  width: 195px;
  margin-right: 4px;
}
.input-create:focus {
  border: 1px solid #636dde;
}
.row-side {
  margin: 10px 0px 8px 6px;
}
.row-side-2 {
  margin-top: 8px;
}
.info-bill-right {
  margin-left: 15px;
}
.date-pick-create {
  padding-left: 8px;
  outline: none;
  height: 33px;
  width: 126px;
  border-radius: 4px;
  border: 1px solid #bbbbbb;
}
.date-pick-create:focus {
  border: 1px solid #636dde;
}
.select-datetime-create {
  width: 136px;
  border-radius: 4px;
  height: 35px;
  font-size: 13px;
  border: 1px solid #bbbbbb;
  padding-left: 8px;
  padding-bottom: 1px;
  box-sizing: border-box;
  outline: none;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAkAAAAECAQAAAD2Bt1FAAAAMklEQVR42mNQDFX8r9jBAAaKqxT/KyqBGGmK/xXLGRgUZyr+V3RhgMqCBM8gCcAFoQIAgcYPEVUyFEIAAAAASUVORK5CYII=);
  background-repeat: no-repeat;
  background-position-x: calc(100% - 8px);
  background-position-y: 15px;
  background-size: 9px;
  appearance: none;
}
.select-datetime-create:focus {
  border: 1px solid #636dde;
}

.txt-money {
  text-align: right !important;
}
</style>
