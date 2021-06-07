using Dapper;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    /// <summary>
    /// Lớp thực thi tương tác với database của Store.
    /// Có kế thừa từ lớp BaseRepository.
    /// Có thêm phương thức riêng.
    /// </summary>
    /// CreatedBy vmquang 18/5/2021.
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {

       

        public Store GetStoreByStoreCode(string storeCode)
        {
            var storeName = $"Proc_GetStoreByStoreCode";
            var parameters = new DynamicParameters();
            parameters.Add("@StoreCode", storeCode);
            var store = _dbConnection
                .Query<Store>(storeName, parameters, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return store;
        }

        public IEnumerable<Store> GetStoreFilter(
            string storeCode,
            string storeName,
            string address,
            string phoneNumber,
            int? status)
        {
            var procName = $"Proc_GetStoreFilter";
            var parameters = new DynamicParameters();
            parameters.Add("@StoreCode", storeCode);
            parameters.Add("@StoreName", storeName);
            parameters.Add("@Address", address);
            parameters.Add("@PhoneNumber", phoneNumber);
            parameters.Add("@Status", status);

            var stores = _dbConnection
                .Query<Store>(procName, parameters, commandType: CommandType.StoredProcedure).OrderByDescending(s=>s.CreatedDate);

            return stores;
        }

        public IEnumerable<Store> GetStoreByIndexOffset(int positionStart, int offset)
        {
            var procName = $"GetStoreByIndexOffset";
            var parameters = new DynamicParameters();
            parameters.Add("positionStart", positionStart);
            parameters.Add("offset", offset);
            var entities = _dbConnection.Query<Store>(procName, param: parameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

     


        public bool CheckStoreCode(Guid? storeId, string storeCode, string functionName)
        {
            var sqlCheckExistCode = "";
            if (functionName == "Insert")
            {
                // Thực hiện lấy số lượng bản ghi có mã khách hàng trùng với mã khách hàng truyền vào
                sqlCheckExistCode = $"Select StoreCode from Store where Store.StoreCode = @StoreCode";
            }
            else if (functionName == "Update")
            {
                // Thực hiện lấy số lượng bản ghi có mã khách hàng trùng với mã khách hàng truyền vào, loại bỏ bản ghi hiện tại
                sqlCheckExistCode = $"Select StoreCode from Store where Store.StoreCode = @StoreCode and  Store.StoreId != '{storeId}'";
            }

            // truyền vào tham số mã cửa hàng - storeCode
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StoreCode", storeCode);

            // thực hiện truy vấn 
            var storeExistCode = _dbConnection
                .Query<string>(
                    sqlCheckExistCode,
                    dynamicParameters,
                    commandType: CommandType.Text);

            // kiểm tra kết quả:
            if (storeExistCode.AsList().Count > 0)
            {
                return true;
            }

            return false;
        }


    }
}
