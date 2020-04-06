using System.Web.Http;
using WebAPI.Models;
using System.Data;
using System.Net.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select id, name from dbo.departments";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                    using(var da = new SqlDataAdapter(cmd))
                    {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                    }


            return Request.CreateResponse(System.Net.HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {

                DataTable table = new DataTable();
                string query = @"insert into dbo.departments values ('" + dep.Name + "')";

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


        public string Put(Department dep)
        {
            try
            {

                DataTable table = new DataTable();
                string query = @"update dbo.departments set Name = '" + dep.Name + "' where id = " + dep.Id.ToString();

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


        public string Delete(int id)
        {
            try
            {

                DataTable table = new DataTable();
                string query = @"delete dbo.departments where id = " + id.ToString();

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
