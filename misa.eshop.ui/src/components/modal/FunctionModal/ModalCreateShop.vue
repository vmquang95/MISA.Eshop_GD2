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
              key="['esc']"
              @click="openModalSave()"
            ></button>
          </div>
        </div>
      </div>
      <!-- toolbar 1 -->
      <div class="tool-bar" style="height:32px">
        <div class="tool-bar-btn div-btn-add">
          <button class="t-btn btn-add click-outside btn-hidden" id="btn-add">
            <i class="t-icon t-icon-prev"></i>
            <span>Trước</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-replication ">
          <button
            disabled
            class="t-btn btn-replication t-btn-disable btn-hidden"
            id="btn-replication"
          >
            <span>Sau</span>
            <i class="t-icon t-icon-next"></i>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-edit">
          <button class="t-btn btn-edit t-btn-disable isActive" id="btn-edit">
            <i class="t-icon t-icon-add"></i>
            <span>Thêm mới</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-edit">
          <button class="t-btn btn-edit t-btn-disable isActive" id="btn-edit">
            <i class="t-icon t-icon-edit"></i>
            <span>Sửa</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-delete">
          <button
            @click="save()"
            class="t-btn btn-delete t-btn-disable isActive"
            id="btn-delete"
          >
            <i class="t-icon t-icon-save"></i>
            <span>Lưu</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button
            class="t-btn btn-load isActive"
            id="btn-load"
            style="opacity:0.5"
          >
            <i class="t-icon t-icon-delete"></i>
            <span>Xóa</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load btn-hidden" id="btn-load">
            <i class="t-icon t-icon-pause"></i>
            <span>Hoãn</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load btn-hidden" id="btn-load">
            <i class="t-icon t-icon-print"></i>
            <span>In</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load btn-hidden" id="btn-load">
            <i class="t-icon t-icon-export"></i>
            <span>Xuất Khẩu</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button class="t-btn btn-load btn-hidden" id="btn-load">
            <i class="t-icon t-icon-help"></i>
            <span>Trợ giúp</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-load">
          <button
            @click="openModalSave()"
            class="t-btn btn-load isActive"
            id="btn-load"
          >
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
              ref="RefSupplierCode"
              v-if="isReadOnlyInput"
              readonly
              class="input-create"
              type="text"
              v-model="currentObject.supplierCode"
              style="background-color: #e5e6eb;"
              placeholder="Mã nhà cung cấp"
            />
            <input
              v-else
              ref="RefSupplierCode"
              class="input-create"
              type="text"
              v-model="currentObject.supplierCode"
              placeholder="Mã nhà cung cấp"
            />
            <input
              v-if="isReadOnlyInput"
              readonly
              class="input-create"
              type="text"
              style="background-color: #e5e6eb; width:390px"
              v-model="currentObject.supplierName"
              placeholder="Tên nhà cung cấp"
            />
            <input
              v-else
              class="input-create"
              type="text"
              style="width:390px"
              v-model="currentObject.supplierName"
              placeholder="Tên nhà cung cấp"
            />
          </div>
          <div class="row-side row-side-2">
            <span style="margin-right: 37px;">Người đặt</span>
            <input
              v-if="!isReadOnlyInput"
              class="input-create"
              type="text"
              v-model="currentObject.customerCode"
              placeholder="Mã người đặt"
            />
            <input
              v-else
              class="input-create"
              type="text"
              v-model="currentObject.customerCode"
              readonly
              style="background-color: #e5e6eb;"
              placeholder="Mã người đặt"
            />
            <input
              v-if="!isReadOnlyInput"
              class="input-create"
              type="text"
              style="width:390px"
              v-model="currentObject.customerName"
              placeholder="Tên người đặt"
            />
            <input
              v-else
              class="input-create"
              type="text"
              style="width:390px; background-color: #e5e6eb;"
              v-model="currentObject.customerName"
              readonly
              placeholder="Tên người đặt"
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
          <div
            class="row-side"
            style="display: flex;margin-top: 8px;align-items: center;"
          >
            <span style="margin-right: 6px;">Ngày đặt hàng</span>
            <!-- <input
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
            /> -->
            <datepicker
              v-if="!isReadOnlyInput"
              input-class="input-orderDate date-pick-create"
              v-model="currentObject.orderDate"
              format="dd/MM/yyyy"
            ></datepicker>
            <datepicker
              v-else
              :disabled="true"
              input-class="input-orderDate date-pick-create inputblock"
              v-model="currentObject.orderDate"
              format="dd/MM/yyyy"
            ></datepicker>
            <!-- <date-picker v-model="currentObject.orderDate" format="DD-MM-YYYY"></date-picker> -->
          </div>
          <div class="row-side" style="margin-top:8px">
            <span style="margin-right: 32px;">Trạng thái</span>
            <select
              v-if="!isReadOnlyInput"
              class="select-datetime-create"
              v-model="currentObject.status"
            >
              <option
                v-for="element in arrayStatus"
                :key="element.value"
                :value="element.value"
                >{{ element.text }}</option
              >
            </select>
            <select
              v-else
              disabled
              class="select-datetime-create inputblock"
              style="background-color: #e5e6eb;"
              v-model="currentObject.status"
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
        <i
          v-if="!isReadOnlyInput"
          class="t-icon t-icon-add-col-table"
          style="min-width: 31px;"
          @click="addNewColumDetail()"
        ></i>
      </div>

      <!-- grid -->
      <div class="t-grid t-grid-create">
        <table id="tbl-list-store" cellspacing="0" cellpadding="0" width="100%">
          <thead>
            <tr>
              <th class="col-15 colum-sku">
                <div class="thead-text">Mã SKU</div>
                <div class="thead-filter order-date-input">
                  <button class="t-btn condition">*</button>
                  <input
                    disabled
                    type="text"
                    class="t-input filter-text filter-text-create"
                  />
                </div>
              </th>
              <th class="col-15" fieldName="shopCode">
                <div class="thead-text">Tên hàng hóa</div>
                <div class="thead-filter order-bill-id-input">
                  <button class="t-btn condition">*</button>
                  <input
                    disabled
                    type="text"
                    class="t-input filter-text filter-text-create"
                  />
                </div>
              </th>
              <th class="col-12 colum-unit" fieldName="status">
                <div class="thead-text">Đơn vị tính</div>
                <div class="thead-filter">
                  <select
                    disabled
                    type="text"
                    class="filter-select"
                    id="filter-status"
                  >
                  </select>
                </div>
              </th>
              <th class="col-21 colum-quality" fieldName="shopName">
                <div class="thead-text">Số lượng đặt</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <input
                    disabled
                    type="text"
                    class="t-input filter-text filter-text-create"
                  />
                </div>
              </th>
              <th class="col-42 colum-quality" fieldName="address">
                <div class="thead-text">Số lượng nhập</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>

                  <input
                    disabled
                    type="text"
                    class="t-input filter-text filter-text-create"
                    id="filter-address"
                  />
                </div>
              </th>

              <th
                class="col-10 colum-prince"
                fieldName="phoneNumber"
                style="min-width: 158px;"
              >
                <div class="thead-text">Đơn giá</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <input
                    disabled
                    type="text"
                    class="t-input filter-text filter-text-create"
                  />
                </div>
              </th>

              <th class="col-42" fieldName="address">
                <div class="thead-text">Thành tiền</div>
                <div class="thead-filter">
                  <button class="t-btn condition">*</button>
                  <input
                    disabled
                    type="text"
                    class="t-input filter-text filter-text-create"
                  />
                </div>
              </th>
              <th v-show="!isReadOnlyInput" class="col-15"></th>
            </tr>
          </thead>

          <tbody class="tbl-scroll">
            <tr
              class="row-data"
              v-for="(element, index) in this.arrayDetail"
              :key="index"
            >
              <td class="col-15 colum-sku" style="padding:0;">
                <input
                  :disabled="isReadOnlyInput"
                  class="input-table-detail ip-sku"
                  type="text"
                  v-model="element.sku"
                  style=" width:88%"
                />
              </td>
              <td class="col-15" style="padding:0">
                <input
                  :disabled="isReadOnlyInput"
                  class="input-table-detail"
                  type="text"
                  v-model="element.name"
                />
              </td>
              <td class="col-21 colum-unit" style="padding:0">
                <select
                  :disabled="isReadOnlyInput"
                  type="text"
                  class="filter-select select-unit"
                  id="filter-status"
                  v-model="element.unit"
                >
                  <option
                    v-for="item in arrayUnit"
                    :key="item.value"
                    :value="item.value"
                    >{{ item.text }}</option
                  >
                </select>
                <!-- <input class="input-table-detail input-prince txt-money" type="text" v-model="element.unit"> -->
              </td>
              <td class="col-42 txt-money colum-quality" style="padding:0">
                <input
                  style="width: 82%;"
                  :disabled="isReadOnlyInput"
                  class="input-table-detail txt-money"
                  type="number"
                  min="1"
                  v-model="element.quality"
                  @keypress="formatPressNumber($event)"
                />
              </td>
              <td
                class="col-10 txt-total txt-money colum-quality"
                style="padding:0"
              >
                <input
                  disabled
                  class="input-table-detail txt-money"
                  type="text"
                  value="0"
                  readonly
                  style="background-color:#e1e1e1;"
                />
              </td>
              <td
                class="col-12 txt-money colum-prince"
                style="padding: 1px 0 0 0"
              >
                <!-- <input
                  :disabled="isReadOnlyInput"
                  class="input-table-detail input-prince txt-money"
                  type="text"
                  v-model="element.prince"
                  @keypress="formatPressNumber($event)"
                /> -->
                <money
                  class="txt-money input-prince-money"
                  :disabled="isReadOnlyInput"
                  v-model="element.prince"
                  v-bind="money"
                ></money>
              </td>
              <td class="col-42 txt-money" style="padding:0 8px 0 0">
                <span>
                  {{ (element.prince * element.quality) | formatMoney }}
                </span>
              </td>

              <td
                v-show="!isReadOnlyInput"
                class="col-15"
                style="width:30px; padding:0"
              >
                <div
                  class="icon-delete-table"
                  @click="deleteRowDetail(index)"
                ></div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="totalfooter create-footer">
        <div class="total-content">
          <div style="margin-right: 370px;">
            <span style="margin-right:15px">Số dòng</span>
            <span>{{ arrayDetail.length }}</span>
          </div>
          <div style="margin-right:30px">
            <span style="margin-right:15px"> Tổng số lương</span>
            <span>{{ getTotalQuality() }}</span>
          </div>
          <div>
            <span style="margin-right:15px"> Thành tiền</span>
            <span>{{ getTotalMoney() | formatMoney }}</span>
          </div>
        </div>
      </div>
    </div>
    <ModelSave ref="ModalSave" @hide="hide" @onSave="save" />
    <ModalValidate ref="ModalValidate" :message="message" />
  </BaseModalForm>
</template>

<script>
// import DatePicker from 'vue2-datepicker';
//   import 'vue2-datepicker/index.css';
import Datepicker from "vuejs-datepicker";
import { Money } from "v-money";
import moment from "moment";
import axios from "axios";
import BaseModalForm from "../../layout/BaseModalForm";
import ModelSave from "../FunctionModal/ModelSave.vue";
import ModalValidate from "../FunctionModal/ModalValidate.vue";

export default {
  components: {
    BaseModalForm,
    ModelSave,
    ModalValidate,
    Money,
    Datepicker,
    // DatePicker
  },
  props: {
    selectedObjectId: String,
    formMode: String,
  },
  data() {
    return {
      message: "",
      index: 0,
      isReadOnlyInput: false,
      currentObject: {
        detail: "",
        orderDate: this.fnFormatDateInput(new Date()),
        status: 0,
      },
      arrayDetail: [],
      arrayStatus: [
        { value: 0, text: "Chưa thực hiện" },
        { value: 1, text: "Đang thực hiện" },
        { value: 2, text: "Đã thực hiện" },
      ],
      arrayUnit: [
        { value: 0, text: "Tấn" },
        { value: 1, text: "Tạ" },
        { value: 2, text: "Yến" },
        { value: 3, text: "Kg" },
        { value: 4, text: "Chiếc" },
        { value: 5, text: "Cái" },
      ],
      money: {
        decimal: ",",
        thousands: ".",
        precision: 0,
        masked: false,
      },
    };
  },
  mounted() {
    clearTimeout(this.timeOut);
    this.timeOut = setTimeout(() => {
      this.$refs.RefSupplierCode.focus();
    }, 300);
  },
  created() {},
  filters: {
    formatMoney: function(money) {
      if (money != null)
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
      else return "0";
      return num;
    },
  },
  methods: {
    openModalValidate() {
      this.$refs.ModalValidate.show();
    },
    /**
     * Lấy tổng tiền.
     */
    getTotalMoney() {
      let sum = 0;
      this.arrayDetail.forEach((element) => {
        sum += element.quality * element.prince;
      });
      return sum;
    },
    /**
     * Lấy tổng số lượng đặt hàng hàng từ 1 chi tiết orerbill
     */
    getTotalQuality() {
      var sumQuality = 0;
      this.arrayDetail.forEach((element) => {
        sumQuality += parseInt(element.quality);
      });
      return sumQuality;
    },
    /**
     * Chỉ cho phép nhập số.
     */
    formatPressNumber(e) {
      let key = e.key;
      if (!/^\d+/g.test(key)) {
        e.preventDefault();
      }
    },
    /**
     * Event mở mocal save, báo dữ liệu thay đổi
     */
    openModalSave() {
      if (this.formMode == "watch") {
        this.hide();
      }
      this.$refs.ModalSave.show();
    },
    /**
     * Format date bind vào input
     * CreateBy:vmquang(21/04/2021)
     */
    fnFormatDateInput: function(dateInput) {
      return moment(dateInput).format("YYYY-MM-DD");
    },

    /**
     * Xóa 1 row ở table detail
     */
    deleteRowDetail(index) {
      this.arrayDetail.pop(this.arrayDetail[index]);
      // this.arrayDetail = this.arrayDetail.filter(function(obj) {
      //   return obj.sku != idSku;
      // });
    },
    addNewColumDetail() {
      let item = {
        sku: "",
        unit: 4,
        quality: 1,
        prince: 1000,
      };
      this.arrayDetail.push(item);
      // console.log(this.arrayDetail.length);
      // console.log(document.getElementsByClassName("ip-sku").item(this.arrayDetail.length-1));
      // console.log(this.arrayDetail[this.arrayDetail.length -1]);
    },
    checkEmptyValue(value) {
      if (value === "" || !value) {
        return true;
      }
      return false;
    },
    removeSpaces(value) {
      if (value) {
        this.value = value.replace(/\s+/g, "");
      }
    },
    ConvertData() {
      this.removeSpaces(this.currentObject.supplierCode);
      this.removeSpaces(this.currentObject.supplierName);
      this.removeSpaces(this.currentObject.customerCode);
      this.removeSpaces(this.currentObject.customerName);
      this.removeSpaces(this.currentObject.description);
      this.removeSpaces(this.currentObject.refCode);
    },
    save() {
      if (this.formMode === "insert") {
        this.ConvertData();
        axios
          .get("http://localhost:35480/api/v1/OrderBills/getbycode", {
            params: {
              refCode: this.currentObject.refCode,
            },
          })
          .then((respone) => {
            if (respone.data.data) {
              this.openModalValidate();
              this.message = "Mã phiếu đã trùng, thử lại với mã khác";
              return;
            }
          })
          .catch((error) => {
            console.log(error);
          });
        if (
          this.checkEmptyValue(this.currentObject.supplierCode) ||
          this.checkEmptyValue(this.currentObject.supplierName)
        ) {
          this.openModalValidate();
          this.message = "Không được bỏ trống Mà nhà cung cấp";
          return;
        }
        if (
          this.checkEmptyValue(this.currentObject.customerCode) ||
          this.checkEmptyValue(this.currentObject.customerName)
        ) {
          this.openModalValidate();
          this.message = "Không được bỏ trống người đặt";
          return;
        }
        if (this.checkEmptyValue(this.currentObject.orderDate)) {
          this.openModalValidate();
          this.message = "Không được bỏ trống ngày đặt";
          return;
        }
        if (this.checkEmptyValue(this.currentObject.refCode)) {
          this.openModalValidate();
          this.message = "Không được bỏ trống Phiếu đặt hàng";
          return;
        }
        this.deleteObjectInCorrect();
        if (this.arrayDetail.length < 1) {
          this.openModalValidate();
          this.message = "Phải có ít nhất 1 hàng hóa.";
          let item = {
            sku: "",
            unit: 4,
            quality: 1,
            prince: 1000,
          };
          this.arrayDetail.push(item);
          return;
        }
        this.currentObject.detail = JSON.stringify(this.arrayDetail);
        console.log("Che do Insert");
        axios
          .post("http://localhost:35480/api/v1/OrderBills", this.currentObject)
          .then((response) => {
            console.log("Insert thanh cong", response);
            this.hide();
            this.$emit("loadData");
          })
          .catch((error) => {
            console.log(error.data);
          });
      } else if (this.formMode === "update") {
        console.log("Che do update");
        this.ConvertData();
        if (
          this.checkEmptyValue(this.currentObject.supplierCode) ||
          this.checkEmptyValue(this.currentObject.supplierName)
        ) {
          this.openModalValidate();
          this.message = "Không được bỏ trống Mà nhà cung cấp";
          return;
        }
        if (
          this.checkEmptyValue(this.currentObject.customerCode) ||
          this.checkEmptyValue(this.currentObject.customerName)
        ) {
          this.openModalValidate();
          this.message = "Không được bỏ trống người đặt";
          return;
        }
        if (this.checkEmptyValue(this.currentObject.orderDate)) {
          this.openModalValidate();
          this.message = "Không được bỏ trống ngày đặt";
          return;
        }
        if (this.checkEmptyValue(this.currentObject.refCode)) {
          this.openModalValidate();
          this.message = "Không được bỏ trống Phiếu đặt hàng";
          return;
        }
        this.deleteObjectInCorrect();
        if (this.arrayDetail.length < 1) {
          this.openModalValidate();
          this.message = "Phải có ít nhất 1 hàng hóa.";
          let item = {
            sku: "",
            unit: 4,
            quality: 1,
            prince: 1000,
          };
          this.arrayDetail.push(item);
          return;
        }
        this.currentObject.detail = JSON.stringify(this.arrayDetail);
        axios
          .put(
            `http://localhost:35480/api/v1/OrderBills/${this.selectedObjectId}`,
            this.currentObject
          )
          .then((response) => {
            console.log("update thanh cong", response);
            this.hide();
            this.$emit("loadData");
          })
          .catch((error) => {
            console.log(error.data);
          });
      } else if (this.formMode === "watch") {
        console.log("Che do watch");
        this.hide();
      } else {
        return;
      }
    },

    /**
     * Hàm này delete những phần tử  {} trong mảng arrayDetail
     */
    deleteObjectInCorrect() {
      this.arrayDetail = this.arrayDetail.filter(function(obj) {
        return obj.sku != "";
      });
    },
    /**
     * resert form
     */
    reSetform() {
      this.currentObject = {};
      this.arrayDetail = [];
      this.isReadOnlyInput = false;
    },
    /**
     * ẩn form
     */
    hide() {
      this.$refs.BaseForm_ref.hide();
      this.reSetform();
      this.$emit("showDialogFn");
    },
    /**
     * hiển thị form
     */
    async show() {
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
            this.currentObject.orderDate = this.fnFormatDateInput(
              this.currentObject.orderDate
            );
            if (this.currentObject.detail) {
              this.arrayDetail = JSON.parse(this.currentObject.detail);
            }
          })
          .catch((error) => console.log(error));
      } else if (this.formMode == "insert") {
        await axios
          .get("http://localhost:35480/api/v1/OrderBills/GetNewRefCode")
          .then((respone) => {
            this.currentObject.refCode = respone.data.data;
          })
          .catch((error) => console.log(error));

        if (this.selectedObjectId) {
          axios
            .get(
              "http://localhost:35480/api/v1/OrderBills/" +
                this.selectedObjectId
            )
            .then((respone) => {
              this.currentObject.supplierCode = respone.data.data.supplierCode;
              this.currentObject.supplierName = respone.data.data.supplierName;
              this.currentObject.customerCode = respone.data.data.customerCode;
              this.currentObject.customerName = respone.data.data.customerName;
              this.currentObject.detail = respone.data.data.detail;
              this.arrayDetail = JSON.parse(this.currentObject.detail);
              this.currentObject.description = respone.data.data.description;
              this.currentObject.orderDate = respone.data.data.orderDate;
              this.currentObject.status = respone.data.data.status;
              
            })
            .catch((error) => console.log(error));
        } else {
          this.arrayDetail = [
            {
              sku: "",
              unit: 4,
              quality: 1,
              prince: 1000,
            },
          ];
        }
      }
      this.$refs.BaseForm_ref.show();
    },
  },
};
</script>

<style sco>
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
  background-position: 14px -2px;
  width: 40px;
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
.input-table-detail {
  border: none;
  background: transparent;
  outline: none;
  padding: 7px 10px 6px;
  width: 86%;
  height: 19px;
}
.input-table-detail:focus {
  height: 17px;
  border: 1px solid #636dde;
  border-radius: 4px;
  background-color: #ffff;
}
.btn-hidden {
  cursor: auto !important;
  opacity: 0.5;
}
.colum-unit {
  min-width: 89px !important;
}
.colum-quality {
  min-width: 119px !important;
}
.colum-prince {
  min-width: 99px !important;
}
.colum-sku {
  min-width: 150px !important;
}
.input-prince {
  width: 76%;
}
.select-unit {
  border: none !important;
  height: 100% !important;
}
.select-unit:focus {
  border: 1px solid #636dde !important;
  border-radius: 4px;
}
.input-prince-money {
  border: none;
  height: 100%;
  border-radius: 4px;
  width: 100%;
}
.input-prince-money:focus {
  border: 1px solid #636dde !important;
}
.filter-text-create {
  height: 32px !important;
}
.input-orderDate {
  height: 35px;
  border-radius: 4px;
  border: 1px solid #bbbbbb;
  width: 135px !important;
  padding-left: 12px;
}
.inputblock {
  background-color: rgb(229, 230, 235);
}
</style>
