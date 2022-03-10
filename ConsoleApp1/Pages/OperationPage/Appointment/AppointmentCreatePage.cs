using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;
using ConsoleApp1.Pages.Validation;

namespace ConsoleApp1.Pages.OperationPage.Appointment
{
    // Randevu oluşturma sayfası
    public class AppointmentCreatePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new AppointmentMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();

            // Doktor seçimi yaptırabilmek için var olan tüm doktorlar alınır
            var doctors = storage.Doctors.GetList();
            
            // Doktor seçimi yaptırılır
            var selectedDoctor = Helper.MakeSelection("Doktor Seçimi", doctors);

            // Yanlış değer girilmişse null döneceğinden kontrol sağlanır
            if (selectedDoctor == null)
            {
                return;
            }

            // Hasta bilgileri alınır
            var patientInputs = Helper.MultiTextInput("Hasta", new List<string>
            {
                "Ad / Soyad",
                "TC No",
                "Telefon",
                "Cinsiyet"
            });

            // Tarih bilgisi alınır
            var date = Helper.SingleTextInput("Tarih");

            // Girilen TC ile eşleşen hasta bulunur
            var patient = storage.Patients.Get(x => x.IdentityNumber == patientInputs[1]);

            // Hasta yoksa oluşturulur, kontrol edilir, saklama alanına eklenir
            if (patient == null)
            {
                patient = new Entities.Patient
                {
                    FullName = patientInputs[0],
                    IdentityNumber = patientInputs[1],
                    Phone = patientInputs[2],
                    Gender = patientInputs[3]
                };

                var status = PersonValidation.Validate(patient);

                if (!status)
                {
                    return;
                }
                
                storage.Patients.Add(patient);
            }

            // Hastanın randevusu bulunur
            var appointment =
                storage.Appointments.Get(x => x.DoctorId == selectedDoctor.Id && x.PatientId == patient.Id);

            // Randevu varsa hata verdirilir hasta saklama alanına kaydedilir
            if (appointment != null)
            {
                Console.WriteLine("Hasta için randevu zaten mevcut.");
                storage.Save();
                return;
            }
            
            // Randevusu yoksa randevu oluşturulur
            storage.Appointments.Add(new Entities.Appointment(selectedDoctor.Id, patient.Id)
            {
                Date = date
            });
            
            storage.Save();
        }
    }
}