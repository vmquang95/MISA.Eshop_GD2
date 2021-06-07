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
    public class DistrictRepository:BaseRepository<District>, IDistrictRepository
    {
        /// <summary>
        /// Lấy danh sách quận/huyện theo Id Tỉnh/thành phố.
        /// </summary>
        /// <param name="provinceId">ID tỉnh thành phố cần quận/huyện.</param>
        /// <returns>Danh sách qận/huyện</returns>
        public IEnumerable<District> GetDistrictWithProvince(Guid? provinceId)
        {
            //#region Declare
            //string queryString = $"SELECT d.ProvinceId,d.DistrictId,d.DistrictName FROM District d  WHERE d.ProvinceId ='{provinceId}'";
            //var districtList = _dbConnection
            //    .Query<District>(queryString);
            //#endregion
            //return districtList;

            string procName = $"Proc_GetDistrictWithProvince";

            var parameters = new DynamicParameters();
            parameters.Add("@ProvinceId", provinceId);

            var districtList = _dbConnection
                .Query<District>
                (procName, parameters, commandType: CommandType.StoredProcedure);
            return districtList;
        }
    }
}
