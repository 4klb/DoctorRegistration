using DoctorRegistration.Data;
using DoctorRegistration.Models;
using DoctorRegistration.Services;
using DoctorRegistration.UI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DoctorRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConfiguration();

            var clientDataAccess = new ClientDataAccess();
            var visit = new Visit();

            var client = new Client()
            {
                FullName = "А.Н. Маратов",
                Phone = "87772156489",
                Address = "г.Нур-Султан, ул.Пушкина дом 2, кв. 80"
            };

            visit.NewVisitor(client);
            visit.AvailableTime();
            visit.SetTime();


        }

        private static void InitConfiguration()
        {
            ConfigurationService.Init();
        }
    }
}
