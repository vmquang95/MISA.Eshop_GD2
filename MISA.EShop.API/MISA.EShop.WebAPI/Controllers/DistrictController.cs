using Microsoft.AspNetCore.Mvc;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.EShop.WebAPI.Controllers
{

    /// <summary>
    /// API cho District.
    /// Có kế thừa từ BaseEntitieController.
    /// </summary>
    /// CreatedBy: vmquang 14/5/2021.
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DistrictController : BaseEntityController<District>
    {
        #region Declare
        private IDistrictService _districtService;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo.
        /// </summary>
        /// <param name="districtService"></param>
        /// CreatedBy: vmquang 14/5/2021.
        public DistrictController(IDistrictService districtService) : base(districtService)
        {
            _districtService = districtService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// API get , lấy phường/xã theo Id của Province.
        /// </summary>
        /// <param name="provinceId">Id province</param>
        /// <returns>OK-200 lấy thành công dữ liệu. 404-url không đúng</returns>
        [HttpGet("WithProvince/{provinceId}")]
        public IActionResult Get(Guid? provinceId)
        {
            var responseResult = _districtService.GetDistrictWithProvince(provinceId);

            return Ok(responseResult);
        }
        #endregion
    }
}
