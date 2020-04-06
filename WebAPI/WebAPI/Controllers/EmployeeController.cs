using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select id, name, department,mail,convert(varchar(10),doj,120) as doj from dbo.Employees";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }


            return Request.CreateResponse(System.Net.HttpStatusCode.OK, table);
        }

        [HttpPost]
        public string Post(Employee emp)
        {
            try
            {

                DataTable table = new DataTable();
                string query = @"insert into dbo.Employees values 
                                ('" + emp.Name + "','"
                                    + emp.Department + "','"
                                    + emp.Mail + "','"
                                    + emp.Doj + "')"; 




                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Add OK";
            }
            catch (System.Exception)
            {

                return "Error";
            }
        }


        [HttpPut]
        public string Put(Employee emp)
        {
            try
            {

                DataTable table = new DataTable();
                string query = @"update dbo.employees 
                                set Name = '" + emp.Name + "'" + 
                                " where id = " + emp.Id.ToString();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Update OK";
            }
            catch (System.Exception)
            {

                return "Error";
            }
        }

        [HttpDelete]
        public string Delete(int id)
        {
            try
            {

                DataTable table = new DataTable();
                string query = @"delete dbo.employees where id = " + id.ToString();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Deleted OK";
            }
            catch (System.Exception)
            {

                return "Error";
            }
        }

    }
}
