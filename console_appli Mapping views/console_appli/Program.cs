using console_appli;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE
{
    class Program
    {
        public static void Main(string[] args)
        {
            var orderBillDetails = new AppDBbContext().Set<OrderBill>()
                .FromSqlInterpolated($"Select * from GetOrderBill({1})").ToList();

            foreach(var items in orderBillDetails)
            {
                Console.WriteLine(items);
            }

        }

       
    }
}