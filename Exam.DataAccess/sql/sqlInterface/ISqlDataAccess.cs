using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Exam.DataAccess.sql.sqlInterface
{

public interface ISqlDataAccess
{
     DbDataReader GetDataReader(int connectionId,string commandText, List<DbParameter> parameters, CommandType commandType);
       int ExecuteNonQuery(int connectionId,string commandText, List<DbParameter> parameters, CommandType commandType);
}

}