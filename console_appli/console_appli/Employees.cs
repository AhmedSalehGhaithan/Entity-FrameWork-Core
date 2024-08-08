using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE
{
    public class Employees
    {
        public int Employee_id { get; set; }// auto incremant,primaty key
        public string Employee_name{ get; set; }//not null
        public decimal Employee_salary { get; set; }//(8,2)
        public string Employee_phone { get; set; }//(unique)

        public override string ToString()
        {
            return $"--------------------------------" +
                $"Employee Id : {Employee_id}\t" +
                $"Employee Name : {Employee_name}\n" +
                $"Employee Salary : {Employee_salary}\t" +
                $"Employee Phone : {Employee_phone}\n" +
                $"--------------------------------";
        }
    }
}
