using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Lớp IBaseService các thao tác chung xử lý nghiệp vụ của các thực thể.
    /// </summary>
    /// <typeparam name="T">Kiểu của thực thể</typeparam>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IBaseService<T>
    {
        #region Methods
        /// <summary>
        /// Lấy toàn bộ dữ liệu các bản ghi của Thực thể trong database
        /// </summary>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        ResponseResult GetEntities();

        /// <summary>
        /// Nghiệp vụ Lấy thông tin của thực thể theo id.
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        ResponseResult GetById(Guid entityId);

        /// <summary>
        /// Nghiệp vụ Thêm mới một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        ResponseResult Insert(T entity);

        /// <summary>
        /// Nghiệp vụ sửa thông tin 1 trường dữ liệu thực thể một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        /// CreatedBy: vmquang(14/5/2021).
        ResponseResult Update(T entity, Guid entityId);

        /// <summary>
        /// Nghiệp vụ Xóa một bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của thực thể  cần xóa</param>
        /// <returns>ResponseResult gồm Data,DevMsg,UserMsg,ErrorCode,...</returns>
        ResponseResult Delete(Guid entityId);
        #endregion
    }
}
