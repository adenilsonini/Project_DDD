using JSP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSP_Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.UserName)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("varchar(250)");

            builder.Property(prop => prop.Password)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("varchar(100)");


            builder.Property(prop => prop.Email)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(250)");

            builder.Property(prop => prop.Ativo)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("bit");

            builder.Property(prop => prop.datacad)
               .HasConversion(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Data_cadastro")
               .HasColumnType("DateTime");
        }
    }
}
