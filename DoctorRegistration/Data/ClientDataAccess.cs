using DoctorRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DoctorRegistration.Data
{
    public class ClientDataAccess : DbDataAccess<Client>
    {
        public void Insert(Client client)
        {
            string insertSqlScript = "insert into Users values (@Id,@FullName, @Phone,@Email)";

            using (var transaction = connection.BeginTransaction())
            {
                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = insertSqlScript;

                    try
                    {
                        command.Transaction = transaction;

                        var idParameter = factory.CreateParameter();
                        idParameter.DbType = System.Data.DbType.Guid;
                        idParameter.Value = client.Id;
                        idParameter.ParameterName = "Id";
                        command.Parameters.Add(idParameter);

                        var fullNameParameter = factory.CreateParameter();
                        fullNameParameter.DbType = System.Data.DbType.String;
                        fullNameParameter.Value = client.FullName;
                        fullNameParameter.ParameterName = "FullName";
                        command.Parameters.Add(fullNameParameter);

                        var phoneParameter = factory.CreateParameter();
                        phoneParameter.DbType = System.Data.DbType.String;
                        phoneParameter.Value = client.Phone;
                        phoneParameter.ParameterName = "Phone";
                        command.Parameters.Add(phoneParameter);

                        var addressParameter = factory.CreateParameter();
                        addressParameter.DbType = System.Data.DbType.String;
                        addressParameter.Value = client.Address;
                        addressParameter.ParameterName = "Address";
                        command.Parameters.Add(addressParameter);

                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (DbException)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public ICollection<Schedule> GetAvailableTime()
        {
            string selectSqlScript = "SELECT * FROM Schedule WHERE IsAvailable = 'true'";

            var schedule = new List<Schedule>();

            using (var command = factory.CreateCommand())
            {
                command.CommandText = selectSqlScript;
                command.Connection = connection;

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        schedule.Add(new Schedule
                        {
                            Id = Guid.Parse(dataReader["Id"].ToString()),
                            VisitTime = DateTime.Parse(dataReader["VisitTime"].ToString()),
                            IsAvailable = Convert.ToBoolean(dataReader["IsAvailable"].ToString())
                        });
                    }
                }

                return schedule;
            }
        }

        public void SetVisitTime(string time)
        {
            string updateSqlScript = $"UPDATE Schedule SET IsAvailable = 'false' WHERE VisitTime = '{time}'";


            using (var command = factory.CreateCommand())
            {
                command.CommandText = updateSqlScript;
                command.Connection = connection;

                command.ExecuteNonQuery();
            }
        }
    }
}
