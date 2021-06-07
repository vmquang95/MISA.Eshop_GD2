using MISA.EShop.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Results
{
    /// <summary>
    /// Class lưu trử thông tin trả về của Services.
    /// Class lưu trữ hàm xử lý lỗi phía Services.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021)
    public class ResponseResult
    {
        #region Properties
        // Thành công hay thất bại, mặc định true.
        public bool IsSuccess { get; set; } = true;

        // Messagess cho lập trình viên.
        public string DevMsg { get; set; }

        // Messagess cho user
        public string UserMsg { get; set; }

        // Mã lỗi thao tác, mặc định là NONE(0) không có lỗi.
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NONE;

        // Thông tin thêm thêm cho lập trình viên.
        public string MoreInfo { get; set; }

        // Mã lỗi để tra cữu.
        public string TraceId { get; set; }

        // Dữ liệu trả về dạng Object.
        public object Data { get; set; }
        #endregion


        #region Methods
        /// <summary>
        /// Xử lý lỗi ngoại lệ
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ex"></param>
        /// CreatedBy: vmquang(14/5/2021)
        public void OnException(ResponseResult result, Exception ex)
        {
            result.UserMsg = Resources.Messages.ExceptionUser;
            result.DevMsg = Resources.Messages.ExceptionUser;
            result.IsSuccess = false;
            result.ErrorCode = ErrorCode.EXCEPTION;
        }

        /// <summary>
        /// Xử lý lỗi dữ liệu sai từ phía Client.
        /// </summary>
        /// <param name="result"></param>
        /// CreatedBy: vmquang(14/5/2021)
        public void OnBadRequest(ResponseResult result)
        {
            result.IsSuccess = false;
            result.ErrorCode = ErrorCode.BADREQUEST;
            result.DevMsg = Resources.Messages.ErrorInputData;
            result.UserMsg = Resources.Messages.ErrorInputData;
        }
        #endregion
    }
}
