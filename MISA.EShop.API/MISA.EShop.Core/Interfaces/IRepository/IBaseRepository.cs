using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Base Repository, chứa các method chung thao tác với Databse.
    /// </summary>
    /// <typeparam name="T">Thực thể đại diện Store,Ward,Province,...</typeparam>
    /// CreatedBy: vmquang(14/5/2021).
    public interface IBaseRepository<T>
    {
        #region Methods
        /// <summary>
        /// Lấy toàn bộ dữ liệu các bản ghi của Thực thể.
        /// Thao tác trực tiếp với database.
        /// </summary>
        /// <returns>Danh sách bản ghi của thực thể.</returns>
        /// CreatedBy: vmquang(14/5/2021).
        IEnumerable<T> GetEntities();

        /// <summary>
        /// Lấy dữ liệu của thực thể theo khóa chính Id.
        /// Thao tác trực tiếp với database.
        /// </summary>
        /// <param name="entityId">ID của thực thể.</param>
        /// <returns>1 bản ghi dữ liệu duy nhất của thực thể có ID tương ứng</returns>
        /// CreatedBy: vmquang(14/5/2021).
        T GetById(Guid entityId);

        /// <summary>
        /// Thêm mới một bản ghi của thực thể.
        /// Thao tác trực tiếp với database.
        /// </summary>
        /// <param name="entity">Thực thể thêm mới</param>
        /// <returns>Số bản ghi thêm mới thành công.(-1 fail)</returns>
        /// CreatedBy: vmquang(14/5/2021).
        int Insert(T entity);

        /// <summary>
        /// Sửa thông tin của bản ghi thực thể theo Id.
        /// Thao tác trực tiếp với database.
        /// </summary>
        /// <param name="entity">Thực thể cần sửa.</param>
        /// <param name="entityId">ID của thực thể cần sửa.</param>
        /// <returns>Số bản ghi được sửa thông tin(-1 fail)</returns>
        /// CreatedBy: vmquang(14/5/2021).
        int Update(T entity, Guid entityId);

        /// <summary>
        /// Xóa một bản ghi theo ID.
        /// Thao tác trực tiếp với database.
        /// </summary>
        /// <param name="entityId">ID của thực thể cần xóa</param>
        /// <returns>Số bản ghi đã xóa thành công (-1 fail)</returns>
        /// CreatedBy: vmquang(14/5/2021).
        int Delete(Guid entityId);
        #endregion

    }
}
