using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<Employee> employeeList = new List<Employee>();
            using (TestDBEntities dbEntities =new TestDBEntities())
            {
                employeeList = dbEntities.Employees.ToList();
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, employeeList);
                return response;
            }   
        }
        [HttpPost]
        public string Insert(Employee emp)
        {
            string message = string.Empty;
            try
            {
                using (TestDBEntities dBEntities = new TestDBEntities())
                {
                    dBEntities.Employees.Add(emp);
                    dBEntities.SaveChanges();
                    if (emp.Id > 0)
                    {
                        message = "Saved successfully";
                    }
                    else
                    {
                        message = "Not Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Error message:" + ex.Message;
            }
            return message;
        }
        [HttpPut]
        public string Update(Employee emp)
        {
            string message = string.Empty;
            try
            {
                using (TestDBEntities dBEntities = new TestDBEntities())
                {
                    Employee empUpdated = dBEntities.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
                    if (empUpdated != null)
                    {
                        empUpdated.Name =emp.Name;
                        empUpdated.Position =emp.Position;
                        dBEntities.SaveChanges();
                        message = "Updated Successfully";
                    }
                    else
                    {
                        message = "Not Updated";
                    }                
                }
            }
            catch (Exception ex)
            {
                message = "Error message:" + ex.Message;
            }
            return message;
        }
        [HttpDelete]
        public string Delete(Employee emp)
        {
            string message = string.Empty;
            try
            {
                using (TestDBEntities dBEntities = new TestDBEntities())
                {
                    Employee empUpdated = dBEntities.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
                    if (empUpdated != null)
                    {
                        dBEntities.Employees.Remove(empUpdated);
                        dBEntities.SaveChanges();
                        message = "Deleted Successfully";
                    }
                    else
                    {
                        message = "Not Deleted";
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Error message:" + ex.Message;
            }
            return message;
        }

    }
}
