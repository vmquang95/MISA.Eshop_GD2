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
        /// Số phiếu cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string refCode { get; set; }




        /// <summary>
        /// Tên nhà cung cấp cần filter.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string supplierName { get; set; }

        /// <summary>
        /// Tên người đặt.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string customerName { get; set; }

        /// <summary>
        /// Tình trạng đơn hàng.
        /// (0-Chưa thực hiện , 1- đang thực hiện  , 2 - Đã thực hiện , khác-tất cả).
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public int? status { get; set; }

        /// <summary>
        /// DIễn dải.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string description { get; set; }
        #endregion
    }
}
