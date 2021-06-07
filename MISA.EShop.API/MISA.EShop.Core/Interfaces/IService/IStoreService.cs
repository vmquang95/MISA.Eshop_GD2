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
    /// Interface bao gồm các hàm xử lý nghiệp vụ của Store.
    /// Kế thừa từ lớp cở sở IBaseService.
    /// Có thêm nghiệp vụ riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IStoreService : IBaseService<Store>
    {

        #region Methods
        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng.
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <returns>1 đối tượng ResponResult: data,DevMsg,UserMsg,ErorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021)
        ResponseResult GetStoreByStoreCode(string storeCode);

        /// <summary>
        /// Lọc thông tin theo các tiêu chí
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <param name="storeName">Tên cửa hàng</param>
        /// <param name="address">Địa chỉ</param>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <param name="status">Trạng thái hoạt động</param>
        /// <returns>1 đối tượng ResponResult: data,DevMsg,UserMsg,ErorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021)
        ResponseResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);
        #endregion

    }
}
