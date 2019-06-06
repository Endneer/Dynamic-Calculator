using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EFGHermes.Calculator.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CalculatorService : ICalculatorService
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "ADMIN")]
        public double Divide(double x, double y)
        {
            return x / y;
        }

        public void Login()
        {

        }

        [PrincipalPermission(SecurityAction.Demand, Role = "ADMIN")]
        public double Multiply(double x, double y)
        {
            return x * y;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "ADMIN")]
        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Sum(double x, double y)
        {
            return x + y;
        }
    }
}
