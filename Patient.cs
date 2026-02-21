using System;

namespace RegentHealthBookingSystem
{
    // The Patient class acts as a template for storing person-specific data
    class Patient
    {
        // Mandatory private fields (Encapsulation)
        // These are private to protect the data from direct external modification
        private string fullName;
        private string email;

        // Public properties (Getters) 
        // These allow other classes to READ the name and email safely
        public string FullName { get { return fullName; } }
        public string Email { get { return email; } }

        // The Constructor: This runs automatically when you create a 'new Patient'
        public Patient(string name)
        {
            // Requirement: Store the full name provided
            fullName = name;

            // Requirement: Auto-generate email based on name rules
            // Logic: Convert to lowercase, remove spaces, and append domain
            email = name.Replace(" ", "").ToLower() + "@regenthealth.com";
        }
    }
}