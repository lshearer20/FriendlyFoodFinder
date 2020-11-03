using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class NutritionController : ApiController
    {
        string connectionString = "Server=tcp:friendly-food-finder.database.windows.net,1433;Initial Catalog=friendly-food-finder;Persist Security Info=False;User ID=Admin123;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdStr = "Select ingredients, itemName from Nutrition where upc = '" + id + "'";
                var SqlCommand = new SqlCommand(cmdStr, connection);
                SqlDataReader reader = SqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    return reader[0].ToString() + "|" + reader[1].ToString();
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