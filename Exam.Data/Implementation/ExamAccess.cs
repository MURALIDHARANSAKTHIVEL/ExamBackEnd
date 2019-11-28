using System.Data.Common;
using Exam.Contract.Data;
using Exam.DataAccess.sql.sqlImplementation;
using System;
using Microsoft.Extensions.Options;
using Exam.Contract.DBconfig;
using System.Data;
using Exam.Contract.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exam.Data.Implementation
{

    public class ExamAccess : SqlDataAccess, IExamAccess
    {

        public ExamAccess(IOptions<DbConfig> dbConfig) : base(dbConfig) { }

        public int CreateUser(OwnerDetails newuser)
        {
            string procedure = "[dbo].[CreateUser]";
            List<DbParameter> DbParameter = new List<DbParameter>();
            DbParameter.Add(new SqlParameter { ParameterName = "@firstname", Value = newuser.firstname, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@lastname", Value = newuser.lastname, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@employee_Id", Value = newuser.employee_Id, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@email", Value = newuser.email, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@mobileNumber", Value = newuser.mobileNumber, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@roleKey", Value = newuser.roleKey, SqlDbType = SqlDbType.Int });
            DbParameter.Add(new SqlParameter { ParameterName = "@permission", Value = newuser.permission, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@genderkey", Value = newuser.genderkey, SqlDbType = SqlDbType.Int });
            DbParameter.Add(new SqlParameter { ParameterName = "@displaypicture", Value = newuser.displaypicture, SqlDbType = SqlDbType.VarBinary });
            DbParameter.Add(new SqlParameter { ParameterName = "@createdBy", Value = newuser.createdBy, SqlDbType = SqlDbType.Int });
            DbParameter.Add(new SqlParameter { ParameterName = "@password", Value = newuser.password, SqlDbType = SqlDbType.VarChar });
            
            return ExecuteNonQuery(1, procedure, DbParameter, CommandType.StoredProcedure);
        }

        public DbDataReader GetPermission()
        {
            string procedure = "[dbo].[GetPermission]";
            return GetDataReader(1, procedure, null, CommandType.StoredProcedure);
        }

        public DbDataReader GetUser(Logindetails logindetails)
        {
            string procedure = "[dbo].[GetUser]";
            List<DbParameter> DbParameter = new List<DbParameter>();
            DbParameter.Add(new SqlParameter { ParameterName = "@username", Value = logindetails.username, SqlDbType = SqlDbType.VarChar });
            DbParameter.Add(new SqlParameter { ParameterName = "@password", Value = logindetails.password, SqlDbType = SqlDbType.VarChar });
            return GetDataReader(1, procedure, DbParameter, CommandType.StoredProcedure);
        }
    }
}