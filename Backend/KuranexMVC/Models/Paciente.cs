using System.Collections.Generic;

namespace KuranexMVC.Models
{
    public class Paciente
    {
        public int Id { get; set; } // Primary Key
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Habitacion { get; set; }
        public string DiagnosticoPrincipal { get; set; }

        // Clave foránea que lo conecta con Familiar
        public int FamiliarId { get; set; }
        public Familiar Familiar { get; set; } // Propiedad de navegación

        // Relación 1-N: Un paciente tiene muchos registros de signos vitales
        public List<RegistroSignoVital> RegistrosVitales { get; set; }

        public Paciente()
        {
            RegistrosVitales = new List<RegistroSignoVital>();
        }
    }
}