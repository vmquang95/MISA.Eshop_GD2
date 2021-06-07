using Dapper;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    /// <summary>
    /// Lớp xử lý lấy Country.
    /// Tương tác trực tiếp với databse.
    /// Kế thừa từ lớp baseRepository.
    /// </summary>
    public class OrderBillRepository : BaseRepository<OrderBill>, IOrderBillRepository
    {
        public IEnumerable<OrderBill> GetOrderBillFilter(string refCode, string supplierName, string customerName, int? status, string description)
        {
            var procName = $"Proc_GetOrderBillFilter";
            var parameters = new DynamicParameters();
            parameters.Add("@RefCode", refCode);
            parameters.Add("@SupplierName", supplierName);
            parameters.Add("@CustomerName", customerName);
            parameters.Add("@Status", status);
            parameters.Add("@Description", description);

            var obs = _dbConnection
                .Query<OrderBill>(procName, parameters, commandType: CommandType.StoredProcedure).OrderByDescending(ob => ob.OrderDate);

            return obs;
        }
    }
}
