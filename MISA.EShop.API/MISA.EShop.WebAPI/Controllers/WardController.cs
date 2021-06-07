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
    /// API cho Ward.
    /// Có kế thừa từ BaseEntitieController.
    /// Có thêm API riêng.
    /// </summary>
    /// CreatedBy: vmquang 14/5/2021.
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class WardController : BaseEntityController<Ward>
    {
        #region Declare
        private IWardService _wardService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wardService">1object thực thi IWardService</param>
        /// CreatedBy: vmquang(16/5/2021)
        public WardController(IWardService wardService) : base(wardService)
        {
            _wardService = wardService;
        }
        #endregion


        #region Methods
        /// <summary>
        /// API get , lấy xá/phường theo Id của Districted.
        /// </summary>
        /// <param name="provinceId">Id province</param>
        /// <returns>OK-200 lấy thành công dữ liệu. 404-url không đúng</returns>
        /// CreatedBy: vmquang(16/5/2021)
        [HttpGet("WithDistrict/{districtId}")]
        public IActionResult Get(Guid? districtId)
        {
            var responseResult = _wardService.GetWardWithDistrict(districtId);

            return Ok(responseResult);
        }
        #endregion
    }
}
