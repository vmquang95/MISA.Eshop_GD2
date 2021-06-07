using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.EShop.WebAPI
{
    /// <summary>
    /// Class mô tả các trường thông tin khi Filter dữ liệu từ Client.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class FilterStoreParams
    {
        #region Properties
        /// <summary>
        /// Mã cửa hàng cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string storeCode { get; set; }

        /// <summary>
        /// Tên cửa hàng cần filter
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string storeName { get; set; }

        /// <summary>
        /// Địa chỉ cửa hàng cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string address { get; set; }

        /// <summary>
        /// Số điện thoại cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string phoneNumber { get; set; }

        /// <summary>
        /// Tình trạng(0-đã ngừng hoạt động , 1- đang hoạt động , khác - tất cả).
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public int? status { get; set; }

        #endregion
    }
}
