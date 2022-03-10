using System;
using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Doctor
{
    public class DoctorDeletePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new DoctorMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();

            Console.WriteLine("--Doktor Silme--\n");
            
            // Doktorun TC'si alınır
            var input = Helper.SingleTextInput("TC No");

            // TC'ye denk gelen doktor var mı kontrol edilir, yoksa hata verilir
            var doctor = storage.Doctors.Get(x => x.IdentityNumber == input);

            if (doctor == null)
            {
                return;
            }

            // Doktor silinir, saklama alanı kaydedilir.
            storage.Doctors.Remove(doctor);
            storage.Save();
            
            Console.WriteLine("Doktor Silme Başarılı.");
        }
    }
}