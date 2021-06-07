<template>
  <div id="footer">
    <!-- start footer -->
    <div class="footer">
      <div class="footer-content">
        <div class="pagination">
          <button
            class="t-btn btn-footer t-icon t-icon-left-shift t-btn-disable"
            id="btn-left-shift"
          ></button>
          <button
            class="t-btn btn-footer t-icon t-icon-previous t-btn-disable"
            id="btn-previous"
          >
            <i class=""></i>
          </button>
          <div class="footer-text">Trang</div>
          <div class="page-index">
            <input type="text" id="p-index" class="p-index" value="1" />
          </div>
          <div class="footer-text">trên <span class="page-total">1</span></div>
          <button
            class="t-btn btn-footer t-icon t-icon-next t-btn-disable"
            id="btn-next"
          >
            <i class=""></i>
          </button>
          <button
            class="t-btn btn-footer t-icon t-icon-right-shift t-btn-disable"
            id="btn-right-shift"
          >
            <i class=""></i>
          </button>
          <button
            class="t-btn btn-footer t-icon t-icon-refresh"
            id="btn-refresh"
          >
            <i class=""></i>
          </button>
          <div class="cb-footer">
            <select name="cb-paging" id="cb-paging" class="cb-paging">
              <option value="15">15</option>
              <option value="25">25</option>
              <option value="50" selected>50</option>
              <option value="100">100</option>
            </select>
          </div>
        </div>
        <div class="footer-text display-paging-text">
          Hiển thị <span class="begin-record"> 1 </span> -
          <span class="last-record"> 13</span> trên
          <span class="total-record"> 13 </span> kết quả
        </div>
      </div>
    </div>
    <!-- end footer -->
  </div>
</template>

<style>
    @import "../../../styles/layout/footer.css";
</style>