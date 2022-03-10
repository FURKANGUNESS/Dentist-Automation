using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;
using ConsoleApp1.Pages.Validation;

namespace ConsoleApp1.Pages.OperationPage.Doctor
{
    public class DoctorCreatePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new DoctorMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();
            
            // Doktor bilgileri alınır
            var inputs = Helper.MultiTextInput("Doktor Oluşturma", new List<string>
            {
                "Ad / Soyad",
                "Uzmanlık",
                "TC No",
                "Telefon",
                "Cinsiyet"
            });

            // Doktor objesi oluşturulur
            var doctor = new Entities.Doctor
            {
                FullName = inputs[0],
                Profession = inputs[1],
                IdentityNumber = inputs[2],
                Phone = inputs[3],
                Gender = inputs[4]
            };

            // Bİlgiler kontrol edilir
            var status = PersonValidation.Validate(doctor);

            if (!status)
            {
                return;
            }

            // Girilen TC veya Telefon başka bir kişide kullanılmışsa hata verdirilir
            var isDuplicateDoctor = storage.Doctors.GetList()
                .Any(x => x.IdentityNumber == doctor.IdentityNumber || x.Phone == doctor.Phone);
            
            var isDuplicatePatient = storage.Patients.GetList()
                .Any(x => x.IdentityNumber == doctor.IdentityNumber || x.Phone == doctor.Phone);

            if (isDuplicateDoctor || isDuplicatePatient)
            {
                Console.WriteLine("Telefon numarası veya TC No sistemde zaten kayıtlı.");
                return;
            }
            
            // Doktor eklenir, saklama alanı kaydedilir.
            storage.Doctors.Add(doctor);
            storage.Save();
            
            Console.WriteLine("Doktor Ekleme Başarılı.");
        }
    }
}