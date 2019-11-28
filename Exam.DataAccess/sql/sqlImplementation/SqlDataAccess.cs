using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Exam.Contract.DBconfig;
using Exam.DataAccess.sql.sqlInterface;
using Microsoft.Extensions.Options;

namespace Exam.DataAccess.sql.sqlImplementation
{


    public class SqlDataAccess : ISqlDataAccess
    {


        private DbConfig _dbConfiguration;
        public SqlDataAccess(IOptions<DbConfig> dbConfig)
        {
            _dbConfiguration = dbConfig.Value;
        }
        public String SqlConnectionString { get; set; }

        public DbDataReader GetDataReader(int connectionId, string commandText, List<DbParameter> parameters, CommandType commandType = CommandType.Text)
        {
            DbDataReader dataReader;

            try
            {
                SqlConnection connection = this.GetConnection(connectionId);

                DbCommand cmd = this.GetCommand(connection, commandText, commandType);

                UpdateDbNullValues(parameters);
                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataReader;
        }

        private DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType)
        {
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
            command.CommandType = commandType;
            command.CommandTimeout = 1000;
            return command;
        }

        private SqlConnection GetConnection(int connectionId)
        {  

            SqlConnectionString = _dbConfiguration.DefaultConnectionString;
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }

        private void UpdateDbNullValues(IList<DbParameter> parameterValues)
        {
            if (parameterValues != null)
            {
                //Iterate through all the parameters and replace null values with DbNull.Value
                foreach (DbParameter sqlParameter in parameterValues)
                {
                    if ((sqlParameter.Value is string && string.IsNullOrEmpty(sqlParameter.Value.ToString())) || sqlParameter.Value == null)
                    {
                        sqlParameter.Value = DBNull.Value;
                    }
                }
            }
        }


 public int ExecuteNonQuery(int connectionId, string commandText, List<DbParameter> parameters, CommandType commandType = CommandType.Text)
        {
            int returnValue = -1;
            try
            {
                using (SqlConnection connection = this.GetConnection(connectionId))
                {
                    DbCommand cmd = this.GetCommand(connection, commandText, commandType);
                    UpdateDbNullValues(parameters);
                    if (parameters != null && parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    
                    }

                    returnValue = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }



    }

}