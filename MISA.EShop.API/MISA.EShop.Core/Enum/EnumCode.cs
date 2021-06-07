using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Enum
{
    /// <summary>
    /// Chứa mã các mã code trả về khi có lỗi xảy ra.
    /// OK-200: lấy dữ liệu thành công.
    /// NOTFOUND-404: url không đúng.
    /// BADREQUEST-400: Lỗi dữ liệu đầu vào sai.
    /// EXEPTION=500: Lỗi phía serve
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public enum ErrorCode
    {
        #region Declare
        NONE = 0,
        OK=200,
        NOTFOUND = 404,
        BADREQUEST = 400,
        NOCONTENT = 204,
        EXCEPTION = 500,
        #endregion

    }

    
}
