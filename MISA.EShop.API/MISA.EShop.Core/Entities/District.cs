using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Class lưu trữ thông tin quận/huyện.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class District:BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khóa chính.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Key]
        public Guid DistrictId { get; set; }

        /// <summary>
        /// Tên quận/ huyện.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string DistrictName { get; set; }

        /// <summary>
        /// ID tỉnh/thành phố, Khóa ngoại, không được null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid ProvinceId { get; set; }
        #endregion
    }
}
