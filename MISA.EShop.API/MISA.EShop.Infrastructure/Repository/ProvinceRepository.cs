using Dapper;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    public class ProvinceRepository:BaseRepository<Province>, IProvinceRepository
    {
        /// <summary>
        /// Lây danh sách tỉnh/thành phố theo Id quốc gia.
        /// </summary>
        /// <param name="countryId">Id quốc gia.</param>
        /// <returns>Danh sách tỉnh/thành phố thuộc Id quốc gia.</returns>
        public IEnumerable<Province> GetProvinceWithCountry(Guid? countryId)
        {
            //string queryString = $"SELECT p.CountryId,p.ProvinceId,p.ProvinceName FROM Province p WHERE p.CountryId = '{countryId}'";

            //var provinceList = _dbConnection
            //    .Query<Province>(queryString);
            //return provinceList;

            string procName = "Proc_GetProvinceWithCountry";
            var parameters = new DynamicParameters();
            parameters.Add("@CountryId", countryId);

            var provinceList = _dbConnection
                .Query<Province>
                (procName, parameters, commandType: CommandType.StoredProcedure);
            return provinceList;

        }
    }
}
