using System;
using System.Collections.Generic;
using Exam.Contract.Model;

namespace Exam.Contract.IOrchestration
{

    public interface IExamOrchestration
    {

    OwnerDetails GetUser(Logindetails logindetails);

    List<Permission> GetPermission();
    }
}
