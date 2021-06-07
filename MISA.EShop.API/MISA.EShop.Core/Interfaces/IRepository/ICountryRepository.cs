using MISA.EShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    /// <summary>
    /// Interface bao gồm các hàm của Country.
    /// Tương tác với Database.
    /// Kế thừa từ lớp cở sở IBaseRepository.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public interface ICountryRepository:IBaseRepository<Country>
    {
    }
}
