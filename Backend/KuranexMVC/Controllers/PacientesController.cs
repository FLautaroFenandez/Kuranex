using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KuranexMVC.Data;
using KuranexMVC.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace KuranexMVC.Controllers
{
    public class PacientesController : Controller
    {
        private readonly KuranexDbContext _context;

        public PacientesController(KuranexDbContext context)
        {
            _context = context;
        }

        // GET: /Pacientes
        public async Task<IActionResult> Index()
        {
            // Traemos los pacientes, y le pedimos explícitamente a SQL que haga JOIN
            // con las tablas de Familiares y RegistrosSignosVitales
            var pacientes = await _context.Pacientes
                .Include(p => p.Familiar)
                .Include(p => p.RegistrosVitales)
                .ToListAsync();

            return View(pacientes);
        }

        // GET: /Pacientes/CargarDatosDePrueba
        public async Task<IActionResult> CargarDatosDePrueba()
        {
            if (!await _context.Familiares.AnyAsync())
            {
                // 1. Familiar
                var familiar = new Familiar { Nombre = "Juan", Apellido = "Giménez", Email = "juan.gimenez@mail.com" };

                // 2. Pacientes
                var paciente1 = new Paciente { Nombre = "Rosa", Apellido = "Giménez", Habitacion = "204B", DiagnosticoPrincipal = "Monitoreo post-operatorio", Familiar = familiar };
                var paciente2 = new Paciente { Nombre = "Carlos", Apellido = "Martínez", Habitacion = "102A", DiagnosticoPrincipal = "Control cardiovascular", Familiar = familiar };

                // 3. Registros de Signos Vitales (Relacionados a los pacientes)
                var registro1 = new RegistroSignoVital { FechaHora = DateTime.Now, FrecuenciaCardiaca = 82, SaturacionOxigeno = 96, Temperatura = 36.5m, Paciente = paciente1 };
                var registro2 = new RegistroSignoVital { FechaHora = DateTime.Now.AddHours(-2), FrecuenciaCardiaca = 80, SaturacionOxigeno = 97, Temperatura = 36.6m, Paciente = paciente1 };
                var registro3 = new RegistroSignoVital { FechaHora = DateTime.Now, FrecuenciaCardiaca = 90, SaturacionOxigeno = 94, Temperatura = 37.1m, Paciente = paciente2 };

                // 4. Agregamos y hacemos el Commit (Save)
                _context.Familiares.Add(familiar);
                _context.Pacientes.AddRange(paciente1, paciente2);
                _context.RegistrosSignosVitales.AddRange(registro1, registro2, registro3);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}