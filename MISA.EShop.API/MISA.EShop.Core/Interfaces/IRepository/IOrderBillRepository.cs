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
        IEnumerable<OrderBill> GetOrderBillFilter(string refCode, string supplierName, string customerName, int? status, string description);
    }
}
