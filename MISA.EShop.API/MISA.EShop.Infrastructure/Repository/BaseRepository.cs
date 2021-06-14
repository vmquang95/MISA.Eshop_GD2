﻿using Dapper;
using MISA.EShop.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MISA.EShop.Core.Entities;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    /// <summary>
    /// Lớp base thao tác với database
    /// </summary>
    /// <typeparam name="T">đại diên cho thực thể</typeparam>
    /// Created By: vmquang 15/6/2021
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected string _tableName = string.Empty;

        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database=MF806_VMQUANG_MISA.Eshop; " +
               "convert zero datetime=True;";

        protected IDbConnection _dbConnection;
        public BaseRepository()
        {
            _tableName = typeof(T).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }


        /// <summary>
        /// Lấy tất cả dữ liệu của dối tượng
        /// </summary>
        /// <returns>Danh sách dữ liệu của đố tượng</returns>
        /// Created By: vmquang 15/6/2021
        public IEnumerable<T> GetEntities()
        {
            // Thực hiện lấy dữ liệu từ Database
            var entities = _dbConnection.Query<T>(
                $"Proc_Get{_tableName}s",
                commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Lấy 1 dữ liệu theo id
        /// </summary>
        /// <param name="entityId">id cần lấy</param>
        /// <returns>1 đối tượng</returns>
        public T GetById(Guid entityId)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_Get{_tableName}ById";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeGetByIdParamName, entityId);

            var entity = _dbConnection.Query<T>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return entity;
        }
        /// <summary>
        /// Insert dữ liệu vào db
        /// </summary>
        /// <param name="entity">đối tượng chứa dữ liệu cần insert</param>
        /// <returns>số bản ghi thao tác thành cồng</returns>
        /// Created By: vmquang 15/6/2021
        public int Insert(T entity)
        {
            var keyprop = GetKeyProperty();
            var keyValue = keyprop.GetValue(entity);
            if (keyValue == null || keyValue.ToString() == "")
            {
                var newValue = new Guid();
                keyprop.SetValue(keyprop.Name, newValue);
            }
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName,
                param: storeParam,
                commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Insert dữ liệu vào db
        /// </summary>
        /// <param name="entity">đối tượng chứa dữ liệu cần Update</param>
        /// <param name="entityId">id đối tượng hiện tại cần update</param>
        /// <returns>số bản ghi thao tác thành cồng</returns>
        /// Created By: vmquang 15/6/2021
        public int Update(T entity, Guid entityId)
        {
            var storeName = $"Proc_Update{_tableName}";
            var keyProperty = GetKeyProperty();
            var properties = typeof(T).GetProperties();
            var storeParam = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                if (property.Name == keyProperty.Name)
                {
                    continue;
                }
                var propertyValue = property.GetValue(entity);
                storeParam.Add($"@{propertyName}", propertyValue);

            }
            storeParam.Add($"@{keyProperty.Name}", entityId);
            var rowAffects = _dbConnection.Execute(
                storeName,
                param: storeParam,
                commandType: CommandType.StoredProcedure);

            return rowAffects;
        }

        /// <summary>
        /// Xóa dữ liêu từ db theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>số bản ghi xóa thành công</returns>
        /// Created By: vmquang 15/6/2021
        public int Delete(Guid entityId)
        {
            // Thực hiện xóa dữ liệu từ Database:
            var storeName = $"Proc_Delete{_tableName}";
            var keyProperty = GetKeyProperty();
            var storeParam = new Dictionary<string, object>
            {
                { keyProperty.Name, entityId }
            };
            var rowEffects = _dbConnection.Execute(
                storeName,
                param: storeParam,
                commandType: CommandType.StoredProcedure);
            return rowEffects;
        }

        /// <summary>
        /// Lấy ra khóa chính của đối tượng
        /// </summary>
        /// <returns>thuộc tính là khóa chính của đối tượng</returns>
        /// CreatedBy: 14.04.2021
        public PropertyInfo GetKeyProperty()
        {
            var keyProperty = typeof(T)
                .GetProperties()
                .Where(p => p.IsDefined(typeof(KeyAttribute), false))
                .FirstOrDefault();
            return keyProperty;
        }

        // hàm hủy kết nối
        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
