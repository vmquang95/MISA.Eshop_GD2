using MISA.EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces.IRepository
{
    /// <summary>
    /// Interface bao gồm các phương thức  của OorderBill.
    /// Thao tác dữ liêu với database.
    /// Kế thừa từ lớp cở sở IBaseRepository.
    /// Có thêm method riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IOrderBillRepository : IBaseRepository<OrderBill>
    {
        /// <summary>
        /// FIlter dữ liệu theo tiêu chí từ phía client.
        /// </summary>
        /// <param name="refCode">Số phiếu đặt hàng</param>
        /// <param name="supplierName">Tên nhà cung cấp</param>
        /// <param name="customerName">Tên người đặt</param>
        /// <param name="status">Tình trạng đơn hàng</param>
        /// <param name="description">diễn dải đơn hàng</param>
        /// <returns>List phiếu đặt hàng thỏa mãn.</returns>
        /// CreatedBy: vmquang(14/5/2021)
        IEnumerable<OrderBill> GetOrderBillFilter(string refCode,string supplierName, string customerName, int? status, string description);

        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng.
        /// Method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="refCode">Mã cửa hàng</param>
        /// <returns>1 cửa hàng có mã tương ứng.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        OrderBill GetOrderBillByRefCode(string refCode);

        /// <summary>
        /// Sinh Số phiếu ngẫu nhiên không trùng lặp.
        /// </summary>
        /// <returns>Số phiếu dạng PDH0111111</returns>
        /// CreatedBy: vmquang(14/5/2021)
        string GetNewRefCode();

        /// <summary>
        /// Check trùng Số phiếu đối với thao tác update dữ liệu
        /// </summary>
        /// <param name="refCode">Số phiếu sửa đổi</param>
        /// <param name="id">mã địa diện cho thực thể hiện tại đang sửa</param>
        /// <returns>1 đối tương
        /// Có Orderbill tức là trùng.
        /// Orderbil = nul là không trùng
        /// </returns>
        /// CreatedBy: vmquang(14/5/2021)
        OrderBill CheckDuplicateUpDateOrderBill(string refCode, Guid id);

    }
}
