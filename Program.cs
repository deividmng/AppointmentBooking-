using System;
using System.Linq;

namespace RegentHealthBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializamos el sistema
            BookingSystem system = new BookingSystem();
            bool isAuthenticated = false;

            Console.WriteLine("--- System Of Gestion Regent Health ---");

            // --- SISTEMA DE LOGIN ---
            while (!isAuthenticated)
            {
                Console.Write("\nUsername: ");
                string user = Console.ReadLine();

                Console.Write("Password: ");
                string passWord = Console.ReadLine();

                if (user == "D" && passWord == "R")
                {
                    isAuthenticated = true;
                    Console.WriteLine("\n✓ Login successful. Welcome, Doctor"  + user + "!");
                }
                else
                {
                    Console.WriteLine("\n✗ Incorrect credentials. Please try again.");
                }
            }

            // --- MENÚ PRINCIPAL ---
            while (isAuthenticated)
            {
                Console.WriteLine("\n--- Regent Health Menu ---");
                Console.WriteLine("1. Enter Patient Details & Book");
                Console.WriteLine("3. View Booking Summary");
                Console.WriteLine("4.  View Highest and Lowest Cost Appointment ");
                Console.WriteLine("5. Clear Current Booking ");
                Console.WriteLine("7. Logout");
                Console.Write("Select option: ");

                // Leemos la opción y limpiamos espacios con Trim()
                string option = Console.ReadLine()?.Trim() ?? "";

                switch (option)
                {
                    case "1":
                        Console.Write("\nEnter patient full name: ");
                        string name = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(name) || !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                        {
                            Console.WriteLine("✗ Error: Invalid name.");
                        }
                        else
                        {
                            system.CreatePatient(name);
                            Console.WriteLine("\n✓ Patient registered!");

                            // Selección de Cita inmediata
                            Console.WriteLine("\n--- Select Appointment Type ---");
                            Console.WriteLine("1. General Consultation (£35)");
                            Console.WriteLine("2. Nurse Check-up (£20)");
                            Console.WriteLine("3. Blood Test (£15)");
                            Console.WriteLine("4. Specialist Consultation (£60)");
                            Console.Write("Choice: ");

                            if (int.TryParse(Console.ReadLine(), out int choice))
                            {
                                system.GetCurrentPatient().SetAppointment(choice);
                                Console.WriteLine($"\n✓ {system.GetCurrentPatient().AppointmentType} saved for {name}!");
                            }
                        }
                        break;

                    // case "3":
                    //     // OBTENER EL PACIENTE DEL SISTEMA
                    //     // var p = system.GetCurrentPatient();     
                    //     // Obtenemos la lista completa del sistema
                    //     List<Patient> todos = system.GetAllPatients();
                    //     if (todos.Count == 0) // Si no hay pacientes registrados, mostramos un mensaje de error
                    //     {
                    //         Console.WriteLine("\n******************************************");
                    //         Console.WriteLine("✗ ERROR: No hay ningún paciente registrado.");
                    //         Console.WriteLine("Por favor, usa la opción 1 primero.");
                    //         Console.WriteLine("******************************************");
                    //     }
                    //     else
                    //     {
                    //         // MOSTRAR EL RESUMEN REAL
                    //         Console.WriteLine("\n========================================");
                    //         Console.WriteLine("        PATIENT BOOKING SUMMARY         ");
                    //         Console.WriteLine("========================================");
                    //         Console.WriteLine($"Full Name:    {p.FullName}");
                    //         Console.WriteLine($"Email:        {p.Email}");
                    //         Console.WriteLine("----------------------------------------");

                    //         // 3. AÑADIMOS ESTA LÍNEA PARA VER LA FECHA EN PANTALLA
                    //             Console.WriteLine($"Date:         {p.AppointmentDate}");
                    //         if (string.IsNullOrEmpty(p.AppointmentType))
                    //         {
                    //             Console.WriteLine("Appointment:  Not selected yet.");
                    //         }
                    //         else
                    //         {
                    //             Console.WriteLine($"Service:      {p.AppointmentType}");
                    //             Console.WriteLine($"Total Price:  £{p.AppointmentPrice}");
                    //         }
                    //         Console.WriteLine("========================================");
                    //     }
                    //     break;
                    case "3":
                        // Obtenemos la lista completa del sistema
                        List<Patient> todos = system.GetAllPatients();

                        if (todos.Count == 0)
                        {
                            Console.WriteLine("\n[!] No patients registered.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- LIST OF ALL PATIENTS ---");
                            foreach (Patient p in todos)
                            {
                                Console.WriteLine("Name: " + p.FullName + " | Date: " + p.AppointmentDate + " | Total: £" + p.AppointmentPrice);
                            }
                            Console.WriteLine("-----------------------------");
                        }
                        break;
                    case "4":
                        var sortedPatients = system.GetAllPatients();

                        if (sortedPatients == null || sortedPatients.Count == 0)
                        {
                            Console.WriteLine("\n[!] No patients registered.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- PATIENTS SORTED BY PRICE (DESC) ---");
                            foreach (Patient p in sortedPatients)
                            {
                                Console.WriteLine("Name: " + p.FullName + " | Date: " + p.AppointmentDate + " | Total: £" + p.AppointmentPrice);
                            }
                            Console.WriteLine("----------------------------------------");
                        }
                        break;

                    case "5":
                        
                            Console.WriteLine("Claring current booking...");
                        
                        break;

                    case "7":
                        isAuthenticated = false;
                        Console.WriteLine("Logged out successfuly.");
                        break;

                    default:
                        Console.WriteLine($"\n[!] Option '{option}' not recognized. Try pressing 1, 3 or 7.");
                        break;
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}