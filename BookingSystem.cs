namespace RegentHealthBookingSystem
{
    class BookingSystem
    {
        private Patient currentPatient; // La variable debe llamarse igual que la que usas abajo

        public void CreatePatient(string name)
        {
            currentPatient = new Patient(name);
        }

        public Patient GetCurrentPatient()
        {
            return currentPatient; // Si esto devuelve null, el case 3 dirá "No patient found"
        }
    }
}