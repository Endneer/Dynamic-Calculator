using EFGHermes.Calculator.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace EFGHermes.Calculator.Service
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        AuthorizationContext _context;
        public CustomUserNameValidator()
        {
            _context = new AuthorizationContext();
        }
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            // TODO: Read users from database
            if (!_context.Users.Any(u => u.Name == userName && u.Password == password))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
                // When you do not want to throw an infomative fault to the client,
                // throw the following exception.
                // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }
        }
    }
}