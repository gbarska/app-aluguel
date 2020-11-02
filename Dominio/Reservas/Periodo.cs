using System.Runtime.CompilerServices;
using System;
using System.Diagnostics.CodeAnalysis;
using Dominio.Core;
using System.Collections.Generic;

namespace Dominio.Reservas
{
    public class Periodo : ValueObject, IComparable<Periodo>
    {
        public DateTime Inicio { get; }
        public DateTime Fim { get; }

        public Periodo(DateTime inicio, DateTime fim)
        {

            Inicio = inicio;
            Fim = fim;
        }

        public Periodo(DateTime inicio, int dias) : this(inicio, inicio.AddDays(dias))
        {
        }
        
        protected Periodo()
        {
        }

        public int DuracaoEmMinutos()
        {
            return (Fim - Inicio).Minutes;
        }

        public Periodo NovoFim(DateTime novoFim)
        {
            return new Periodo(this.Inicio, novoFim);
        }
        public Periodo NovaDuracao(int dias)
        {
            return new Periodo(this.Inicio, dias);
        }
        public Periodo NovoInicio(DateTime novoInicio)
        {
            return new Periodo(novoInicio, this.Fim);
        }

        public static Periodo CriarPeriodoUmDia(DateTime dia)
        {
            return new Periodo(dia, dia.AddDays(1));
        }

        public static Periodo CriarPeriodoUmaSemana(DateTime diaInicio)
        {
            return new Periodo(diaInicio, diaInicio.AddDays(7));
        }

        public bool Sobrepoem(Periodo periodo)
        {
            return this.Inicio < periodo.Fim && 
                this.Fim > periodo.Inicio;
        }
        public int CompareTo([AllowNull] Periodo outro)
        {
                if (this < outro) return -1;
                if (this == outro) return 0;
                return 1;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Inicio;
            yield return Fim;
        }
        public static bool operator <(Periodo obj, Periodo obj2) => obj.Inicio < obj2.Inicio;
        public static bool operator >(Periodo obj, Periodo obj2) => obj.Inicio > obj2.Inicio;
        
    }
}
