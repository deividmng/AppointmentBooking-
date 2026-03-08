using System;

namespace RegentHealthBookingSystem
{
    // Part 2 utility class (no OOP used - just a static method)
    static class Classify_appointment
    {
        public static string ClassifyAppointmentPrice(double price)
        {
            if (price < 0)
                return "Invalid";
            if (price < 20)
                return "Low Cost";
            if (price < 60)
                return "Standard";
            return "Premium";
        }
    }
}