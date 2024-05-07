﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using CustomerWebAPI.Models;
namespace CustomerWebAPI
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
			try
			{
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();

                    }
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();

                    }
                }
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
                throw;
			}
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
