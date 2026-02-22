using System;
using System.Collections.Generic; 
using System.Linq;

namespace RegentHealthBookingSystem
{
    class BookingSystem
    {
        // Esta es nuestra "base de datos" dinámica
        private List<Patient> patients = new List<Patient>(); 

        public void CreatePatient(string name)
        {
            // ERROR SOLUCIONADO: 
            // 1. Creamos una única instancia
            Patient newPatient = new Patient(name); 
            
            // 2. LA AÑADIMOS A LA LISTA (Esto es lo que te faltaba)
            patients.Add(newPatient); 
            
            Console.WriteLine("System: Patient added to the list. Total: " + patients.Count);
        }

        // Para el flujo de "añadir cita" justo después de crear el paciente
        public Patient GetCurrentPatient()
        {
            // Devolvemos el último de la lista para que el Program.cs trabaje con él
            return patients.LastOrDefault(); 
        }

        // NUEVO MÉTODO: Para que el Case 3 pueda ver a TODOS
        public List<Patient> GetAllPatients()
        {
            // OrderByDescending organiza de mayor a menor basándose en la propiedad que elijas
            return patients.OrderByDescending(p => p.AppointmentPrice).ToList();
        }                       
    }
}