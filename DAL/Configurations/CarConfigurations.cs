using FirstApiProject.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FirstApiProject.DAL.Configurations  
{
    public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(b => b.Description)
            .IsRequired()
            .HasColumnType(SqlDbType.NVarChar.ToString());



    }
}
}
