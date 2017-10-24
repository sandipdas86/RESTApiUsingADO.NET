using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Web.Script.Serialization;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET /api/employees
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString.ToString()))
                {
                    List<Employee> pm = new List<Employee>();

                    var p = new DynamicParameters();

                    var data = cnn.QueryMultiple("[dbo].[GetEmployees_SP]", p, commandType: CommandType.StoredProcedure);

                    pm = data.Read<Employee>().ToList();

                    var json = new JavaScriptSerializer().Serialize(pm);

                    response = Request.CreateResponse(HttpStatusCode.OK, json.ToString());
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        // POST /api/employees/obj
        public HttpResponseMessage Post([FromBody]Employee obj)
        {
            HttpResponseMessage response;
            try
            {
                using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString.ToString()))
                {
                    var p = new DynamicParameters();

                    p.Add("@Name", obj.Name);
                    p.Add("@City", obj.City);
                    p.Add("@Address", obj.Address);

                    var data = cnn.Execute("[dbo].[AddNewEmpDetails_SP]", p, commandType: CommandType.StoredProcedure);

                    response = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        //PUT /api/values/1
        public HttpResponseMessage Put(string Id, [FromBody]Employee obj)
        {
            HttpResponseMessage response;
            try
            {
                using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString.ToString()))
                {
                    var p = new DynamicParameters();

                    p.Add("@EmpId", Id);
                    p.Add("@Name", obj.Name);
                    p.Add("@City", obj.City);
                    p.Add("@Address", obj.Address);

                    var data = cnn.Execute("[dbo].[UpdateEmpDetails_SP]", p, commandType: CommandType.StoredProcedure);

                    response = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        //DELETE /api/values/2
        public HttpResponseMessage Delete(string Id)
        {
            HttpResponseMessage response;
            try
            {
                using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString.ToString()))
                {
                    var p = new DynamicParameters();

                    p.Add("@EmpId", Id);

                    var data = cnn.Execute("[dbo].[DeleteEmpById_SP]", p, commandType: CommandType.StoredProcedure);

                    response = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }    
}
