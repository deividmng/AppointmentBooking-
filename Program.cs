using System; // Required to use Console methods like WriteLine and ReadLine
using System.Linq; // <--- AÑADIDO: Necesario para usar .All()

namespace RegentHealthBookingSystem
{
    class Program
    {
        // The Main method is the entry point of the application
        // This is where the execution starts (like index[0] for the CPU)
        static void Main(string[] args)
        {
            // PASO VITAL: Creamos el sistema antes de los bucles
            BookingSystem system = new BookingSystem();
            
            // Requirement 1: Login System
            // Declare the boolean as false initially because the userD is not yet logged in
            bool isAuthenticated = false;

            Console.WriteLine("--- System Of Gestion Regent Health ---");

            // Loop continues while isAuthenticated is false (! means NOT)
            while (!isAuthenticated)
            {
                // Asking the user to input the username 
                Console.Write("\nUsername: ");
                string user = Console.ReadLine();

                // Asking the user for the password 
                Console.Write("Password: ");
                string passWord = Console.ReadLine();

                // Validation: Check if credentials match the predefined requirements
                // We use '&&' (AND) because both conditions must be true
                if (user == "D" && passWord == "R")
                {
                    // If credentials match, set boolean to true to exit the loop
                    isAuthenticated = true;
                    Console.WriteLine("\n✓ Login successful. Welcome, Doctor!");
                }
                else
                {
                    // In case of an error, display this warning and the loop restarts
                    Console.WriteLine("\n✗ Incorrect credentials. Please try again.");
                }
            }

            // El menú principal se ejecuta mientras el usuario esté autenticado
            while (isAuthenticated == true)
            {
                Console.WriteLine("\n--- Regent Health Menu ---");
                Console.WriteLine("1. Enter Patient Details");
                Console.WriteLine("2. Book Appointment");
                Console.WriteLine("3. View Booking Summary");
                Console.WriteLine("4. View Highest & Lowest Cost");
                Console.WriteLine("5. View Activity Log");
                Console.WriteLine("6. Clear Booking");
                Console.WriteLine("7. Logout");
                Console.Write("Select option: ");

                string option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Console.Write("Enter patient full name: ");
                        string name = Console.ReadLine();

                        // Validación: Que no esté vacío y que solo sean letras/espacios
                        if (string.IsNullOrWhiteSpace(name) || !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                        {
                            Console.WriteLine("✗ Error: Invalid name. Use only letters.");
                        }
                        else
                        {
                            // Llamamos al sistema para que cree al paciente
                            system.CreatePatient(name);
                            
                            // Mostramos que funcionó usando los Getters que creaste en Patient.cs
                            Console.WriteLine("\n✓ Patient details registered!");
                            Console.WriteLine("Name: " + system.GetCurrentPatient().FullName);
                            Console.WriteLine("Email: " + system.GetCurrentPatient().Email);
                        }
                        break;

                    case "7":
                        isAuthenticated = false;
                        Console.WriteLine("Logged out.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } // <--- CORRECCIÓN: Aquí cerraba correctamente el bucle del menú

            // Once the loop ends, the program moves to this line
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}