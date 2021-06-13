using MISA.EShop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Interface chứa các việc xử lý nghiệp vụ chung của các đối tượng.
    /// </summary>
    /// CreatedBy: vmquang (14/5/2021)
    public interface IUnitOfWork
    {
        IOrderBillRepository OrderBillTask { get; }
    }
}
