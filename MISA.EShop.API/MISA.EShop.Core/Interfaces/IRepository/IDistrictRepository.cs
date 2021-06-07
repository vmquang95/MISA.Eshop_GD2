using MISA.EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Interface bao gồm các chức năng của Country.
    /// Thao tác dữ liêu với database.
    /// Kế thừa từ lớp cở sở IBaseRepository.
    /// Có thêm method riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IDistrictRepository:IBaseRepository<District>
    {
        #region Methods
        /// <summary>
        /// Lấy danh sách tất cả  quận/huyện theo Id tỉnh/thành phố.
        /// </summary>
        /// <param name="ProvinceId">ID của tỉnh/thành phố</param>
        /// <returns>Danh sách quận/huyện có id tỉnh thành phố tương ứng.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        IEnumerable<District> GetDistrictWithProvince(Guid? provinceId);
        #endregion
    }
}
