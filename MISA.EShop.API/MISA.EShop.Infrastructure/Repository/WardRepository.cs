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
    public class WardRepository:BaseRepository<Ward>, IWardRepository
    {
        /// <summary>
        /// Lấy danh sách phường/xã theo Id quận/huyện.
        /// </summary>
        /// <param name="districtId">Id quận huyên cần lấy.</param>
        /// <returns>Danh sách phường/xã.</returns>
        public IEnumerable<Ward> GetWardWithDistrict(Guid? districtId)
        {

            //#region Delcare
            //string queryString = $"SELECT w.DistrictId,w.WardId,w.WardName FROM Ward w  WHERE w.DistrictId ='{districtId}'";
            //#endregion
            //var wardList = _dbConnection
            //    .Query<Ward>(queryString);
            //return wardList;

            string procName = $"Proc_GetWardWithDistrict";

            var parameters = new DynamicParameters();
            parameters.Add("@DistrictId", districtId);

            var wardList = _dbConnection
                .Query<Ward>
                (procName, parameters, commandType: CommandType.StoredProcedure);
            return wardList;
        }
    }
}
