using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Reservas;

namespace Infraestrutura.Data.Usuarios
{
    public class ReservaMap: IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> entity)
        {
                entity.ToTable("Reservas").HasKey(k => k.Id);
                entity.Property(p => p.Id).HasColumnName("ReservaId");

                entity.OwnsOne( p => p.Periodo, p => {
                    p.Property(pp => pp.Inicio).HasColumnName("Inicio");
                    p.Property(pp => pp.Fim).HasColumnName("Fim");
                });
         }
    }
}