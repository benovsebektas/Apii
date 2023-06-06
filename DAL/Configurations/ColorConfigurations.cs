using FirstApiProject.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FirstApiProject.DAL.Configurations 
{
    public class ColorConfigurations : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.Property(b => b.Name)
            .IsRequired()
            .HasColumnType(SqlDbType.NVarChar.ToString());


    }
}
}
