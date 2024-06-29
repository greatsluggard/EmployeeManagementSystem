using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageService.Models;

namespace StorageService.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.DepartmentId).ValueGeneratedOnAdd();
            builder.Property(x => x.DepartmentName).IsRequired().HasMaxLength(100);

            builder.HasMany<Employee>(x => x.Employees)
                   .WithOne(x => x.Department)
                   .HasForeignKey(x => x.DepartmentId);
        }
    }
}