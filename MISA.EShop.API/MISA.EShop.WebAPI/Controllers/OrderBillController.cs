using Microsoft.AspNetCore.Mvc;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces.IService;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.EShop.WebAPI.Controllers
{
    
    /// <summary>
    /// API cho Coutry
    /// Kế thừa  từ BaseController.
    /// </summary>
    /// CreatedBy: vmquang 14/5/2021.
    public class OrderBillController : BaseEntityController<OrderBill>
    {
        #region Declare
        private IOrderBillService _orderBillService;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo, 1 đối tượng được tạo ra để thực thi ICountryService.
        /// </summary>
        /// <param name="countryService">đối tượng sẽ thực thi ICountryService</param>
        /// CreatedBy: vmquang 14/5/2021.
        public OrderBillController(IOrderBillService orderBillService) : base(orderBillService)
        {
            _orderBillService = orderBillService;
        }
        #endregion
        [HttpGet("Filter")]
        public IActionResult Get([FromQuery] FilterOrderBillParams filterparams)
        {
            var responseResult = new ResponseResult();
            try
            {
                responseResult = _orderBillService.GetOrderBillFilter(
                    filterparams.refCode,
                    filterparams.supplierName,
                    filterparams.customerName,
                    filterparams.status,
                    filterparams.description);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }
            return Ok(responseResult);
        }

        /// <summary>
        /// API lấy thông tin đối tượng theo mã 
        /// </summary>
        /// <param name="refCode">Mã cửa hàng</param>
        /// <returns>ResponseResult với data là Danh sách bản ghi có mã cửa hàng bằng mã cửa hàng truyền vào</returns>
        /// CreatedBy: vmquang 14.5.20201
        [HttpGet("getbycode")]
        public IActionResult Get(string refCode)
        {
            var responseResult = new ResponseResult();
            try
            {
                responseResult = _orderBillService.GetOrderBillByRefCode(refCode);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }

            return Ok(responseResult);
        }
    }
}
