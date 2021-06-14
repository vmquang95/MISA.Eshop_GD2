using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    public class OrderBill : BaseEntity
    {
        [Key]
        public Guid OrderBillId { get; set; }

        [Unique]
        [Required]
        [Display(Name = "Số Phiếu")]
        public string RefCode { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }

        [Required]
        [Display(Name = "Mã nhà cung cấp")]
        public string SupplierCode { get; set; }

        [Required]
        [Display(Name = "Tên cung cấp")]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name = "Mã người đặt")]
        public string CustomerCode { get; set; }

        [Required]
        [Display(Name = "Tên người đặt")]
        public string CustomerName { get; set; }

        [Display(Name = "Diễn dải")]
        public string Description { get; set; }

        [Display(Name = "Chi tiết đơn hàng")]
        public string Detail { get; set; }

    }
}
