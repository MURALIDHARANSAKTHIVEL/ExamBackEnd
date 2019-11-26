namespace Exam.Contract.Model
{

    public class GenderResponse
    {

public int Gid{get;set;}
public int Genderkey{get;set;}
public string Gendername{get;set;}


    }

public class Logindetails
{
public string username{get;set;}
public string password{get;set;}

}


public class Permission
{

public int pid{get;set;}
public int permissonkey{get;set;}

public string accessname{get;set;}

public int roleaccesskey{get;set;}

}


}