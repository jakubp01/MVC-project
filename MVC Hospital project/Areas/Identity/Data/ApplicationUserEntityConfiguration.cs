using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVC_Hospital_project.Areas.Identity.Data
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u=>u.Firstname).HasMaxLength(128);
            builder.Property(u=>u.Lastname).HasMaxLength(128);
        }
    }
}