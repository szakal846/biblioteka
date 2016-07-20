using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Usr
    {


        public class User
        {
            private string Name { get; set; }
            private string LastName { get; set; }
            public int Id { get; set; }


            public User() { }

            

            public User(string name, int id, string lastName)
            {
                this.Name = name;
                this.Id = id;
                this.LastName = lastName;
            }

        }
    }
}