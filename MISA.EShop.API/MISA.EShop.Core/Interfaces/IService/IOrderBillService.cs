using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces.IService
{
    /// <summary>
    /// Interface bao gồm các hàm xử lý nghiệp vụ của Store.
    /// Kế thừa từ lớp cở sở IBaseService.
    /// Có thêm nghiệp vụ riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IOrderBillService : IBaseService<OrderBill>
    {
        /// <summary>
        /// FIlter dữ liệu theo tiêu chí từ phía client.
        /// </summary>
        /// <param name="refCode">Số phiếu đặt hàng</param>
        /// <param name="supplierName">Tên nhà cung cấp</param>
        /// <param name="customerName">Tên người đặt</param>
        /// <param name="status">Tình trạng đơn hàng</param>
        /// <param name="description">diễn dải đơn hàng</param>
        /// <returns>Respone theo chuẩn Resfull</returns>
        /// CreatedBy: vmquang(14/5/2021)
        ResponseResult GetOrderBillFilter(string refCode, string supplierName, string customerName, int? status, string description);

        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng.
        /// Method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="refCode">Mã cửa hàng</param>
        /// <returns>1 cửa hàng có mã tương ứng.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        ResponseResult GetOrderBillByRefCode(string refCode);

        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng.
        /// Method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="refCode">Mã cửa hàng</param>
        /// <returns>Respone chuẩn restFull</returns>
        /// CreatedBy: vmquang(14/5/2021).
        ResponseResult GetNewRefCode();

        /// <summary>
        /// Check trùng Số phiếu đối với thao tác update dữ liệu
        /// </summary>
        /// <param name="refCode">Số phiếu sửa đổi</param>
        /// <param name="id">mã địa diện cho thực thể hiện tại đang sửa</param>
        /// <returns>Respone chuẩn restfull</returns>
        /// CreatedBy: vmquang(14/5/2021)
        ResponseResult CheckDuplicateUpDateOrderBill(string refCode, Guid id);
    }
}
