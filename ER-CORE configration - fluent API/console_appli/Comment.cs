using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_External_Configuration
{
    public class Comment
    {
        public int Id { get; set; }
        public int TweetId { get; set; }
        public int USerId { get; set; }
        public string commentText { get; set; }
        public DateTime createdAt { get; set; }
        
    }
}


