using System.Collections.Generic;

namespace KuranexMVC.Models
{
    public class Familiar
    {
        public int Id { get; set; } // Primary Key
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        // Relación 1-N: Un familiar puede tener a cargo varios pacientes
        public List<Paciente> Pacientes { get; set; }

        public Familiar()
        {
            Pacientes = new List<Paciente>();
        }
    }
}