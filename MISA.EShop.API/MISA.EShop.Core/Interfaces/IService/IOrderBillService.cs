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
        ResponseResult GetOrderBillFilter(string refCode, string supplierName, string customerName, int? status, string description);
        
    }
}
