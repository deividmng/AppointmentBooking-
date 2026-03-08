using System;

namespace RegentHealthBookingSystem
{
    class Patient
    {
        // field variables required
        private string fullName;
        private string email;

        // reference to appointment object
        public Appointment? Appointment { get; set; }

        public string FullName => fullName;
        public string Email => email;

        public Patient(string name)
        {
            fullName = name;
            email = name.Replace(" ", "").ToLower() + "@regenthealth.com";
        }
    }
}