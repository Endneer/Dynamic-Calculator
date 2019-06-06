using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFGHermes.Calculator.Service.Models
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        // TODO: implement hashing techniques
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}