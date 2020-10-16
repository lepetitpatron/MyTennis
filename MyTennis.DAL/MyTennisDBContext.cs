using Microsoft.EntityFrameworkCore;

namespace MyTennis.DAL
{
    class MyTennisDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS; initial catalog=MyTennis; integrated security=True;");
        }
    }
}
