using System;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Doctor
{
    public class DoctorGetPage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new DoctorMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();
            
            Console.WriteLine("--Doktor Görüntüleme--\n");
            // Doktorun TC NO'su alınır
            var input = Helper.SingleTextInput("TC No");

            // TC No'ya denk gelen doktor saklama alanından alınır, denk gelen bir doktor yoksa hata verilir
            var doctor = storage.Doctors.Get(x => x.IdentityNumber == input);

            if (doctor == null)
            {
                Console.WriteLine($"'{input}' TC No'lu doktor bulunamadı.");
                return;
            }
            
            // Doktor bilgieri console'a bastırılır.
            Console.WriteLine(doctor.ToString());
        }
    }
}