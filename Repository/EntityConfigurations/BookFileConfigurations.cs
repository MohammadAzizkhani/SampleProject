using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityConfigurations
{
    public class BookFileConfigurations : IEntityTypeConfiguration<BookFile>
    {
        public void Configure(EntityTypeBuilder<BookFile> builder)
        {
            builder.HasOne<Book>()
                .WithOne(p => p.BookFile)
                .HasPrincipalKey<Book>(p => p.Id);
        }
    }
}
