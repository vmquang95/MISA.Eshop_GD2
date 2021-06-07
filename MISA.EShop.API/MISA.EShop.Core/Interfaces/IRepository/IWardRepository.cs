using MISA.EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Interface bao gồm các chức năng. của Ward.
    /// Thao tác dữ liêu với database.
    /// Kế thừa từ lớp cở sở IBaseRepository.
    /// Có thêm method riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IWardRepository:IBaseRepository<Ward>
    {
        #region Methods.
        /// <summary>
        /// Lấy danh sách các phường/xã theo Id quận/huyện
        /// </summary>
        /// <param name="DistrictId">ID quận huyện</param>
        /// <returns>Danh sách các xã/phường có Id quận/huyện tương ứng.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        IEnumerable<Ward> GetWardWithDistrict(Guid? districtId);
        #endregion
    }
}
