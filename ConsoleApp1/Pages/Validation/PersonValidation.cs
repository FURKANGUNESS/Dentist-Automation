using System;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Pages.Validation
{
    public static class PersonValidation
    {
        // Doğrulama static metodu Patient ve Doctor entityleri için çalışır
        public static bool Validate(Person input)
        {
            if (input.FullName == "")
            {
                Console.WriteLine("Ad boş bırakılamaz.");
                return false;
            }
            
            long tmp;
            var status = long.TryParse(input.IdentityNumber, out tmp);
            
            if (input.IdentityNumber.Length != 11 || !status)
            {
                Console.WriteLine("TC No doğru girilmelidir.");
                return false;
            }

            return true;
        }
    }
}