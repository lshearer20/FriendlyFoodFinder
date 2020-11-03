using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/Family")]
    public class FamilyController : ApiController
    {
        string connectionString = "Server=tcp:friendly-food-finder.database.windows.net,1433;Initial Catalog=friendly-food-finder;Persist Security Info=False;User ID=Admin123;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("create/{name}/{userID}")] //Matches GET ComicBooks/Spiderman
        public string Get(string name, string userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdStr = "insert into Family(familyName) values ('" + name +
                                "'); SELECT SCOPE_IDENTITY() As NewID";
                var SqlCommand = new SqlCommand(cmdStr, connection);
                SqlDataReader reader = SqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string familyID = reader[0].ToString();
                    reader.Close();
                    cmdStr = "insert into userfamiles(familyId, userId) values ('" + familyID +
                                    "','"+userID+"')";
                    SqlCommand = new SqlCommand(cmdStr, connection);
                    SqlCommand.ExecuteNonQuery();

                    return familyID;
                }
                return null;
            }
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