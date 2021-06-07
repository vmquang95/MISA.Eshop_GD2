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
    public class WardService : BaseService<Ward>, IWardService
    {
        IUnitOfWork _unitOfWork;
        public WardService(IUnitOfWork unitOfWork, IBaseRepository<Ward> baseRepository) : base(baseRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseResult GetWardWithDistrict(Guid? districtId)
        {
            var result = new ResponseResult();
            if (string.IsNullOrEmpty(districtId.ToString()))
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.DevMsg = Resources.Messages.ErrorInputData;
                result.UserMsg = Resources.Messages.ErrorIsNotExist;
            }
            else
            {
                var provinces = _unitOfWork.WardTask.GetWardWithDistrict(districtId);

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