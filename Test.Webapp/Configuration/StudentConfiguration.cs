using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Webapp.Models;

namespace Test.Webapp.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        builder.HasKey(t => t.Id);
        builder.Property(t=> t.Name).HasMaxLength(50).IsRequired();
        builder.Property(t=> t.Email).HasMaxLength(50).IsRequired();
        builder.Property(t=> t.Phone).HasMaxLength(50).IsRequired();
        builder.Property(t=> t.Address).HasMaxLength(150).IsRequired();
        builder.Property(t=> t.RegistrationId).HasMaxLength(50).IsRequired();
    }
}
