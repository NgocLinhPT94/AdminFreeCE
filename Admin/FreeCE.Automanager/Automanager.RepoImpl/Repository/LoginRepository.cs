using System;
using System.Data;
using System.Data.SqlClient;
using Automanager.Entity.EntityModel;
using Automanager.RepoInterface.Repository;
using System.Linq;

namespace Automanager.RepoImpl.Repository
{
    public class LoginRepository : DbRepository,ILoginRepository
    {
        public int Login(string username, string pass)
        {
            return SpCheckLogin(username, pass);
        }


        #region ========Store procedure=================
        private int SpCheckLogin(string username,string pass)
        {
            var userNameParam = new SqlParameter
            {
                ParameterName = "@UserName",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = username.Trim(),
                Size = 10
            };
            if (userNameParam.Value == null)
                userNameParam.Value = DBNull.Value;

            var passParam = new SqlParameter
            {
                ParameterName = "@Pass",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Value = pass.Trim(),
                Size = 10
            };
            if (passParam.Value == null)
                passParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter
            {
                ParameterName = "@procResult",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[sp_test_login] @UserName,@Pass", userNameParam, passParam, procResultParam);

            return (int)procResultParam.Value;
        }
        #endregion
    }
}

