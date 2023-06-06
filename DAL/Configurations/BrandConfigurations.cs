using FirstApiProject.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FirstApiProject.DAL.Configurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.NVarChar.ToString());

            //builder.HasMany(b => b.Products)
            //    .WithMany(p => p.Brands);


        }
    }
}
