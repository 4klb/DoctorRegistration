using DoctorRegistration.Data;
using DoctorRegistration.Models;
using System;

namespace DoctorRegistration.UI
{
    public class Visit
    {
        public void NewVisitor(Client client)
        {
            var clientDataAccess = new ClientDataAccess();
            clientDataAccess.Insert(client);
        }

        public void AvailableTime()
        {
            var clientDataAccesse = new ClientDataAccess();
            var result = clientDataAccesse.GetAvailableTime();

            Console.WriteLine("Доступные часы");
            foreach (var u in result)
            {
                Console.WriteLine(u.VisitTime);
            }
        }
        public void SetTime()
        {
            var clientDataAccess = new ClientDataAccess();
            Console.WriteLine("Введите время");
            var time = Console.ReadLine();
            clientDataAccess.SetVisitTime(time);
        }
    }
}
