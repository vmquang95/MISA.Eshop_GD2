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
    /// Interface bao gồm các phương thức  của Store.
    /// Thao tác dữ liêu với database.
    /// Kế thừa từ lớp cở sở IBaseRepository.
    /// Có thêm method riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IStoreRepository : IBaseRepository<Store>
    {
        #region Methods
        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng.
        /// Method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <returns>1 cửa hàng có mã tương ứng.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        Store GetStoreByStoreCode(string storeCode);

        /// <summary>
        /// Lọc cửa hàng theo các theo chí tương ứng với các param.
        /// Method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <param name="storeName">Tên cửa hàng</param>
        /// <param name="address">Địa chỉ</param>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <param name="status">Trạng thái cửa hàng</param>
        /// <returns>Danh sách cửa hàng lọc theo các tiêu chí</returns>
        /// CreatedBy: vmquang(14/5/2021).
        IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);

        /// <summary>
        /// Kiểm tra có có bản ghi nào có Id , code truyền vào.
        /// method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="storeId">ID cửa hàng truyền vào khi sửa</param>
        /// <param name="storeCode">Mã cửa hàng </param>
        /// <param name="functionName"> tên phương thức(Insert - thêm bản ghi, Update - Sửa bản ghi)</param>
        /// <returns>true - Bị trùng, false -Không bị trùng</returns>
        bool CheckStoreCode(Guid? storeId, string storeCode, string functionName);
        #endregion
    }
}
