
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
                foreach(var user in context.Users)
                {
                    Console.WriteLine(user.userName);
                }

                Console.WriteLine();
                Console.WriteLine("--------------- Tweets -------------------");
                Console.WriteLine();

                foreach (var user in context.Tweets)
                {
                    Console.WriteLine(user.tweetText);
                }

                Console.WriteLine();
                Console.WriteLine("--------------- comments -------------------");
                Console.WriteLine();

                foreach (var user in context.Comments)
                {
                    Console.WriteLine(user.commentText);
                }

            }




            Console.ReadKey();
        }
    }
}