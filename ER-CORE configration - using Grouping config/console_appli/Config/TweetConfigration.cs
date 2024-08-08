using EF_CORE_External_Configuration3;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_External_Configuration3
{
    public class TweetConfigration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable("Tweets");
        }
    }
}
