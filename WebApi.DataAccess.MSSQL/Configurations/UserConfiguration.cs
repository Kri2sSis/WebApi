using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.MSSQL.Entities;

namespace WebApi.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);


            builder.Property(x => x.UserId).HasMaxLength(100);
            builder.Property(x => x.UserFullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Sex).HasMaxLength(10).IsRequired();


        }
    }
}
