<template>
  <BaseModalForm ref="BaseForm_ref">
    <div class="dialog-form form-add-edit">
      <!-- header -->
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div
            v-if="formMode == this.$Const.INSERT"
            class="dialog-title"
            id="dialog-title"
          >
            {{ this.$Const.TITLE_FORM_INSERT }}
          </div>
          <div
            v-else-if="formMode == this.$Const.UPDATE"
            class="dialog-title"
            id="dialog-title"
          >
            {{ this.$Const.TITLE_FORM_UPDATE }}
          </div>
          <div v-else class="dialog-title" id="dialog-title">
            {{ this.$Const.TITLE_FORM_WATCH }}
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
          <button class="t-btn btn-edit t-btn-disable btn-hidden" id="btn-edit">
            <i class="t-icon t-icon-add"></i>
            <span>Thêm mới</span>
          </button>
        </div>
        <div class="tool-bar-btn div-btn-edit">
          <button
            :disabled="this.formMode != this.$Const.WATCH"
            :class="
              this.formMode === this.$Const.WATCH ? 'isActive' : 'btn-hidden'
            "
            @click="changeToUpdateObject()"
            class="t-btn btn-edit t-btn-disable "
            id="btn-edit"
          >
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
        <button v-if="!isReadOnlyInput" @click="addNewColumDetail()" class="btn-quang btn-chose btn-action-table">
          <span>Thêm hàng</span>
        </button>
        <!-- <i
          v-if="!isReadOnlyInput"
          class="t-icon t-icon-add-col-table"
          style="min-width: 31px;"
          @click="addNewColumDetail()"
        ></i> -->
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
                  @keypress="formatPressNumber($event, element.quality)"
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
  },
  props: {
    selectedObjectId: String,
    formMode: String,
  },
  data() {
    return {
      trashData: "",
      message: "",
      index: 0,
      isReadOnlyInput: false,
      currentObject: {
        refCode: "",
        supplierName: "",
        supplierCode: "",
        customerCode: "",
        customerName: "",
        description: "",
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
      itemDefault: {
        sku: "",
        name: "",
        unit: 4,
        quality: 1,
        prince: 1000,
      },
    };
  },
  mounted() {
    clearTimeout(this.timeOut);
    this.timeOut = setTimeout(() => {
      this.$refs.RefSupplierCode.focus();
    }, 400);
  },
  created() {},
  filters: {
    /**
     * Hàm filter tiền.
     * created vmquang 14/6/2021
     */
    formatMoney: function(money) {
      if (money != null)
        var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
      else return "0";
      return num;
    },
  },

  methods: {
    /**
     * Hàm đổi từ form xem sang sửa đối tượng
     * created vmquang 14/6/2021
     */
    changeToUpdateObject() {
      this.formMode = this.$Const.UPDATE;
      this.isReadOnlyInput = false;
    },
    /**
     * Hàm reset mảng chứa chi tiết đơn hàng
     * created vmquang 14/6/2021
     */
    resetArrayDetail() {
      this.arrayDetail = [
        {
          sku: "",
          unit: 4,
          name: "",
          quality: 1,
          prince: 1000,
        },
      ];
    },
    /**
     * Hàm convert nội dung của chi teeits đơn hàng
     * created vmquang 14/6/2021
     */
    convertArrayDetail() {
      this.arrayDetail.forEach((element) => {
        element.sku = element.sku.toUpperCase();
        element.sku = element.sku.replace(/\s+/g, "");
        element.name = element.name.trim();
        element.name = element.name.replace(/\s+/g, " ");
      });
    },

    /**
     * Hàm convert dữ liệu người dùng nhập vào.
     * created vmquang 14/6/2021
     */
    convertDataObject() {
      this.currentObject.refCode = this.currentObject.refCode.toUpperCase();
      this.currentObject.supplierCode = this.currentObject.supplierCode.toUpperCase();
      this.currentObject.customerCode = this.currentObject.customerCode.toUpperCase();
      this.currentObject.refCode = this.currentObject.refCode.replace(
        /\s+/g,
        ""
      );
      this.currentObject.supplierCode = this.currentObject.supplierCode.replace(
        /\s+/g,
        ""
      );
      this.currentObject.customerCode = this.currentObject.customerCode.replace(
        /\s+/g,
        ""
      );
      this.currentObject.customerName = this.currentObject.customerName.trim();
      this.currentObject.supplierName = this.currentObject.supplierName.trim();
      this.currentObject.description = this.currentObject.description.trim();
      this.currentObject.customerName = this.currentObject.customerName.replace(
        /\s+/g,
        " "
      );
      this.currentObject.supplierName = this.currentObject.supplierName.replace(
        /\s+/g,
        " "
      );
      this.currentObject.description = this.currentObject.description.replace(
        /\s+/g,
        " "
      );

      this.currentObject.customerName = this.currentObject.customerName
        .toLowerCase()
        .replace(/\b[a-z]/g, function(letter) {
          return letter.toUpperCase();
        });
    },
    /**
     * Hàm mở THông báo validate.
     * created vmquang 14/6/2021
     */
    openModalValidate() {
      this.$refs.ModalValidate.show();
    },
    /**
     * Hàm mở thông báo validte kèm nội dung message
     * created vmquang 14/6/2021
     */
    openFormAlertValidate(text) {
      this.$refs.ModalValidate.show();
      this.message = text;
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
    formatPressNumber(e, value) {
      let key = e.key;
      if (!/^\d+/g.test(key) || value.length > 9) {
        e.preventDefault();
      }
    },
    /**
     * Event mở mocal save, báo dữ liệu thay đổi
     */
    openModalSave() {
      if (this.formMode == this.$Const.WATCH) {
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
      this.arrayDetail.splice(index, 1);
    },
    /**
     * Hàm thêm mới 1 hàng hóa ở chi tiết đơn hàng.
     * created vmquang 14/6/2021
     */
    addNewColumDetail() {
      let item = {
        sku: "",
        name: "",
        unit: 4,
        quality: 1,
        prince: 1000,
      };
      this.arrayDetail.push(item);
    },
    /**
     * Kiểm tra null hoặc emtpy 1 dữ liệu.
     * created vmquang 14/6/2021
     */
    checkEmptyValue(value) {
      if (value === "" || !value) {
        return true;
      }
      return false;
    },
    /**
     * hàm xóa dấu cách
     * created vmquang 14/6/2021
     */
    removeSpaces(value) {
      if (value) {
        this.value = value.replace(/\s+/g, "");
      }
    },
    /**
     * Hàm check xem dữ liệu Nhà cung cấp có đúng không ?
     * created vmquang 14/6/2021
     */
    inCorrectSupplierInput() {
      if (
        this.checkEmptyValue(this.currentObject.supplierCode) ||
        this.checkEmptyValue(this.currentObject.supplierName)
      ) {
        return true;
      }
      return false;
    },

    /**
     * Hàm sự kiện nút lưu
     * created vmquang 14/6/2021
     */
    save() {
      this.convertArrayDetail();
      this.convertDataObject();
      if (this.formMode === this.$Const.INSERT) {
        axios
          .get(`${this.$Const.API_HOST}/api/v1/OrderBills/getbycode`, {
            params: {
              refCode: this.currentObject.refCode,
            },
          })
          .then((respone) => {
            if (respone.data.data) {
              this.openFormAlertValidate(this.$Const.MESSAGE_DUPLICATE_REFCODE);
              return;
            }
          })
          .catch((error) => {
            this.trashData = error;
          });
        if (this.inCorrectSupplierInput()) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_SUPPLIER);
          return;
        }
        if (
          this.checkEmptyValue(this.currentObject.customerCode) ||
          this.checkEmptyValue(this.currentObject.customerName)
        ) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_CUSTOMER);
          return;
        }
        if (this.checkEmptyValue(this.currentObject.orderDate)) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_ORDERDATE);
          return;
        }
        if (this.checkEmptyValue(this.currentObject.refCode)) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_REFCODE);
          return;
        }
        this.deleteObjectInCorrect();
        if (this.arrayDetail.length < 1) {
          this.openFormAlertValidate(this.$Const.MESSAGE_NOEXIST_ITEM);
          this.arrayDetail.push(this.itemDefault);
          return;
        }
        this.currentObject.detail = JSON.stringify(this.arrayDetail);
        axios
          .post(`${this.$Const.API_HOST}/api/v1/OrderBills`, this.currentObject)
          .then((response) => {
            this.trashData = response;
            this.hide();
            this.$emit("loadData");
          })
          .catch((error) => {
            this.trashData = error;
          });
      } else if (this.formMode === this.$Const.UPDATE) {
        axios
          .get(
            `${this.$Const.API_HOST}/api/v1/OrderBills/CheckDupliCateRefCode`,
            {
              params: {
                refCode: this.currentObject.refCode,
                id: this.currentObject.orderBillId,
              },
            }
          )
          .then((respone) => {
            if (respone.data.data) {
              this.openFormAlertValidate(this.$Const.MESSAGE_DUPLICATE_REFCODE);
              return;
            }
          })
          .catch((error) => {
            this.trashData = error;
          });
        if (
          this.checkEmptyValue(this.currentObject.supplierCode) ||
          this.checkEmptyValue(this.currentObject.supplierName)
        ) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_SUPPLIER);
          return;
        }
        if (
          this.checkEmptyValue(this.currentObject.customerCode) ||
          this.checkEmptyValue(this.currentObject.customerName)
        ) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_CUSTOMER);
          return;
        }
        if (this.checkEmptyValue(this.currentObject.orderDate)) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_ORDERDATE);
          return;
        }
        if (this.checkEmptyValue(this.currentObject.refCode)) {
          this.openFormAlertValidate(this.$Const.MESSAGE_EMPTY_REFCODE);
          return;
        }
        this.deleteObjectInCorrect();
        if (this.arrayDetail.length < 1) {
          this.openFormAlertValidate(this.$Const.MESSAGE_NOEXIST_ITEM);
          this.arrayDetail.push(this.itemDefault);
          return;
        }
        this.currentObject.detail = JSON.stringify(this.arrayDetail);
        axios
          .put(
            `${this.$Const.API_HOST}/api/v1/OrderBills/${this.selectedObjectId}`,
            this.currentObject
          )
          .then((response) => {
            this.trashData = response;
            this.hide();
            this.$emit("loadData");
          })
          .catch((error) => {
            this.trashData = error;
          });
      } else if (this.formMode === this.$Const.WATCH) {
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
     * truyền dữ liệu sang form watch
     * created vmquang 14/6/2021
     */
    biddingDataWatch(respone) {
      this.currentObject = respone.data.data;
      this.currentObject.orderDate = this.fnFormatDateInput(
        this.currentObject.orderDate
      );
      if (this.currentObject.detail) {
        this.arrayDetail = JSON.parse(this.currentObject.detail);
      }
    },

    /**
     * Hàm copy thông tin đối tượng, phục phục vụ chức năng nhân bản
     * created vmquang 14/6/2021
     */
    copyObject(respone) {
      this.currentObject.supplierCode = respone.data.data.supplierCode;
      this.currentObject.supplierName = respone.data.data.supplierName;
      this.currentObject.customerCode = respone.data.data.customerCode;
      this.currentObject.customerName = respone.data.data.customerName;
      this.currentObject.detail = respone.data.data.detail;
      this.arrayDetail = JSON.parse(this.currentObject.detail);
      this.currentObject.description = respone.data.data.description;
      this.currentObject.orderDate = respone.data.data.orderDate;
      this.currentObject.status = respone.data.data.status;
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
      if (
        this.formMode == this.$Const.UPDATE ||
        this.formMode == this.$Const.WATCH
      ) {
        if (this.formMode == this.$Const.WATCH) {
          this.isReadOnlyInput = true;
        }
        axios
          .get(
            `${this.$Const.API_HOST}/api/v1/OrderBills/` + this.selectedObjectId
          )
          .then((respone) => {
            this.biddingDataWatch(respone);
          })
          .catch((error) => (this.trashData = error));
      } else if (this.formMode == this.$Const.INSERT) {
        await axios
          .get(`${this.$Const.API_HOST}/api/v1/OrderBills/GetNewRefCode`)
          .then((respone) => {
            this.currentObject.refCode = respone.data.data;
          })
          .catch((error) => (this.trashData = error));

        if (this.selectedObjectId) {
          axios
            .get(
              `${this.$Const.API_HOST}/api/v1/OrderBills/` +
                this.selectedObjectId
            )
            .then((respone) => {
              this.copyObject(respone);
            })
            .catch((error) => (this.trashData = error));
        } else {
          this.resetArrayDetail();
        }
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
  top: 355px;
  width: 96%;
  height: 30px;
  padding: 10px 0px 0px 16px;
  display: flex;
  justify-content: space-between;
  align-items: center;
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

input[type="tel"]:focus {
  border: 1px solid #636dde !important;
}
.btn-action-table {
    width: 69px !important;
    height: 32px !important;
    padding-left: 4px;
    padding-right: 4px !important;
    position: relative !important;
    top: -12px !important;
    cursor: pointer;
}
.btn-action-table:hover{
  color: #ffff;
  background-color:  #2b3173;
}
</style>
