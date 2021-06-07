using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Services
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        IUnitOfWork _unitOfWork;
        public StoreService(IUnitOfWork unitOfWork, IBaseRepository<Store> baseRepository) : base(baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        


        public ResponseResult GetStoreByStoreCode(string storeCode)
        {
            var result = new ResponseResult();
            var store = _unitOfWork.StoreTask.GetStoreByStoreCode(storeCode);
            if (store != null)
            {
                result.Data = store;
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.UserMsg = Resources.Messages.ErrorDuplicate;
                result.DevMsg = Resources.Messages.ErrorDuplicate;
            }
            else
            {
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;

            }
            return result;
        }

        public ResponseResult GetStoreFilter(string storeCode, 
                string storeName, 
                string address, 
                string phoneNumber, 
                int? status)
        {
            var result = new ResponseResult();

            var stores = _unitOfWork.StoreTask.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);

            if (stores != null)
            {
                result.Data = stores;
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;
                result.UserMsg = Resources.Messages.GetDataSuccess;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                result.UserMsg = Resources.Messages.ErrorFilterData;
                result.DevMsg = Resources.Messages.ErrorFilterData;
            }
            return result;
        }



        /// <summary>
        /// Hàm validate dữ liệu 
        /// </summary>
        /// <param name="responseResult">Kết quả trả về xem có </param>
        /// <param name="entity"></param>
        public override void Validate(ResponseResult responseResult, Store entity, Guid? entityID, string functionName)
        {
            var propertyUnique = "Mã cửa hàng";
            var propertyRequired = new Dictionary<string, string>();
            propertyRequired.Add("Mã cửa hàng", entity.StoreCode);
            propertyRequired.Add("Tên cửa hàng", entity.StoreName);
            propertyRequired.Add("Địa chỉ", entity.Address);

            foreach (var property in propertyRequired)
            {
                if (string.IsNullOrEmpty(property.Value))
                {
                    responseResult.IsSuccess = false;
                    responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                    responseResult.DevMsg = property.Key + " " + Resources.Messages.ErrorRequiredData;
                    responseResult.UserMsg = property.Key + " " + Resources.Messages.ErrorRequiredData;
                }
            }

            // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate

            bool checkDuplicateCode = _unitOfWork.StoreTask.CheckStoreCode(entityID, entity.StoreCode, functionName);

            if (checkDuplicateCode)
            {
                responseResult.IsSuccess = false;
                responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                responseResult.DevMsg = propertyUnique + " " + Resources.Messages.ErrorDuplicate;
                responseResult.UserMsg = propertyUnique + " " + Resources.Messages.ErrorDuplicate;
            }

        }
    }

}
