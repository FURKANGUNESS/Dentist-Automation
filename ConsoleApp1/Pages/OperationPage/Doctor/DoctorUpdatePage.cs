using System;
using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Doctor
{
    public class DoctorUpdatePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new DoctorMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();
            
            // Güncellenecek alanlar alınır.
            var inputs = Helper.MultiTextInput("Doktor Güncelleme", new List<string>
            {
                "TC No",
                "Uzmanlık",
                "Telefon"
            });
            
            // TC No'nun kontrolü yapılır, yanlışsa hata verdirilir.
            long tmp;
            var status = long.TryParse(inputs[0], out tmp);
            
            if (inputs[0].Length != 11 || !status)
            {
                Console.WriteLine("TC No doğru girilmelidir.");
                return;
            }

            // Saklama alanından TC No ile eşleşen doktor getirilir, bulunamazsa hata verdirilir.
            var doctor = storage.Doctors.Get(x => x.IdentityNumber == inputs[0]);

            if (doctor == null)
            {
                Console.WriteLine($"'{inputs[0]}' TC No'ya sahip doktor bulunamadı.");
                return;
            }

            // Doktor güncellenir.
            doctor.Profession = inputs[1];
            doctor.Phone = inputs[2];
            
            storage.Doctors.Update(doctor);
            storage.Save();

            Console.WriteLine("Doktor Güncelleme Başarılı.");
        }
    }
}