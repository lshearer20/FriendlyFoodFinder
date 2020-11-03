using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Person()
        {

        }

        public Person(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }
    }
}