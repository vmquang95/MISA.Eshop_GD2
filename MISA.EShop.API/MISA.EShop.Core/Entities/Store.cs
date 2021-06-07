using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Lớp lưu trữ thông tin của các cửa hàng
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class Store:BaseEntity
    {
        #region Properties
        /// <summary>
        /// ID cửa hàng-khóa chính.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Key]
        public Guid StoreId { get; set; }

        /// <summary>
        /// Mã cửa hàng , duy nhất , không được null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Unique]
        [Required]
        [Display(Name ="Mã cửa hàng")]
        public string StoreCode { get; set; }

        /// <summary>
        /// Tên cửa hàng , không được null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Required]
        [Display(Name = "Tên cửa hàng")]
        public string StoreName { get; set; }

        /// <summary>
        /// Địa chỉ của cửa hàng , không được null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Display(Name ="Mã số thuế")]
        public string StoreTaxCode { get; set; }

        /// <summary>
        /// ID quốc gia,khóa ngoại reference table Country.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid? CountryId { get; set; }

        /// <summary>
        /// ID tỉnh/thành phố - khóa ngoại reference Province
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid? ProvinceId { get; set; }

        /// <summary>
        /// ID quận/huyện - khóa ngoại reference District
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid? DistrictId { get; set; }

        /// <summary>
        /// ID phường/xã -khóa ngoại reference Ward
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid? WardId { get; set; }

        /// <summary>
        /// Đường phố
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Display(Name ="Đường phố")]
        public string Street { get; set; }

        /// <summary>
        /// Trạng thái hoạt động (0 - Đang hoạt động, 1 - Đang đóng cửa)
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Display(Name ="Trạng thái")]
        public int? Status { get; set; }

        #endregion
    }
}
