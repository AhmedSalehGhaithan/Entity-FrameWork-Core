using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlTypes;

namespace EF_CORE
{
    class Program
    {
        public static void Main(string[] args)
        {
            var context = new AppDBbContext();

            foreach(var items in context.orderWithDetails)
            {
                Console.WriteLine(items);
            }

        }

       
    }
}