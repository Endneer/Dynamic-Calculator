using EFGHermes.Calculator.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Data.Entity;

namespace EFGHermes.Calculator.Service
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity _identity;

        public IIdentity Identity { get => _identity; set => _identity = value; }

        private string[] _roles;

        AuthorizationContext _context;
        public CustomPrincipal()
        {
            _context = new AuthorizationContext();
        }
        public CustomPrincipal(IIdentity identity) : this()
        {
            this._identity = identity;
        }

        public bool IsInRole(string role)
        {
            EnsureRoles();

            return _roles.Contains(role);
        }

        // TODO: read Role of user from database
        protected virtual void EnsureRoles()
        {
            _roles = _context.Users.Include(t => t.Roles)
                .FirstOrDefault(u => u.Name == _identity.Name)
                .Roles.Select(r => r.Name).ToArray();
        }
    }
}