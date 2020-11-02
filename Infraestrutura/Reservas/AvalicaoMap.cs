using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Reservas;
using Dominio.Usuarios;

namespace Infraestrutura.Data.Usuarios
{
    public class AvaliacaoMap: IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> entity)
        {
                entity.ToTable("Avaliacoes").HasKey(k => k.Id);
                entity.Property(p => p.Id).HasColumnName("AvaliacaoId");

                entity.HasOne(p => p.Usuario).WithMany();
              
                entity.Property(p => p.Nota)
                    .HasConversion(p => p.Value, p => Nota.Criar(p).Value);
         }
    }
}