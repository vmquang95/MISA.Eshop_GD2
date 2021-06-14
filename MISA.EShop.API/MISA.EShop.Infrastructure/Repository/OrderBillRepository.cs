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
    /// Created By: vmquang 15/6/2021
    public class OrderBillRepository : BaseRepository<OrderBill>, IOrderBillRepository
    {
        /// <summary>
        /// Lấy số phiếu ngẫu nhiên từ db
        /// </summary>
        /// <returns>số phiếu</returns>
        /// Created By: vmquang 15/6/2021
        public string GetNewRefCode()
        {
            var storeName = $"Proc_GetNewRefCode";
            // Thực hiện lấy dữ liệu từ Database
            var newCode = _dbConnection.Query<string>(
                storeName,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            return newCode;
        }

        /// <summary>
        /// Lấy phiếu đặt hàng theo số phiếu
        /// </summary>
        /// <param name="refCode">số phiếu</param>
        /// <returns>1 bản ghi</returns>
        /// Created By: vmquang 15/6/2021
        public OrderBill GetOrderBillByRefCode(string refCode)
        {
            var storeName = $"Proc_GetOrderBillByCode";
            var parameters = new DynamicParameters();
            parameters.Add("@RefCode", refCode);
            var ob = _dbConnection
                .Query<OrderBill>(storeName, parameters, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return ob;
        }

        /// <summary>
        /// Filter dữ liệu từ db.
        /// </summary>
        /// <param name="refCode">số phiếu</param>
        /// <param name="supplierName">tên nhà cung cấp</param>
        /// <param name="customerName">tên người đặt</param>
        /// <param name="status">tình trạng đơn hàng</param>
        /// <param name="description">diễn dải</param>
        /// <returns>Danh sách dữ liệu thỏa mãn</returns>
        /// Created By: vmquang 15/6/2021
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

        /// <summary>
        /// Check trùng Số phiếu khi sửa 1 bản ghi.
        /// </summary>
        /// <param name="refCode">Số phiếu cần check</param>
        /// <param name="id">id đại diện đối tượng cần sửa đổi</param>
        /// <returns>đối tượng trùng lặp</returns>
        /// Created By: vmquang 15/6/2021
        public OrderBill CheckDuplicateUpDateOrderBill(string refCode, Guid id)
        {
            var storeName = $"Proc_CheckDuplicateUpDateOrderBill";
            var parameters = new DynamicParameters();
            parameters.Add("@RefCode", refCode);
            parameters.Add("@OrderBillId", id);
            var ob = _dbConnection
                .Query<OrderBill>(storeName, parameters, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return ob;
        }

    }
}
