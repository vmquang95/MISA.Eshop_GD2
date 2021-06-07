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
        #region Properties
        /// <summary>
        /// object đại diện cho IStoreRepository
        /// </summary>
        /// CreatedBy: vmquang (14/5/2021)
        IStoreRepository StoreTask { get; }

        /// <summary>
        /// object đại diện cho ICountryRepository
        /// </summary>
        /// CreatedBy: vmquang (14/5/2021)
        ICountryRepository CountryTask { get; }

        /// <summary>
        /// object đại diện cho IProvinceRepository
        /// </summary>
        /// CreatedBy: vmquang (14/5/2021)
        IProvinceRepository ProvinceTask { get; }

        /// <summary>
        /// object đại diện cho IDistrictRepository
        /// </summary>
        /// CreatedBy: vmquang (14/5/2021)
        IDistrictRepository DistrictTask { get; }

        /// <summary>
        /// object đại diện cho IWardRepository
        /// </summary>
        /// CreatedBy: vmquang (14/5/2021)
        IWardRepository WardTask { get; }

        IOrderBillRepository OrderBillTask { get; }
        #endregion
    }
}
