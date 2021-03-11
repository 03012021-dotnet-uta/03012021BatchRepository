using System;
using System.Collections.Generic;
using System.Linq;
using DbFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var dbContext = new Sample_DBTestContext())
            {
                // List<Customer> customers = dbContext.Customers.Include("Address").ToList();
                List<Customer> customers = dbContext.Customers.Include(a => a.Address).ToList();
                Customer cust = dbContext.Customers.Where(c => c.FirstName == "Mark").FirstOrDefault();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"The customers name is {c.FirstName} {c.LastName}\n\tand his/her address is {c.Address.AddressLine1}.");
                }

                Console.WriteLine($"{cust.FirstName} {cust.LastName} is {cust.Remarks}.");

                Customer c1 = new Customer()
                {
                    FirstName = "Jimmy",
                    LastName = "McFlunilew",
                    AddressId = 3,
                    LastOrderDate = DateTime.Now,
                    Remarks = "made by Jerry"
                };
                dbContext.Customers.Add(c1);
                dbContext.SaveChanges();

                Customer c2 = dbContext.Customers.Where(x => x.FirstName == "Jimmy").FirstOrDefault();
                Console.WriteLine($" The new customer is {c2.FirstName} {c2.LastName}.");

                dbContext.Remove(dbContext.Customers.Where(x => x.FirstName == "Jerry").FirstOrDefault());
                dbContext.SaveChanges();

            }


        }
    }
}
