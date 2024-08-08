using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_External_Configuration
{
    public class Wallets
    {
        public int Id { get; set; }
        public string? Holder { get; set; }
        public decimal Balance{ get; set; }

        public void dis()
        {
            Console.WriteLine("id = : "+Id);
        }

        public override string ToString()
        {
            return $"Id :  {this.Id}\t name : {Holder}\t Balance : {Balance}";
        }

    }
}
