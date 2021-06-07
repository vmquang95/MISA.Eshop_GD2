using Microsoft.AspNetCore.Mvc;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.EShop.WebAPI.Controllers
{
    /// <summary>
    /// API dùng chung cho các thực thể.
    /// Các API của các thực thẻ khác sẽ kế thừa.
    /// </summary>
    /// <typeparam name="T">Thực thể đại diện chung.</typeparam>
    /// CreatedBy: vmquang 14/5/2021.
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Delare
        private IBaseService<T> _baseService;
        #endregion

        #region Constructor
        /// <summary>
        /// hàm khởi tạo 1 đối tượng sẽ thực thi IBaseService
        /// </summary>
        /// <param name="baseService">1 đối tượng hực thi IBaseService</param>
        /// CreatedBy: vmquang 14/5/2021.
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Methods API
        /// <summary>
        /// API GET
        /// </summary>
        /// <returns>OK-thành công , Badrequest-dữ liệu không đúng.</returns>
        /// CreatedBy: vmquang 14/5/2021.
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var responseResult = _baseService.GetEntities();
                return Ok(responseResult);

            }
            catch (Exception)
            {

                return BadRequest();
            }
            /*var responseResult = new ResponseResult();
            try
            {
                 responseResult.Data = _baseService.GetEntities();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new JsonResult(responseResult);*/
        }


        /// <summary>
        /// API Get theo Id
        /// </summary>
        /// <param name="entityId">id cần Get, truyên qua Router</param>
        /// <returns>OK-200 hoặc 400-badRequest</returns>
        /// CreatedBy: vmquang 14/5/2021.
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var responseResult = _baseService.GetById(entityId);
            return Ok(responseResult);
        }

        /// <summary>
        /// API Post, thêm mới dữ liệu. truyền qua body
        /// </summary>
        /// <param name="entity">đối tượng thực thể cần thêm mới</param>
        /// <returns>201-thêm mới thành công , 400-badrequest</returns>
        /// CreatedBy: vmquang 14/5/2021.
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {

            var responseResult = _baseService.Insert(entity);
            if(responseResult.IsSuccess)
            {

            return Created(Messages.InsertDataSuccess, responseResult);
            }
            else
            {
                return BadRequest(responseResult);
            }
        }

        /// <summary>
        /// API PUT, sửa 1 thực thể, truyền qua body
        /// </summary>
        /// <param name="entityId">Id đối tượng thực thể cần sửa.</param>
        /// <param name="entity">đối tượng chưa các thông tin cần sửa</param>
        /// <returns>200-OKe sửa thành công. 400-badreqeust</returns>
        /// CreatedBy: vmquang 14/5/2021.
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId, [FromBody] T entity)
        {
            var responseResult = _baseService.Update(entity, entityId);
            if (responseResult.IsSuccess)
            {

            return Ok(responseResult);
            }
            else
            {
                return BadRequest(responseResult);

            }
        }

        /// <summary>
        /// API delete , tham số truyền qua router
        /// </summary>
        /// <param name="entityId">id đối tượng thực thể cần xóa.</param>
        /// <returns>200-xóa thành công</returns>
        /// CreatedBy: vmquang 14/5/2021.
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var responseResult = _baseService.Delete(entityId);
            return Ok(responseResult);
        }
        #endregion
    }

}
