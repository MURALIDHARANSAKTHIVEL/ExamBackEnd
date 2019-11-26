using System;
using Microsoft.AspNetCore.Mvc;
using Exam.Contract.IOrchestration;
using Exam.Contract.Model;
using System.Collections.Generic;

namespace Exam.Gateway.Controllers

{
    [ApiController]
    [Route("api/exam")]
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
            Dictionary<Int64, string> d = new Dictionary<Int64, string>();
            List<Permission> c = _ExamOrchetration.GetPermission();

            foreach (Permission a in c)
            {

                d.Add(a.permissonkey, a.accessname);
            }
            return Ok(d);

        }




    }
}