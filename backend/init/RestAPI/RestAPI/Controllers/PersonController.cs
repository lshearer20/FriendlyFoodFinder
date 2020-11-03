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
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        string connectionString = "Server=tcp:friendly-food-finder.database.windows.net,1433;Initial Catalog=friendly-food-finder;Persist Security Info=False;User ID=Admin123;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //api/Person/getpeopleinfamily/familyId
        [HttpGet]
        [Route("{getpeopleinfamily}")]
        public List<Person> ShowComicBook(int getpeopleinfamily)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdStr = "select personId, personName from Person where personId in (select personId from familypersons where familyId = '"+ getpeopleinfamily.ToString() + "');";
                var SqlCommand = new SqlCommand(cmdStr, connection);
                SqlDataReader reader = SqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    List<Person> people = new List<Person>();
                    while (reader.Read())
                    {
                        people.Add(new Person(reader[0].ToString(), Convert.ToInt32(reader[1].ToString())));
                    }

                    return people;
                }
                else
                    return null;
            }
            return null;
        }

        [HttpGet]
        [Route("addtofamily/{familyID}/{personID}")]
        public void ShowComicBook(string familyID, string personID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string cmdStr = "insert into familypersons(personID,familyID) values ('" + personID + "','" + familyID + "')";
                    var SqlCommand = new SqlCommand(cmdStr, connection);
                    SqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                }
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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