using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Interfaces.IService;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Services
{
    /// <summary>
    /// Các nghiệp vụ  của Country.
    /// Kế thừa từ lớp cở sở BaseService.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class OrderBillService : BaseService<OrderBill>, IOrderBillService
    {
        IUnitOfWork _unitOfWork;
        #region Constructor
        /// <summary>
        /// Hàm khởi tạo.
        /// Kế thừa từ baseRepository.
        /// </summary>
        /// <param name="baseRepository">1 object thự thi IBaseRepository </param>
        /// CreatedBy: vmquang(16/5/2021)
        public OrderBillService(IUnitOfWork unitOfWork,IBaseRepository<OrderBill> baseRepository) : base(baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseResult CheckDuplicateUpDateOrderBill(string refCode, Guid id)
        {
            var result = new ResponseResult();
            var ob = _unitOfWork.OrderBillTask.CheckDuplicateUpDateOrderBill(refCode,id);
            result.Data = ob;
            return result;
        }

        public ResponseResult GetNewRefCode()
        {
            var result = new ResponseResult();
            var newCode = _unitOfWork.OrderBillTask.GetNewRefCode();
            result.Data = newCode;
            return result;
        }

        public ResponseResult GetOrderBillByRefCode(string refCode)
        {
            var result = new ResponseResult();
            var ob = _unitOfWork.OrderBillTask.GetOrderBillByRefCode(refCode);
            if (ob != null)
            {
                result.Data = ob;
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.DevMsg = Resources.Messages.ErrorDuplicate;
            }
            else
            {
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;

            }
            return result;
        }

        public ResponseResult GetOrderBillFilter(string refCode, string supplierName, string customerName, int? status, string description)
        {
            var result = new ResponseResult();

            var stores = _unitOfWork.OrderBillTask.GetOrderBillFilter(refCode, supplierName, customerName, status, description);

            if (stores != null)
            {
                result.Data = stores;
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                result.DevMsg = Resources.Messages.ErrorFilterData;
            }
            return result;
        }

        public override void ValidateInsertObject(ResponseResult responseResult, OrderBill entity)
        {
            var propertyUnique = "Số Phiếu";
            var propertyRequired = new Dictionary<string, string>();
            propertyRequired.Add("Số Phiếu", entity.RefCode);
            propertyRequired.Add("Ngày đặt hàng", entity.OrderDate.ToString());
            propertyRequired.Add("Trạng thái", entity.Status.ToString());
            propertyRequired.Add("Mã nhà cung cấp", entity.SupplierCode);
            propertyRequired.Add("Tên nhà cung cấp", entity.SupplierName);
            propertyRequired.Add("Mã người đặt", entity.CustomerCode);
            propertyRequired.Add("Tên người đặt", entity.CustomerName);
            propertyRequired.Add("Chi tiết đơn đặt hàng", entity.Detail);


            foreach (var property in propertyRequired)
            {
                if (string.IsNullOrEmpty(property.Value))
                {
                    responseResult.IsSuccess = false;
                    responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                    responseResult.DevMsg = property.Key + " " + Resources.Messages.ErrorInputData;
                    responseResult.Data = null;
                }
            }

            // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate
            var ob = _unitOfWork.OrderBillTask.GetOrderBillByRefCode(entity.RefCode);

            if (ob != null)
            {
                responseResult.IsSuccess = false;
                responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                responseResult.DevMsg = propertyUnique + " " + Resources.Messages.ErrorDuplicate;
            }
        }

        public override void ValidateUpdateObject(ResponseResult responseResult, OrderBill entity, Guid entityID)
        {
            var propertyUnique = "Số Phiếu";
            var propertyRequired = new Dictionary<string, string>();
            propertyRequired.Add("Số Phiếu", entity.RefCode);
            propertyRequired.Add("Ngày đặt hàng", entity.OrderDate.ToString());
            propertyRequired.Add("Trạng thái", entity.Status.ToString());
            propertyRequired.Add("Mã nhà cung cấp", entity.SupplierCode);
            propertyRequired.Add("Tên nhà cung cấp", entity.SupplierName);
            propertyRequired.Add("Mã người đặt", entity.CustomerCode);
            propertyRequired.Add("Tên người đặt", entity.CustomerName);
            propertyRequired.Add("Chi tiết đơn đặt hàng", entity.Detail);


            foreach (var property in propertyRequired)
            {
                if (string.IsNullOrEmpty(property.Value))
                {
                    responseResult.IsSuccess = false;
                    responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                    responseResult.DevMsg = property.Key + " " + Resources.Messages.ErrorInputData;
                    responseResult.Data = null;
                }
            }

            // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate
            var ob = _unitOfWork.OrderBillTask.CheckDuplicateUpDateOrderBill(entity.RefCode, entityID);

            if (ob != null)
            {
                responseResult.IsSuccess = false;
                responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                responseResult.DevMsg = propertyUnique + " " + Resources.Messages.ErrorDuplicate;
            }
        }


        #endregion
    }
}
