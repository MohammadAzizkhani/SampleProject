using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EntityConfigurations;

namespace Repository
{
    public class AppContext : DbContext
    {
        public  DbSet<Book> Books { get; set; }
        public  DbSet<BookFile> BookFiles { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<BookBorrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=Library;uid=sa;pwd=12;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookFileConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
