﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlTypes;

namespace EF_CORE_External_Configuration
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDBbContext())
            {
                Console.WriteLine("--------------- Users -------------------");
                Console.WriteLine();
                foreach(var user in context.User)
                {
                    Console.WriteLine(user.userName);
                }

                Console.WriteLine();
                Console.WriteLine("--------------- Tweets -------------------");
                Console.WriteLine();

                foreach (var user in context.Tweet)
                {
                    Console.WriteLine(user.TheTextOfTweet);
                }

                Console.WriteLine();
                Console.WriteLine("--------------- comments -------------------");
                Console.WriteLine();

                foreach (var user in context.Comment)
                {
                    Console.WriteLine(user.commentText);
                }

            }




            Console.ReadKey();
        }
    }
}