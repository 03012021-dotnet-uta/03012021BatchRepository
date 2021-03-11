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
                List<Customer> customers = dbContext.Customers.Include(d => d.Address).ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"The customers name is {c.FirstName} {c.LastName}\n\tand his/her address is{c.AddressId}.");

                }

            }


        }
    }
}
