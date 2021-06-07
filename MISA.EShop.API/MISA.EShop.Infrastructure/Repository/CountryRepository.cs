using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    /// <summary>
    /// Lớp xử lý lấy Country.
    /// Tương tác trực tiếp với databse.
    /// Kế thừa từ lớp baseRepository.
    /// </summary>
    public class CountryRepository:BaseRepository<Country>, ICountryRepository
    {
    }
}
