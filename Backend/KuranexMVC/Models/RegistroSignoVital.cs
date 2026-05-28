using System;
using System.ComponentModel.DataAnnotations.Schema; // Agregamos esta librería

namespace KuranexMVC.Models
{
    public class RegistroSignoVital
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public int SaturacionOxigeno { get; set; }

        // Le decimos a SQL Server que reserve espacio para 5 dígitos en total, 2 de ellos decimales (ej: 036.50)
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Temperatura { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}