using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.EShop.Core.Entities;

namespace MISA.EShop.Core.Services
{
    /// <summary>
    /// Lớp BaseService các thao tác chung.
    /// Xử lý nghiệp vụ của các Entities.
    /// </summary>
    /// <typeparam name="T">Kiểu của thực thể</typeparam>
    /// CreatedBy: vmquang(14/5/2021).
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        //Khởi tạo object thực implement IBaseRepository
        protected IBaseRepository<T> _baseRespository;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo.
        /// </summary>
        /// <param name="baseRespository">1 đối tượng cụ thể thực thi IBaseRepository</param>
        public BaseService(IBaseRepository<T> baseRespository)
        {
            _baseRespository = baseRespository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Nghiệp vụ Lấy thông tin của thực thể theo id.
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        public ResponseResult GetById(Guid entityId)
        {
            //kết quả trả về.
            var result = new ResponseResult();

            //kiểm tra id có  null/empty.Nếu có gán lỗi cho kết quả trả về.
            if (string.IsNullOrEmpty(entityId.ToString()))
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.DevMsg = Resources.Messages.ErrorIsNotExist;
            }
            //có id
            else
            {
                //lấy dữ liệu thực thể theo id từ DB, trả về 1 đối tượng.
                var entity = _baseRespository.GetById(entityId);

                //có đối tượng,gán data , gán message
                if (entity != null)
                {
                    result.Data = entity;
                    result.IsSuccess = true;
                    result.ErrorCode = Enum.ErrorCode.NONE;
                    result.UserMsg = Resources.Messages.GetDataSuccess;

                }
                //không có dữ liệu trả về , gán message thông báo/
                else
                {
                    result.IsSuccess = false;
                    result.DevMsg = Resources.Messages.ErrorIsNotExist;
                    result.UserMsg = Resources.Messages.ErrorIsNotExist;
                }
            }

            return result;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu các bản ghi của Thực thể trong database
        /// </summary>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        public ResponseResult GetEntities()
        {
            var entities = _baseRespository.GetEntities();

            var result = new ResponseResult();
            if (entities != null)
            {
                result.Data = entities;
                result.ErrorCode = Enum.ErrorCode.NONE;
                result.UserMsg = Resources.Messages.GetDataSuccess;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = Resources.Messages.NotFoundData;
                result.DevMsg = Resources.Messages.NoContentData;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
            }

            return result;
        }

        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        public ResponseResult Insert(T entity)
        {
            var result = new ResponseResult();
            string functionName = "Insert";
            
            // Validate nghiệp vụ
            Validate(result, entity, null, functionName);

            if (result.IsSuccess == true)
            {
                // Thực hiện thêm mới
                var rowAffects = _baseRespository.Insert(entity);

                if (rowAffects == 1)
                {
                    result.IsSuccess = true;
                    result.ErrorCode = Enum.ErrorCode.NONE;
                    result.UserMsg = Resources.Messages.InsertDataSuccess;
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorCode = Enum.ErrorCode.EXCEPTION;
                    result.DevMsg = Resources.Messages.ErrorInsertData;
                    result.UserMsg = Resources.Messages.ErrorInsertData;
                }
            }

            return result;
        }

        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần update</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        public ResponseResult Update(T entity, Guid entityId)
        {
            var result = new ResponseResult();
            string functionName = "Update";

            //Validate nghiệp vụ khi cập nhật

            Validate(result, entity, entityId, functionName);

            if (result.IsSuccess == true)
            {
                // thực hiện cập nhật
                var rowAffects = _baseRespository.Update(entity, entityId);

                if (rowAffects == 1)
                {
                    result.IsSuccess = true;
                    result.ErrorCode = Enum.ErrorCode.NONE;
                    result.UserMsg = Resources.Messages.UpdateDataSuccess;

                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorCode = Enum.ErrorCode.EXCEPTION;
                    result.DevMsg = Resources.Messages.ErrorUpdateData;
                    result.UserMsg = Resources.Messages.ErrorUpdateData;

                }
            }
            return result;
        }

        /// <summary>
        /// Xóa một bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của thực thể  cần xóa</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang 14/5/2021.
        public ResponseResult Delete(Guid entityId)
        {
            // xóa.
            var rowAffects = _baseRespository.Delete(entityId);

            var result = new ResponseResult();
            if (rowAffects == 1)
            {
                result.ErrorCode = Enum.ErrorCode.NONE;
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = Resources.Messages.NoContentData;
                result.DevMsg = Resources.Messages.NoContentData;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
            }

            return result;
        }

        /// <summary>
        /// Method nghiệp vụ validate dữ liệu chung ho các entities.
        /// Các entity sẽ override lại nếu dùng.
        /// </summary>
        /// <param name="responseResult">Kết quả trả về</param>
        /// <param name="entity">thực thể cần validate</param>
        public virtual void Validate(ResponseResult responseResult, T entity, Guid? entityID, string functionName)
        {
    
        }

        #endregion
    }
}
