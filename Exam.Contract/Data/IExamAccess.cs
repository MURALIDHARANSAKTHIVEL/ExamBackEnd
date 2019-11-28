using System;
using System.Data.Common;
using Exam.Contract.Model;

namespace Exam.Contract.Data
{

    public interface IExamAccess
    {
        DbDataReader GetUser(Logindetails logindetails);
        DbDataReader GetPermission();
        int CreateUser(OwnerDetails newuser);
    }
}