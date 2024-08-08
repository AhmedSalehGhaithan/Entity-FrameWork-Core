using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_External_Configuration
{
    public class User
    {
        public int UserId { get; set; }
        public string userName { get; set; }

    }
}
