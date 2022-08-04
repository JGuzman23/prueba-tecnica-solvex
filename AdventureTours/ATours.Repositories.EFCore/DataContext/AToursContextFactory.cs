using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ATours.Repositories.EFCore.DataContext
{
    class AToursContextFactory : IDesignTimeDbContextFactory<AToursContext>
    {
        public AToursContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
                new DbContextOptionsBuilder<AToursContext>();
            OptionBuilder.UseSqlServer(
                @"Data Source=.;Initial Catalog=ATours;Integrated Security=True");
            return new AToursContext(OptionBuilder.Options);
        }
    }
}
