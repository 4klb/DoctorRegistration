using DoctorRegistration.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DoctorRegistration.Data
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;

        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("DoctorRegistrationProvider");

            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["dataAccessConnectionString"];
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
