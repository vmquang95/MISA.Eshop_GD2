using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Interface bao gồm các hàm xử lý nghiệp vụ của District.
    /// Kế thừa từ lớp cở sở IBaseService.
    /// Có thêm nghiệp vụ riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IDistrictService : IBaseService<District>
    {
        #region Methods
        /// <summary>
        /// Nghiệp vụ Lấy danh sách các quận/huyện theo Id tỉnh/thành phố
        /// </summary>
        /// <param name="ProvinceId">ID của tỉnh/thành phố</param>
        /// <returns>1 đối tượng ResponResult: data,DevMsg,UserMsg,ErorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021)
        ResponseResult GetDistrictWithProvince(Guid? provinceId);
        #endregion
    }
}
