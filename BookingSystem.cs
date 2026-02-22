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


        public void ShowAllPatientsWithIndex()
        {
    

            for (int i = patients.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < 1; j++) // Imprime el mensaje varias veces para mayor impacto visual
                {
                    Console.WriteLine($"Clearing booking index {i}: {patients[i].FullName}  {j + 1})");
                }
                // Console.WriteLine($"Clearing booking for: {patients[i].FullName} | Date: {patients[i].AppointmentDate}");  
                // patients.RemoveAt(i);
            }
            Console.WriteLine("Which one do you want to delete? Enter the index:");
            int index;
            
            if (!int.TryParse(Console.ReadLine() ?? string.Empty, out index) || index < 0 || index >= patients.Count)
            {
                Console.WriteLine("Invalid index. Operation cancelled.");
                return;
            }
            // sumando u
            index = +1;
            var removed = patients[index];
            patients.RemoveAt(index);

            Console.WriteLine($"Removed booking index {index}: {removed.FullName}");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients left.");
                return;
            }

            Console.WriteLine("Remaining patients with indices:");
            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine($"{i}: {patients[i].FullName}");
            }
        }

        
    }
}


