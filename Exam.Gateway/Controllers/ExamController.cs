using System;
using Microsoft.AspNetCore.Mvc;
using Exam.Contract.IOrchestration;
using Exam.Contract.Model;
using System.Collections.Generic;

namespace Exam.Gateway.Controllers

{
    [ApiController]
    [Route("api")]
    public class ExamController : ControllerBase
    {

        private IExamOrchestration _ExamOrchetration;
        public ExamController(IExamOrchestration ExamOrchestration)
        {
            _ExamOrchetration = ExamOrchestration;
        }

        

        [HttpPost]
        [Route("users")]
        public IActionResult GetUser(Logindetails logindetails)
        {

            return Ok(_ExamOrchetration.GetUser(logindetails));
        }

        [HttpGet]
        [Route("permissons")]
        public IActionResult GetPermisson()
        {
           
            List<Permission> permissionList = _ExamOrchetration.GetPermission();
            return Ok(permissionList);

        }

        [HttpPost]
        [Route("new-users")]
        public IActionResult CreateUser([FromBody] OwnerDetails newuser)
        {

          return Ok(_ExamOrchetration.CreateUser(newuser));  
        }



    }
}