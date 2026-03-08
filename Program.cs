using System;
using System.Linq;

namespace RegentHealthBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BookingSystem system = new BookingSystem();
            bool isAuthenticated = false;
            string user = string.Empty;

            Console.WriteLine("--- System Of Gestion Regent Health ---");

            // login loop using specified credentials
            while (!isAuthenticated)
            {
                Console.Write("\nUsername: ");
                user = Console.ReadLine() ?? string.Empty;
                Console.Write("Password: ");
                string passWord = Console.ReadLine() ?? string.Empty;

                if (user == "d" && passWord == "r")
                {
                    isAuthenticated = true;
                    system.LogAction("Logged in successfully");
                    Console.WriteLine("\n✓ Login successful. Welcome, Doctor " + user + "!");
                }
                else
                {
                    Console.WriteLine("\n✗ Incorrect credentials. Please try again.");
                }
            }

            while (isAuthenticated)
            {
                var recent = system.GetRecentActions();
                if (recent.Length > 0)
                {
                    Console.WriteLine("\n--- Recent actions ---");
                    foreach (var act in recent)
                        Console.WriteLine(act);
                    Console.WriteLine("-----------------------");
                }

                Console.WriteLine("\n--- Regent Health Menu ---");
                Console.WriteLine("1. Enter Patient Details & Book");
                Console.WriteLine("3. View Booking Summary");
                Console.WriteLine("4. View Highest/Lowest Cost Appointment Type");
                Console.WriteLine("5. Clear Current Booking");
                Console.WriteLine("6. Logout");
                Console.Write("Select option: ");
                string option = Console.ReadLine()?.Trim() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        Console.Write("\nEnter patient full name: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(name) || !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                        {
                            Console.WriteLine("✗ Error: Invalid name.");
                        }
                        else
                        {
                            system.CreatePatient(name);

                            Console.WriteLine("\n--- Select Appointment Type ---");
                            Console.WriteLine("1. General Consultation (£35)");
                            Console.WriteLine("2. Nurse Check-up (£20)");
                            Console.WriteLine("3. Blood Test (£15)");
                            Console.WriteLine("4. Specialist Consultation (£60)");
                            Console.Write("Choice: ");
                            int choice;
                            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                                Console.WriteLine("Invalid choice. Enter 1-4:");

                            Console.Write("Enter date (yyyy-MM-dd): ");
                            DateTime date;
                            while (!DateTime.TryParseExact(Console.ReadLine() ?? string.Empty, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date)
                            || date.Date <= DateTime.Today)
                            {
                                Console.WriteLine("Invalid date. Enter future date yyyy-MM-dd:");
                            }

                            Console.Write("Enter time (HH:mm): ");
                            string time;
                            while (true)
                            {
                                time = Console.ReadLine() ?? string.Empty;
                                if (TimeSpan.TryParseExact(time, @"hh\:mm", null, out _)) break;
                                Console.WriteLine("Invalid time. Use HH:mm format:");
                            }

                            system.BookAppointment(choice, date, time);
                            Console.WriteLine("\n✓ Appointment booked for " + name + "!\n");
                        }
                        break;

                    case "3":
                        var patient = system.GetCurrentPatient();
                        var appointment = system.GetCurrentAppointment();
                        if (patient == null || appointment == null)
                        {
                            Console.WriteLine("\n[!] No current booking available.");
                        }
                        else
                        {
                            Console.WriteLine("\n===== CURRENT BOOKING =====");
                            Console.WriteLine("Name : " + patient.FullName);
                            Console.WriteLine("Email: " + patient.Email);
                            Console.WriteLine("Type : " + appointment.AppointmentType);
                            Console.WriteLine("Date : " + appointment.AppointmentDate.ToString("yyyy-MM-dd"));
                            Console.WriteLine("Time : " + appointment.AppointmentTime);
                            Console.WriteLine("Price: £" + appointment.Price);
                            Console.WriteLine("Class: " + appointment.Classification);
                            Console.WriteLine("===========================\n");
                            system.LogAction("Viewed booking summary");
                        }
                        break;

                    case "4":
                        var (high, low) = system.GetHighestLowestCostTypes();
                        if (high == null)
                        {
                            Console.WriteLine("\n[!] No bookings to analyse.");
                        }
                        else
                        {
                            Console.WriteLine("\nHighest cost appointment type: " + high);
                            Console.WriteLine("Lowest cost appointment type: " + low);
                            system.LogAction("Viewed highest/lowest cost types");
                        }
                        break;

                    case "5":
                        system.ClearCurrentBooking();
                        Console.WriteLine("\nCurrent booking cleared.");
                        break;

                    case "6":
                        isAuthenticated = false;
                        system.LogAction("Logged out");
                        Console.WriteLine("\nLogged out successfully.");
                        break;

                    default:
                        Console.WriteLine("\n[!] Option '" + option + "' not recognized.");
                        break;
                }
            }

            Console.WriteLine("\n--- Price classification examples (Part 2) ---");
            double[] samplePrices = { -5, 0, 15, 50, 100 };
            foreach (double p in samplePrices)
            {
                Console.WriteLine(p + " -> " + Classify_appointment.ClassifyAppointmentPrice(p));
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}