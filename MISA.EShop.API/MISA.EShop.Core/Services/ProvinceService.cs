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
    public class ProvinceService:BaseService<Province>, IProvinceService
    {
        IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork, IBaseRepository<Province> baseRepository) : base(baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseResult GetProvinceWithCountry(Guid? countryId)
        {
            var result = new ResponseResult();

            if (string.IsNullOrEmpty(countryId.ToString()))
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.DevMsg = Resources.Messages.ErrorInputData;
                result.UserMsg = Resources.Messages.ErrorIsNotExist;
            }
            else
            {
                var provinces = _unitOfWork.ProvinceTask.GetProvinceWithCountry(countryId);

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
