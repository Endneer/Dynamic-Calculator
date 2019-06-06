using System.Collections.Generic;

namespace EFGHermes.Calculator.Service.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}