using Microsoft.EntityFrameworkCore;
using Test.Webapp.ViewModel;

namespace Test.Webapp.DatabaseContext;

public class StudentDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
    }

public DbSet<Test.Webapp.ViewModel.StudentVm> StudentVm { get; set; }
}
