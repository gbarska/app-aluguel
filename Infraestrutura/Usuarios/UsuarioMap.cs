using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Usuarios;

namespace Infraestrutura.Data.Usuarios
{
    public class UsuarioMap: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
                entity.ToTable("Usuarios").HasKey(k => k.Id);
                entity.Property(p => p.Id).HasColumnName("UsuarioId");

                entity.OwnsOne( p => p.Nome, p => {
                    p.Property(pp => pp.Nome).HasColumnName("Nome");
                    p.Property(pp => pp.Sobrenome).HasColumnName("Sobrenome");
                });

                entity.Property(p => p.Email)
                    .HasConversion(p => p.Value, p => Email.Criar(p).Value);
                
               

                  entity.HasMany(p => p.Reservas).WithOne(p => p.Usuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                
                  entity.HasMany(p => p.Locais).WithOne()
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
         }
    }
}