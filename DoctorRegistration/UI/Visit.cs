using DoctorRegistration.Data;
using DoctorRegistration.Models;
using System;
using System.Collections.Generic;

namespace DoctorRegistration.UI
{
    public class Visit
    {
        public void NewVisitor(Client client)
        {
            var clientDataAccess = new ClientDataAccess();
            clientDataAccess.Insert(client);
        }

        public ICollection<Schedule> AvailableTime()
        {
            var clientDataAccesse = new ClientDataAccess();
            var result = clientDataAccesse.GetAvailableTime();

            return result;
        }
        public string GetTime()
        {
            Console.WriteLine("Введите время");
            var time = Console.ReadLine();
            return time;
        }
        public void SetTime()
        {
            var clientDataAccess = new ClientDataAccess();
            var registrationDataAccess = new RegistrationDataAccess();
            var listOfAvailableTime = new List<string>();

            var result = AvailableTime();

            Console.WriteLine("Доступные часы");
            foreach (var value in result)
            {
                listOfAvailableTime.Add(value.VisitTime.ToString());
                Console.WriteLine(value.VisitTime);
            }
         
            var time = GetTime();

            foreach (var value in listOfAvailableTime)
            {
                if (value.Contains(time))
                {
                    clientDataAccess.SetVisitTime(time);
                    registrationDataAccess.SetRegistration(time);
                    Console.WriteLine($"Вы записаны на {time}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Введенное Вами время не найдено");
                    break;
                }
            }
        }
    }
}
