using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DataAccess.MSSQL.Entities;

namespace WebApi.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Sex).HasConversion<string>().HasMaxLength(10).IsRequired();


        }
    }
}
