using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Class mô tả các trường thông tin khi Filter dữ liệu từ Client.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class FilterOrderBillParams
    {
        #region Properties
        /// <summary>
        /// Mã cửa hàng cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string refCode { get; set; }

    

        /// <summary>
        /// Địa chỉ cửa hàng cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string supplierName { get; set; }

        /// <summary>
        /// Số điện thoại cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string customerName { get; set; }

        /// <summary>
        /// Tình trạng(0-đã ngừng hoạt động , 1- đang hoạt động , khác - tất cả).
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public int? status { get; set; }

        /// <summary>
        /// Số điện thoại cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string description { get; set; }
        #endregion
    }
}
