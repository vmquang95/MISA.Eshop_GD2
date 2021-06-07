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
    /// API cho Province.
    /// Có kế thừa từ BaseEntitieController.
    /// </summary>
    /// CreatedBy: vmquang 14/5/2021.
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ProvinceController : BaseEntityController<Province>
    {
        #region Declare
        private IProvinceService _provinceService;
        #endregion

        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="provinceService"></param>
        /// CreatedBy: vmquang 14/5/2021.
        public ProvinceController(IProvinceService provinceService) : base(provinceService)
        {
            _provinceService = provinceService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// api lấy tình/thành phố theo id country
        /// </summary>
        /// <param name="countryId">id country</param>
        /// <returns>Ok-200 lấy thành cong dữ liệu , 404 url lỗi.</returns>
        /// Createdby: vmquang 14/5/2021.
        [HttpGet("WithCountry/{countryId}")]
        public IActionResult Get(Guid? countryId)
        {
            var responseResult = _provinceService.GetProvinceWithCountry(countryId);

            return Ok(responseResult);
        }
        #endregion
    }

}
