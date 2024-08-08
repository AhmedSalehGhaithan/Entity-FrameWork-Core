using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlTypes;

namespace EF_CORE
{
    class Program
    {
        public static void Main(string[] args)
        {

            Query_data();

            Console.ReadKey();
        }

        static void Retrieve_All_Data()
        {
            using (var context = new AppDBbContext())
            {
                foreach (var wallets in context.Wallets)
                {
                    Console.WriteLine(wallets);
                }
            }
        }

        static void Retrieve_single_item()
        {
            Console.WriteLine("Enter the id :");
            int tempId = int.Parse(Console.ReadLine());

            using (var context = new AppDBbContext())
            {
                var wallet = context.Wallets.FirstOrDefault(x => x.Id == tempId);
                Console.WriteLine(wallet);
            }
        }

        static void Insert_data()
        {
            var wallet = new Wallets
            {
                Id = 7,
                Holder = "Osam",
                Balance = 1200.01m
            };

            using (var context = new AppDBbContext())
            {
                context.Add(wallet);
                context.SaveChanges();
                Console.WriteLine("One record added");
            }
        }

        static void Update_Data()
        {
            Console.WriteLine("Enter the id :");
            int tempId = int.Parse(Console.ReadLine());

            using (var context = new AppDBbContext())
            {
                var wallet = context.Wallets.Single(x=> x.Id == tempId);
                wallet.Holder = "Mustafa";
                context.SaveChanges();
                Console.WriteLine("One Record updated");
            }
        }

        static void Delete_data()
        {
            Console.WriteLine("Enter the id :");
            int tempId = int.Parse(Console.ReadLine());

            using (var context = new AppDBbContext())
            {
                var wallet = context.Wallets.FirstOrDefault(x => x.Id == tempId);
                context.Wallets.Remove(wallet);
                context.SaveChanges();
                Console.WriteLine("one Record deleted");
            }
        }

        static void Query_data()
        {

            using (var context = new AppDBbContext())
            {
                //retrive a wallet with specified condition
                var result = context.Wallets.Where(x => x.Balance > 100 && x.Balance < 400);
                foreach (var wallet in result)
                {
                    Console.WriteLine(wallet);
                }
            }
        }

        static void Implement_Transaction()
        {
            using (var context = new AppDBbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    // transfere 100 from wallet id = 3 to wallet id =2
                    var fromWallet = context.Wallets.Single(x => x.Id == 3);
                    var toWallet = context.Wallets.Single(x => x.Id == 2);

                    var amountToTransfer = 100m;

                    fromWallet.Balance -= amountToTransfer;
                    context.SaveChanges();

                    toWallet.Balance += amountToTransfer;
                    context.SaveChanges();

                    transaction.Commit();
                }
            }
        }
    }
}