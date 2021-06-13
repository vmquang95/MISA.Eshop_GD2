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

        public ResponseResult GetOrderBillFilter(string refCode, string supplierName, string customerName, int? status, string description)
        {
            var result = new ResponseResult();

            var stores = _unitOfWork.OrderBillTask.GetOrderBillFilter(refCode, supplierName, customerName, status, description);

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
        #endregion
    }
}
