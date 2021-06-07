using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Services
{
    /// <summary>
    /// Các nghiệp vụ  của Country.
    /// Kế thừa từ lớp cở sở BaseService.
    /// </summary>
    /// CreatedBy: vmquang(14/5/2021).
    public class CountryService : BaseService<Country>, ICountryService
    {
        #region Constructor
        /// <summary>
        /// Hàm khởi tạo.
        /// Kế thừa từ baseRepository.
        /// </summary>
        /// <param name="baseRepository">1 object thự thi IBaseRepository </param>
        /// CreatedBy: vmquang(16/5/2021)
        public CountryService(IBaseRepository<Country> baseRepository) : base(baseRepository)
        {
        }
        #endregion
    }
}
