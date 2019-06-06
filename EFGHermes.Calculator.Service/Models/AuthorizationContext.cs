namespace EFGHermes.Calculator.Service.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AuthorizationContext : DbContext
    {
        public AuthorizationContext()
            : base("name=AuthorizationContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}