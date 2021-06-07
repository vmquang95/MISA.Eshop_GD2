using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Class lưu trữ thông tin quốc gia, kế thừa các thuộc tính từ BaseEntity.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class Country: BaseEntity
    {
        #region Properties
        /// <summary>
        /// ID quốc gia , khóa chính.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Key]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Tên quốc gia.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string CountryName { get; set; }
        #endregion
    }
}
