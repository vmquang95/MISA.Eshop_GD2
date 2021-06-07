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
    /// Interface bao gồm các hàm xử lý nghiệp vụ của Ward.
    /// Kế thừa từ lớp cở sở IBaseService.
    /// Có thêm nghiệp vụ riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IWardService : IBaseService<Ward>
    {
        /// <summary>
        /// Lấy danh sách các phường/xã theo id quận/huyện
        /// </summary>
        /// <param name="DistrictId">ID quận/huyện</param>
        /// <returns>1 đối tượng ResponResult: data,DevMsg,UserMsg,ErorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021)
        ResponseResult GetWardWithDistrict(Guid? districtId);
    }
}
