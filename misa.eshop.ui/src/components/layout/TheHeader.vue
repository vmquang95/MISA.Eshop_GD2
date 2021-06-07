<template>
  <!-- start header -->
    <div class="header">
      <div class="header-right catalog-name">Đặt hàng</div>
      <div class="header-left">
        <div class="header-mid">
          <div class="header-mid-selection style-select store-catalog">
            <select name="list-store" id="list-store" class="select-head">
              <option value="1" selected>DODAVI-160 Hoàng Hoa Thám</option>
              <option value="2">30Shine Cầu giấy</option>
              <option value="3">KFC Hà Đông</option>
              <option value="4">Jollibee Tây Hồ</option>

            </select>
          </div>
          <div class="header-mid-selection user-setting">
            <button id="user-control" class="t-btn select-head">
              <span class="icon-user"></span>
              <span class="user-name">Vũ Minh Quang</span>
              <span class="icon-drop">
                <i class="fas fa-angle-down"></i>
              </span>
            </button>
            <!-- Div này sẽ chỉnh sửa sau khi hoàn thành các chức năng khác -->
            <div class="div-user-setting" id="div-user-setting">
              <ul class="user-setting-list">
                <li class="user-setting-item">
                  <a href="#" class="account"> Tài khoản </a>
                </li>
                <li class="user-setting-item">
                  <a href="#" class="change-password"> Thay đổi mật khẩu </a>
                </li>
                <li class="user-setting-item">
                  <a href="#" class="logout"> Đăng xuất </a>
                </li>
              </ul>
            </div>
            <!-- Div user setting -->
          </div>
        </div>
        <div class="header-left-btn">
          <div
            class="header-div-btn support"
            title="Tổng đài MISA - liên hệ để được hỗ trợ"
          >
            <button class="t-btn header-btn btn-support"></button>
          </div>
          <div class="header-div-btn notify" title="Thông báo">
            <button class="t-btn header-btn btn-notify">
              <i class="fas fa-bell">
                <span class="item-head-notify"></span>
              </i>
            </button>
          </div>
          <div class="header-div-btn" title="Trợ giúp">
            <button class="t-btn header-btn btn-help"></button>
          </div>
        </div>
      </div>
    </div>
    <!-- end header -->
</template>

<script>
export default {
  data(){
    return{

    }
  },
  methods:{
  
  }

}
</script>

<style scoped>
@import "../../styles/layout/header.css";
</style>

