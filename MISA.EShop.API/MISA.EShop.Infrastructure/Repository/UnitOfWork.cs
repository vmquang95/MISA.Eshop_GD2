using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IStoreRepository storeTask, 
            ICountryRepository countryTask, 
            IProvinceRepository provinceTask, 
            IDistrictRepository districtTask,
            IOrderBillRepository orderBillTask,
            IWardRepository wardTask)
        {
            StoreTask = storeTask;
            CountryTask = countryTask;
            ProvinceTask = provinceTask;
            DistrictTask = districtTask;
            WardTask = wardTask;
            OrderBillTask= orderBillTask;
        }

        public IStoreRepository StoreTask { get; }

        public ICountryRepository CountryTask { get; }

        public IProvinceRepository ProvinceTask { get; }

        public IDistrictRepository DistrictTask { get; }

        public IWardRepository WardTask { get; }
        public IOrderBillRepository OrderBillTask { get; }
    }
}
