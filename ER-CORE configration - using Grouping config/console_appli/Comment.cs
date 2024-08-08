
namespace EF_CORE_External_Configuration3
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TweetId { get; set; }
        public int USerId { get; set; }
        public string commentText { get; set; }
        public DateTime createdAt { get; set; }
        
    }
}


