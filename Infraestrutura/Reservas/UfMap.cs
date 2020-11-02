using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Reservas;

namespace Infraestrutura.Data.Usuarios
{
    public class UfMap: IEntityTypeConfiguration<Uf>
    {
        public void Configure(EntityTypeBuilder<Uf> entity)
        {
               entity.ToTable("Estados").HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("UfId");
                entity.Property(p => p.Nome);
         }
    }
}