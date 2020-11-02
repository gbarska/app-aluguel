using System;
using Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
using Dominio.Usuarios;
using Dominio.Reservas;

namespace Infraestrutura.Data
{
    public static class DbContextExtensions
    {
        public static bool AllMigrationsApplied(this ApplicationContext context)
        {
            var applied = context.GetService<IHistoryRepository>().
                GetAppliedMigrations()
                .Select(s => s.MigrationId);
            var total = context.GetService<IMigrationsAssembly>().
                Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }

        public static void InitialSeed(this ApplicationContext context)
        {
            var nome = NomeUsuario.Criar("Gustavo", "Barska");
            var email = Email.Criar("gbarska@gbarska.tk");

            var usuario = new Usuario(nome.Value, email.Value);
            context.Usuarios.Add(usuario);

            nome = NomeUsuario.Criar("Uncle", "Bob");
            email = Email.Criar("bob@uncle.com");

            usuario = new Usuario(nome.Value, email.Value);
            context.Usuarios.Add(usuario);
            
            nome = NomeUsuario.Criar("Eric", "Evans");
            email = Email.Criar("eric@evans.com");
            
            usuario = new Usuario(nome.Value, email.Value);
            context.Usuarios.Add(usuario);


            var local = new Local("Pousada sta Marcelina","Uma pousada muito aconchegante no interior de São Paulo", "https://gbarska.tk/images/pousada.png", Endereco.Vazio);
            context.Locais.Add(local);

            local = new Local("Pousada Beija-Flor","Uma pousada  aconchegante no interior de São Paulo", "https://gbarska.tk/images/pousada.png", Endereco.Vazio);
            context.Locais.Add(local);
        }
    }
}