using System;
namespace Exam.Contract.Model
{

    public class OwnerDetails
    {

        public Int64 UserKey { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Employee_Id { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int roleKey { get; set; }
        public string permission { get; set; }
         public int Genderkey { get; set; }
        public byte[] displaypicture { get; set; }
        public int CreatedBy { get; set; }
        public string password { get; set; }

    }

}