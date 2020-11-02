using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Reservas;

namespace Infraestrutura.Data.Usuarios
{
    public class LocalMap: IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> entity)
        {
                entity.ToTable("Locais").HasKey(k => k.Id);
                entity.Property(p => p.Id).HasColumnName("LocalId");

                entity.HasMany(p => p.Avaliacoes)
                    .WithOne(p => p.Local)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                
                entity.OwnsOne( p => p.Endereco, p => {
                  p.Property(pp => pp.Logradouro).HasColumnName("Logradouro");
                  p.Property(pp => pp.Cidade).HasColumnName("Cidade");
                  p.Property(pp => pp.Numero).HasColumnName("Numero");
                  p.Property<Guid?>("UfId").HasColumnName("UfId");
                  p.HasOne(pp => pp.Uf).WithMany().HasForeignKey("UfId").IsRequired(false);
                });
         }
    }
}