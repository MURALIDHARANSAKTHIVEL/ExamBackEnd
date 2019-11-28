

using System;
using Exam.Contract.Class;
using System.Data.Common;
using Exam.Contract.Data;
using Exam.Contract.IRepository;
using Exam.Contract.Model;
using System.Collections.Generic;

namespace Exam.Business.Repository
{


    public class ExamRepository : IExamRepository
    {

        private IExamAccess _ExamAcces;
        public ExamRepository(IExamAccess examAccess)
        {
            _ExamAcces = examAccess;
        }

        public string CreateUser(OwnerDetails newuser)
        {
          int dataReader= _ExamAcces.CreateUser(newuser);

          return "vxv";  
        }

        public List<Permission> GetPermission()
        {
            List<Permission> permissions=new List<Permission>();
            using(DbDataReader dataReader= _ExamAcces.GetPermission())
            {

                    permissions = dataReader.ToCustomList<Permission>();
                    return permissions;
            }
        }

        public OwnerDetails GetUser(Logindetails logindetails)
        {
            OwnerDetails ownerdetail = new OwnerDetails();
            using (DbDataReader datareader = _ExamAcces.GetUser(logindetails))
            {
                ownerdetail = datareader.ToCustomEntity<OwnerDetails>();
                return ownerdetail;
            }

        }



    }

}