using System.Collections.Generic;
using Exam.Contract.Model;

namespace Exam.Contract.IRepository
{

public interface IExamRepository
{
      OwnerDetails  GetUser(Logindetails logindetails);
      List<Permission> GetPermission();
}


}