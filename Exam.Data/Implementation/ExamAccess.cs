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

        public ExamAccess(IOptions<DbConfig> dbConfig):base(dbConfig){}

        public DbDataReader GetPermission()
        {
            string procedure="[dbo].[GetPermission]";
            return GetDataReader(1,procedure,null,CommandType.StoredProcedure);
        }

        public DbDataReader GetUser(Logindetails logindetails)
        {
            string procedure="[dbo].[GetUser]";
            List<DbParameter> DbParameter = new List<DbParameter>();
            DbParameter.Add(new SqlParameter{ParameterName="@username",Value=logindetails.username,SqlDbType=SqlDbType.VarChar});
               DbParameter.Add(new SqlParameter{ParameterName="@password",Value=logindetails.password,SqlDbType=SqlDbType.VarChar});
            return GetDataReader(1,procedure,DbParameter,CommandType.StoredProcedure);
        }
    }
}