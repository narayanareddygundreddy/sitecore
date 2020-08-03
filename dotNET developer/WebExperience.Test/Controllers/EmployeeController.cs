using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<Employee> employeeList = new List<Employee>();
            using (TestDBEntities dbEntities = new TestDBEntities())
            {
                employeeList = dbEntities.Employees.ToList();
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, employeeList);
                return response;
            }
        }
    }
}
