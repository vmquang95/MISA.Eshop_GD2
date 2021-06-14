using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Class lưu trử thông tin Phiếu đặt hàng
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021)
    public class OrderBill : BaseEntity
    {
        /// <summary>
        /// Khóa chính, mã phiếu đặt hàng.0
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Key]
        public Guid OrderBillId { get; set; }

        /// <summary>
        /// Số phiếu, unique.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Unique]
        [Required]
        [Display(Name = "Số Phiếu")]
        public string RefCode { get; set; }

        /// <summary>
        /// Ngày đặt hàng
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Trạng thái đơn hàng.
        /// CreatedBy: vmquang(14/5/2021)
        /// </summary>
        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }

        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Required]
        [Display(Name = "Mã nhà cung cấp")]
        public string SupplierCode { get; set; }

        /// <summary>
        /// Tên nhà cung cấp.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Required]
        [Display(Name = "Tên cung cấp")]
        public string SupplierName { get; set; }

        /// <summary>
        /// Mã người đặt.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Required]
        [Display(Name = "Mã người đặt")]
        public string CustomerCode { get; set; }


        /// <summary>
        /// Tên người đặt.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Required]
        [Display(Name = "Tên người đặt")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Diễn dải đơn hàng.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Display(Name = "Diễn dải")]
        public string Description { get; set; }

        /// <summary>
        /// chi tiết đơn hàng.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        [Display(Name = "Chi tiết đơn hàng")]
        public string Detail { get; set; }

    }
}
