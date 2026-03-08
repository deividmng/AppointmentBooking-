using System;
using System.Collections.Generic;
using System.Linq;

namespace RegentHealthBookingSystem
{
    class BookingSystem
    {
        // required fields per specification
        private Patient? currentPatient;
        private Appointment? currentAppointment;
        private string[] activityLog = new string[3];

        // history for analysis
        private List<Patient> patients = new List<Patient>();

        // activity logging helper
        public void LogAction(string action)
        {
            for (int i = 0; i < activityLog.Length - 1; i++)
            {
                activityLog[i] = activityLog[i + 1];
            }
            activityLog[activityLog.Length - 1] = action;
        }

        public string[] GetRecentActions()
        {
            return activityLog.Where(a => !string.IsNullOrEmpty(a)).ToArray();
        }

        public void CreatePatient(string name)
        {
            currentPatient = new Patient(name);
            patients.Add(currentPatient);
            LogAction("Patient created: " + name);
        }

        public Patient? GetCurrentPatient()
        {
            return currentPatient;
        }

        public Appointment? GetCurrentAppointment()
        {
            return currentAppointment;
        }

        public void BookAppointment(int typeOption, DateTime date, string time)
        {
            if (currentPatient == null)
                throw new InvalidOperationException("No patient selected");

            currentAppointment = new Appointment(typeOption, date, time);
            currentPatient.Appointment = currentAppointment;
            LogAction("Booked " + currentAppointment.AppointmentType);
        }

        public void ClearCurrentBooking()
        {
            currentPatient = null;
            currentAppointment = null;
            LogAction("Cleared current booking");
        }

        public List<Patient> GetAllPatients()
        {
            return patients.OrderByDescending(p => p.Appointment?.Price ?? 0).ToList();
        }

        public (string? highestType, string? lowestType) GetHighestLowestCostTypes()
        {
            var booked = patients.Where(p => p.Appointment != null).ToList();
            if (booked.Count == 0) return (null, null);
            var sorted = booked.OrderBy(p => p.Appointment!.Price).ToList();
            return (sorted.Last().Appointment!.AppointmentType, sorted.First().Appointment!.AppointmentType);
        }
    }
}


