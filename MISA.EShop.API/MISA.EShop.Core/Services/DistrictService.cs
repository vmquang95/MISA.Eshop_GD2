using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Services
{

    /// <summary>
    ///  bao gồm các nghiệp vụ chung của Country.
    /// Kế thừa từ lớp cở sở IBaseRepository.
    /// Có thêm method riêng.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class DistrictService:BaseService<District>, IDistrictService
    {
        IUnitOfWork _unitOfWork;
        public DistrictService(IUnitOfWork unitOfWork, IBaseRepository<District> baseRepository) : base(baseRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseResult GetDistrictWithProvince(Guid? provinceId)
        {
            var result = new ResponseResult();

            if (string.IsNullOrEmpty(provinceId.ToString()))
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.DevMsg = Resources.Messages.ErrorInputData;
                result.UserMsg = Resources.Messages.ErrorIsNotExist;
            }
            else
            {

                var provinces = _unitOfWork.DistrictTask.GetDistrictWithProvince(provinceId);

                if (provinces != null)
                {
                    result.Data = provinces;
                    result.IsSuccess = true;
                    result.ErrorCode = Enum.ErrorCode.NONE;
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                    result.DevMsg = Resources.Messages.NoContentData;
                    result.UserMsg = Resources.Messages.NoContentData;
                }
            }
            return result;
        }
    }
}
