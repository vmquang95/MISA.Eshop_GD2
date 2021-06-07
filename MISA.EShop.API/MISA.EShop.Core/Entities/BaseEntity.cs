using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// Class mô tả thông tin chung của các thực thê.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021)
    public class BaseEntity
    {
        #region Properties
        /// <summary>
        /// Ngày tạo, có thể null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo, có thể null.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa, có thể null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa đối tượng , có thể null.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021)
        public string ModifiedBy { get; set; }
        #endregion
    }
}
