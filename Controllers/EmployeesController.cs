using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        [ActionName("GetEmployeeById")]
        public HttpResponseMessage Get(int id)
        {                
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString.ToString());
                    SqlCommand cmd = new SqlCommand("select * from TblRegister where Id=" + id, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Employee emp = null;
                    while (dr.Read())
                    {
                        emp = new Employee();
                        emp.Id = Convert.ToInt32(dr.GetValue(0));
                        emp.Name = dr.GetValue(1).ToString();
                    }
                    if (emp != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, emp);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found");
                    }
                }
        }
    }    
}
