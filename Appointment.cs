using System;

namespace RegentHealthBookingSystem
{
    class Appointment
    {
        // fields required by the assignment
        private string appointmentType = "";
        private DateTime appointmentDate;
        private string appointmentTime = "";
        private double price;
        private string classification = "";

        // public read-only properties
        public string AppointmentType => appointmentType;
        public DateTime AppointmentDate => appointmentDate;
        public string AppointmentTime => appointmentTime;
        public double Price => price;
        public string Classification => classification;

        public Appointment(int typeOption, DateTime date, string time)
        {
            appointmentDate = date;
            appointmentTime = time;
            SetTypeAndPrice(typeOption);
            classification = ClassifyPrice(price);
        }

        private void SetTypeAndPrice(int option)
        {
            switch (option)
            {
                case 1: appointmentType = "General Consultation"; price = 35; break;
                case 2: appointmentType = "Nurse Check-up"; price = 20; break;
                case 3: appointmentType = "Blood Test"; price = 15; break;
                case 4: appointmentType = "Specialist Consultation"; price = 60; break;
                default:
                    appointmentType = "Unknown";
                    price = 0;
                    break;
            }
        }

        private string ClassifyPrice(double price)
        {
            if (price < 0) return "Invalid";
            if (price < 20) return "Low Cost";
            if (price < 60) return "Standard";
            return "Premium";
        }
    }
}