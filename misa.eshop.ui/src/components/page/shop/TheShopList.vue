<template>
  <div class="shop-list">
    <!-- start content -->
    <div class="content">
      <div class="content-body" id="click-outside">
        <!-- start tool bar -->
        <div class="tool-bar">
          <div class="tool-bar-btn div-btn-add">
            <button
              class="t-btn btn-add click-outside isActive"
              id="btn-add"
              @click="openDialog('insert', '')"
            >
              <i class="t-icon t-icon-add"></i>
              <span>Thêm mới</span>
            </button>
          </div>
          <div class="tool-bar-btn div-btn-replication ">
            <button
              :class="selectedObjectId ? 'isActive' : 'isNotActive'"
              :disabled="!selectedObjectId"
              @click="openDialog('insert', selectedObjectId)"
              class="t-btn btn-replication t-btn-disable"
              id="btn-replication"
            >
              <i class="t-icon t-icon-replication"></i>
              <span>Nhân bản</span>
            </button>
          </div>
          <div class="tool-bar-btn div-btn-edit">
            <button
              :class="selectedObjectId ? 'isActive' : 'isNotActive'"
              :disabled="!selectedObjectId"
              @click="openDialog('watch', selectedObjectId)"
              class="t-btn btn-edit t-btn-disable"
              id="btn-edit"
            >
              <i class="t-icon t-icon-watch"></i>
              <span>Xem</span>
            </button>
          </div>
          <div class="tool-bar-btn div-btn-edit">
            <button
              :class="selectedObjectId ? 'isActive' : 'isNotActive'"
              :disabled="!selectedObjectId"
              @click="openDialog('update', selectedObjectId)"
              class="t-btn btn-edit t-btn-disable"
              id="btn-edit"
            >
              <i class="t-icon t-icon-edit"></i>
              <span>Sửa</span>
            </button>
          </div>
          <div class="tool-bar-btn div-btn-delete">
            <button
              :class="selectedObjectId ? 'isActive' : 'isNotActive'"
              :disabled="!selectedObjectId"
              @click="deleteObject()"
              class="t-btn btn-delete t-btn-disable"
              id="btn-delete"
            >
              <i class="t-icon t-icon-delete"></i>
              <span>Xóa</span>
            </button>
          </div>
          <div class="tool-bar-btn div-btn-load">
            <button
              @click="reLoadData()"
              class="t-btn btn-load isActive"
              id="btn-load"
            >
              <i class="t-icon t-icon-load"></i>
              <span>Nạp</span>
            </button>
          </div>
        </div>
        <!-- end tool bar -->
        <div class="toobar-filter-date">
          <select disabled class="select-datetime">
            <option selected>Tháng này</option>
            <option>6 tháng trước</option>
          </select>
          <div class="datepic-side" style="margin-left: 203px;">
            <span>Từ ngày</span>
            <input disabled class="inputdate" type="date" />
          </div>
          <div class="datepic-side">
            <span>Đến ngày</span>
            <input disabled class="inputdate" type="date" />
          </div>
          <button class="btn-quang">
            <div class="icon-quang"></div>
            <span>Lấy dữ liệu</span>
          </button>
        </div>
        <!-- start grid -->
        <div class="t-grid">
          <table
            id="tbl-list-store"
            cellspacing="0"
            cellpadding="0"
            width="100%"
          >
            <thead>
              <tr>
                <th class="col-15 col-checkbox">
                  <div>
                    <input disabled type="checkbox" />
                  </div>
                </th>
                <th class="col-15 col-inputdate">
                  <div class="thead-text">Ngày đặt hàng</div>
                  <div class="thead-filter order-date-input">
                    <button class="t-btn condition">=</button>
                    <input
                      disabled
                      class="t-input filter-text inputdate"
                      type="date"
                      style="height: 31px;"
                    />
                  </div>
                </th>
                <th
                  class="col-15"
                  fieldName="shopCode"
                  style="min-width:149px !importain"
                >
                  <div class="thead-text">Số phiếu</div>
                  <div class="thead-filter order-bill-id-input">
                    <button class="t-btn condition">*</button>
                    <input
                      tabindex="1"
                      v-model="filterDataTable.refCode"
                      type="text"
                      class="t-input filter-text"
                    />
                  </div>
                </th>
                <th class="col-21" fieldName="shopName">
                  <div class="thead-text">Người đặt</div>
                  <div class="thead-filter">
                    <button class="t-btn condition">*</button>
                    <input
                      tabindex="2"
                      v-model="filterDataTable.customerName"
                      type="text"
                      class="t-input filter-text"
                    />
                  </div>
                </th>
                <th class="col-42" fieldName="address">
                  <div class="thead-text">Nhà cung cấp</div>
                  <div class="thead-filter">
                    <button class="t-btn condition">*</button>
                    <input
                      tabindex="3"
                      v-model="filterDataTable.supplierName"
                      type="text"
                      class="t-input filter-text"
                    />
                  </div>
                </th>

                <th class="col-10" fieldName="phoneNumber">
                  <div class="thead-text">Tổng tiền</div>
                  <div class="thead-filter">
                    <button class="t-btn condition">*</button>
                    <input disabled type="text" class="t-input filter-text" />
                  </div>
                </th>
                <th class="col-12" fieldName="status">
                  <div class="thead-text">Trạng thái</div>
                  <div class="thead-filter">
                    <select
                      tabindex="4"
                      type="text"
                      class="filter-select"
                      id="filter-status"
                      v-model="filterDataTable.status"
                    >
                      <option
                        v-for="option in arrayOrderBillStatus"
                        :key="option.value"
                        :value="option.value"
                      >
                        {{ option.statusName }}
                      </option>
                    </select>
                  </div>
                </th>
                <th class="col-42" fieldName="address">
                  <div class="thead-text">Diễn dải</div>
                  <div class="thead-filter">
                    <button class="t-btn condition">*</button>
                    <input
                      tabindex="5"
                      v-model="filterDataTable.description"
                      type="text"
                      class="t-input filter-text"
                    />
                  </div>
                </th>
              </tr>
            </thead>
            <div v-show="!isLoaded" class="loading-data">
              <div class="loader"></div>
              <div class="text">Đang nạp dữ liệu</div>
            </div>
            <tbody class="tbl-scroll">
              <tr
                v-for="obj in this.orderBillList"
                :key="obj.orderBillId"
                class="row-data"
                @dblclick="openDialog('watch', obj.orderBillId)"
                @click="clickRow(obj.orderBillId)"
                v-bind:class="isSelected(obj.orderBillId) ? 'selected-row' : ''"
              >
                <td class="col-15">
                  <input
                    type="checkbox"
                    :checked="isSelected(obj.orderBillId)"
                  />
                </td>
                <td class="col-15 text-date">
                  {{ obj.orderDate | fnFormatDate }}
                </td>
                <td class="col-15 txt-orderbill-id">
                  <span @click="openDialog('watch', obj.orderBillId)">{{
                    obj.refCode
                  }}</span>
                </td>
                <td class="col-21">{{ obj.customerName }}</td>
                <td class="col-42">{{ obj.supplierName }}</td>
                <td class="col-10 txt-total">
                  {{ getMoneyOrderBill(obj) | formatMoney }}
                </td>
                <td
                  class="col-12"
                  :class="obj.status == 0 ? 'txt-status-text' : ''"
                >
                  {{ getStatusStoreName(obj.status) }}
                </td>
                <td class="col-42">{{ obj.description }}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <TheFooterStore :records="orderBillList.length" />
        <div class="totalfooter">
          <div class="totalfooter-left">
            <span>Tổng số lượng</span>
            <span>{{ orderBillList.length }}</span>
          </div>
          <div class="totalfooter-right">
            <span> Tổng thành tiền</span>
            <span>{{ getTotalMoney() | formatMoney }}</span>
          </div>
        </div>
      </div>
    </div>
    <!-- end content -->

    <ModalCreateShop
      v-if="showDialog"
      ref="ModalCreate"
      :selectedObjectId="selectedObjectId"
      :formMode="formMode"
      @loadData="loadData"
      @showDialogFn="showDialogFn"
    />
    <ModalDeletShop
      ref="ModalDelete"
      :selectedObjectId="selectedObjectId"
      @loadData="loadData"
    />
  </div>
</template>

<script>
import moment from "moment";
import axios from "axios";
import TheFooterStore from "./TheFooterStore";
import ModalCreateShop from "../../modal/FunctionModal/ModalCreateShop";
import ModalDeletShop from "../../modal/FunctionModal/ModelDeleteShop";
export default {
  name: "Content",
  components: {
    ModalCreateShop,
    TheFooterStore,
    ModalDeletShop,
  },
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
  watch: {
    "filterDataTable.refCode"() {
      this.setTimeOutInputFilter();
    },
    "filterDataTable.supplierName"() {
      this.setTimeOutInputFilter();
    },
    "filterDataTable.customerName"() {
      this.setTimeOutInputFilter();
    },
    "filterDataTable.description"() {
      this.setTimeOutInputFilter();
    },
    "filterDataTable.status"() {
      this.getOrderBillByFilter(this.filterDataTable);
    },
  },
  data() {
    return {
      trashDataa: "",
      isLoaded: false,
      showDialog: false,
      formMode: "",
      selectedObjectId: "",
      orderBillList: [],
      countOrderBill: 0,
      totalMoneyAllOrderBill: 0,
      arrayOrderBillStatus: [
        {
          statusName: "Tất cả",
          value: "",
        },
        {
          statusName: "Chưa thực hiện",
          value: 0,
        },
        {
          statusName: "Đang thực hiện",
          value: 1,
        },
        {
          statusName: "Đẫ thực hiện",
          value: 2,
        },
      ],
      filterDataTable: {
        refCode: "",
        supplierName: "",
        customerName: "",
        status: "",
        description: "",
        resetFilterTable() {
          this.refCode = "";
          this.supplierName = "";
          this.customerName = "";
          this.status = "";
          this.description = "";
        },
      },
    };
  },

  created() {
    this.getOrderBillByFilter(this.filterDataTable);
  },

  methods: {
    /**
     * hàm settimeout filter.
     * created vmquang 14/6/2021
     */
    setTimeOutInputFilter() {
      clearTimeout(this.timeout);
      this.timeout = setTimeout(() => {
        this.getOrderBillByFilter(this.filterDataTable);
      }, 500);
    },
    /**
     *Hàm load lại dữ liệu.
     * created vmquang 14/6/2021
     */
    reLoadData() {
      this.orderBillList = [];
      this.selectedObjectId = "";
      this.isLoaded = false;
      this.filterDataTable.resetFilterTable();
      this.getOrderBillByFilter(this.filterDataTable);
    },
    /**
     * Hàm lấy dữ liệu từ filter
     * created vmquang 14/6/2021
     */
    getOrderBillByFilter(filter) {
      var endpoint = `${this.$Const.API_HOST}/api/v1/OrderBills/Filter?refCode=${filter.refCode}&supplierName=${filter.supplierName}&customerName=${filter.customerName}&status=${filter.status}&description=${filter.description}`;
      axios
        .get(endpoint)
        .then((respone) => {
          this.orderBillList = respone.data.data;
        })
        .then(() => {
          this.isLoaded = true;
        })
        .catch((error) => (this.trashDataa = error));
    },

   /**
     * Hàm lấy tổng tiền tất cả phiếu hàng.
     * created vmquang 14/6/2021
     */
    getTotalMoney() {
      let sum = 0;
      this.orderBillList.forEach((obj) => {
        sum += this.getMoneyOrderBill(obj);
      });
      return sum;
    },

     /**
     * Hàm mở dialog
     * created vmquang 14/6/2021
     */
    showDialogFn() {
      this.showDialog = false;
    },

    /**
     * Hàm load lại data
     * created vmquang 14/6/2021
     */
    loadData() {
      this.orderBillList = [];
      this.selectedObjectId = "";
      this.isLoaded = false;
      this.filterDataTable.resetFilterTable();
      this.getOrderBillByFilter(this.filterDataTable);
    },
    /**
     * Hàm Xóa 1 đối tượng
     * created vmquang 14/6/2021
     */
    deleteObject() {
      if (!this.selectedObjectId) {
        return;
      } else {
        this.$refs.ModalDelete.show();
      }
    },
    /**
     * sự kiện click vào 1 row của table OrderList.
     * Gán selectedObject = id của row được chọn.
     */
    clickRow(id) {
      this.selectedObjectId = id;
    },
    /**
     * Hàm kiểm tra hàng hiện tại có được chọn hay không
     * created vmquang 14/6/2021
     */
    isSelected(id) {
      if (this.selectedObjectId == id) return true;
      return false;
    },

    /**
     * hàm lấy tổng tiển từng hàng.
     * created vmquang 14/6/2021
     */
    getMoneyOrderBill(obj) {
      var moneyOrderBill = 0;
      try {
        let arrayDetail = JSON.parse(obj.detail);
        arrayDetail.forEach((element) => {
          moneyOrderBill += element.prince * element.quality;
        });
      } catch (error) {
        moneyOrderBill = 0;
      }
      return moneyOrderBill;
    },
    /**
     * Hàm mở form Thêm/sửa.xem dữ liệu
     * created vmquang 14/6/2021
     */
    openDialog(mode, id) {
      this.showDialog = true;
      if (mode == "insert") {
        this.selectedObjectId = "";
        this.formMode = "insert";
        if (id) {
          this.selectedObjectId = id;
        }
      } else if (mode == "update") {
        this.formMode = "update";
        this.selectedObjectId = id;
      } else {
        this.formMode = "watch";
        this.selectedObjectId = id;
      }
      setTimeout(() => {
        this.$refs.ModalCreate.show();
      }, 300);
    },
    /**
     * Lấy tên  trạng thái qua id status
     */
    getStatusStoreName(value) {
      var status = String;
      if (value == 0) {
        status = "Chưa thực hiện";
      } else if (value == 1) {
        status = "Đang thực hiện";
      } else if (value == 2) {
        status = "Đã thực hiện";
      } else {
        status = "";
      }
      return status;
    },
  },
};
</script>

<style scoped>
@import "../../../styles/layout/toolbar.css";
@import "../../../styles/layout/toolbarFilterDate.css";
@import "../../../styles/layout/content.css";
@import "../../../styles/base/animationLoading.css";

.totalfooter {
  position: absolute;
  bottom: 3px;
  width: 100%;
  height: 29px;
  display: flex;
  justify-content: center;
  justify-content: space-between;
  align-items: center;
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
.inputdate {
  outline: none;
}
.inputdate:focus {
  border: 1px solid #636dde;
}
.col-checkbox {
  min-width: 39px !important;
}
.col-inputdate {
  min-width: 129px;
}
.selected-row {
  background-color: #a7afe4 !important;
  color: #000;
  cursor: default !important;
}
.isNotActive {
  opacity: 0.4;
}
.isNotActive:hover {
  cursor: context-menu;
}
.totalfooter-left {
  display: flex;
  justify-content: space-between;
  width: 130px;
}
.totalfooter-right {
  display: flex;
  justify-content: space-between;
  width: 260px;
  margin-right: 150px;
}
.loading-data {
  width: calc(100% - 186px);
  height: calc(100vh - 300px);
  position: fixed;
  top: 214px;
  background-color: rgba(0, 0, 0, 0.3);
  color: #ffffff;
  text-align: center;
}
.loading-data .text {
  position: fixed;
  left: calc(50% + 20px);
  top: 50%;
}
</style>
