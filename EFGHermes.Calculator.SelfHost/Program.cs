using EFGHermes.Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EFGHermes.Calculator.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
                host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomUserNameValidator();
                host.Open();
                if (host.State == CommunicationState.Opened)
                {
                    foreach (var end in host.Description.Endpoints)
                        Console.WriteLine(end.ListenUri);
                    Console.WriteLine("Press Enter to exit");
                    Console.ReadLine();
                    host.Close();
                }
            }
        }
    }
}
