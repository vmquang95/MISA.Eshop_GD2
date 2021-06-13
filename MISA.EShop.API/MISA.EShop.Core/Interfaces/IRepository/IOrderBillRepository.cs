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
        IEnumerable<OrderBill> GetOrderBillFilter(string refCode,string supplierName, string customerName, int? status, string description);

        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng.
        /// Method riêng, không kế thừa từ Base.
        /// </summary>
        /// <param name="refCode">Mã cửa hàng</param>
        /// <returns>1 cửa hàng có mã tương ứng.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        OrderBill GetOrderBillByRefCode(string refCode);

        string GetNewRefCode();

        OrderBill CheckDuplicateUpDateOrderBill(string refCode, Guid id);

    }
}
