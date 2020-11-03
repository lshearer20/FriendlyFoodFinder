using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        string connectionString = "Server=tcp:friendly-food-finder.database.windows.net,1433;Initial Catalog=friendly-food-finder;Persist Security Info=False;User ID=Admin123;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("create/{name}")] //Matches GET ComicBooks/Spiderman
        public string createUser(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdStr = "insert into Person(personName) values ('" + name +
                                "'); SELECT SCOPE_IDENTITY() As NewID";
                var SqlCommand = new SqlCommand(cmdStr, connection);
                SqlDataReader reader = SqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    cmdStr = "insert into Users(personId) values ('" + reader[0].ToString() + "'); SELECT SCOPE_IDENTITY() As NewID";
                    SqlCommand = new SqlCommand(cmdStr, connection);
                    reader.Close();
                    reader = SqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader[0].ToString();
                    }
                }
                else
                    return null;
            }
            return null;
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}