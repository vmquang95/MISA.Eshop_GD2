using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Enum
{
    /// <summary>
    /// enum chứa tình trạng cửa hàng (0-đang hoat dộng , 1- đang đóng cửa)
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public enum StatusStore
    {
        #region Declare
        isAlive = 0,
        isnotAlive = 1,
        #endregion
    }
}
