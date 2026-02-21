using System;

namespace RegentHealthBookingSystem
{
    class BookingSystem
    {
        // Guardamos al paciente actual aquí
        private Patient currentPatient;

        // Método para crear el paciente usando el "molde" que ya hiciste
        public void CreatePatient(string name)
        {
            currentPatient = new Patient(name);
        }

        // Método para poder leer los datos del paciente desde el Program.cs
        public Patient GetCurrentPatient()
        {
            return currentPatient;
        }
    }
}