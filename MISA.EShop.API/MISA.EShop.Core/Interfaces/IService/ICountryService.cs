using MISA.EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Interface bao gồm các hàm xử lý nghiệp vụ của Country.
    /// Kế thừa từ lớp cở sở IBaseService.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface ICountryService : IBaseService<Country>
    {
    }
}
