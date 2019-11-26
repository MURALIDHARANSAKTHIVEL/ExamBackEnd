using System;
using System.Collections.Generic;
using Exam.Contract.IOrchestration;
using Exam.Contract.IRepository;
using Exam.Contract.Model;

namespace Exam.Business.Orchestration{


public class ExamOrchestration : IExamOrchestration
{
 

private IExamRepository _ExamRepository;
public ExamOrchestration(IExamRepository examRepository)
{
_ExamRepository=examRepository;
}
        public OwnerDetails GetUser(Logindetails logindetails)
        {
            return _ExamRepository.GetUser(logindetails);
        }
        public List<Permission> GetPermission()
        {

            return _ExamRepository.GetPermission();
        }
    }

}