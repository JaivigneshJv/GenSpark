using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlServerConnectionDemo.Model;

namespace SqlServerConnectionDemo
{
    internal class Program
    {
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            var connectionString = builder.GetConnectionString("testdb");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to SQL Server: " + ex.Message);
                }
            }
            Area area = new Area();
            area.Area1 = "POPO";
            area.Zipcode = "44332";
            testdbContext context = new testdbContext();
            context.Areas.Add(area);
            context.SaveChanges();
        }
    }
}
