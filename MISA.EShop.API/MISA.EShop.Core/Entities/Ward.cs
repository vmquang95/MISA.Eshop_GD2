using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Entities
{
    #region Properties
    /// <summary>
    /// Class lưu trữ thông tin các phường/xã.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class Ward:BaseEntity
    {
        /// <summary>
        /// ID phường xã - khóa chính.
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        [Key]
        public Guid WardId { get; set; }

        /// <summary>
        /// Tên phường/ xã
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public string WardName { get; set; }

        /// <summary>
        /// ID quận/huyện - khóa ngoại reference  Province)
        /// </summary>
        /// CreatedBy: vmquang(14/5/2021).
        public Guid DistrictId { get; set; }
        #endregion
    }
}
