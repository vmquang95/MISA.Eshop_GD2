using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Class lưu trữ thông tin  tỉnh/ thành phố.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class Province:BaseEntity
    {
        #region Properties
        /// <summary>
        /// khóa chính.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Key]
        public Guid ProvinceId { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string ProvinceName { get; set; }

        /// <summary>
        /// Khóa ngoại - FK.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid CountryId { get; set; }

        #endregion
    }
}
