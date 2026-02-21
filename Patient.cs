using System;

namespace RegentHealthBookingSystem
{
    class Patient
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        
        // Estas se inicializan como "" para evitar el warning CS8618
        public string AppointmentType { get; private set; } = ""; 
        public double AppointmentPrice { get; private set; }
        
        // AQUÍ ESTÁ EL ERROR: Faltaba declarar esta propiedad
        public string AppointmentDate { get; private set; } = "";

        public Patient(string name)
        {
            FullName = name;
            Email = name.Replace(" ", "").ToLower() + "@regenthealth.com";
        }

        public void SetAppointment(int option)
        {
            switch (option)
            {
                case 1: AppointmentType = "General Consultation"; AppointmentPrice = 35; break;
                case 2: AppointmentType = "Nurse Check-up"; AppointmentPrice = 20; break;
                case 3: AppointmentType = "Blood Test"; AppointmentPrice = 15; break;
                case 4: AppointmentType = "Specialist Consultation"; AppointmentPrice = 60; break;
                default: AppointmentType = "Standard"; AppointmentPrice = 0; break;
            }

            Console.Write("Enter date (yyyy-mm-dd): ");
            // Guardamos lo que el usuario escribe en la propiedad que acabamos de crear
            AppointmentDate = Console.ReadLine() ?? "Not set";
        }
    }
}