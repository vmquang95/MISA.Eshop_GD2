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
    /// API cho Coutry
    /// Kế thừa  từ BaseController.
    /// </summary>
    /// CreatedBy: vmquang 14/5/2021.
    public class CountryController : BaseEntityController<Country>
    {
        #region Declare
        private ICountryService _countryService;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo, 1 đối tượng được tạo ra để thực thi ICountryService.
        /// </summary>
        /// <param name="countryService">đối tượng sẽ thực thi ICountryService</param>
        /// CreatedBy: vmquang 14/5/2021.
        public CountryController(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;
        }
        #endregion
    }

}
