using System;
namespace Exam.Contract.Model
{

    public class OwnerDetails
    {

        public Int64 userKey { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string employee_Id { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public int roleKey { get; set; }
        public string permission { get; set; }
         public int genderkey { get; set; }
        public byte[] displaypicture { get; set; }
        public int createdBy { get; set; }
        public string password { get; set; }

    }

}