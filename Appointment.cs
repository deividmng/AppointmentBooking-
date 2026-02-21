using System;

namespace RegentHealthBookingSystem
{
    class Appointment
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public Appointment(int typeOption, DateTime date)
        {
            Date = date;
            SetTypeAndPrice(typeOption);
        }

        private void SetTypeAndPrice(int option)
        {
            // Requirement: Pricing table implementation
            switch (option)
            {
                case 1: Type = "General Consultation"; Price = 35; break;
                case 2: Type = "Nurse Check-up"; Price = 20; break;
                case 3: Type = "Blood Test"; Price = 15; break;
                case 4: Type = "Specialist Consultation"; Price = 60; break;
            }
        }
    }
}