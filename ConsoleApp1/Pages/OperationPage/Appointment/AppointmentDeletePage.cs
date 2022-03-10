using System;
using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Appointment
{
    public class AppointmentDeletePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new AppointmentMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();
            
            // Doktorlar seçtirilmek için alınır
            var doctors = storage.Doctors.GetList();
            
            // Seçim yaptırılır
            var selectedDoctor = Helper.MakeSelection("Doktor Seçimi", doctors);

            // Yanlış seçim yapılmışsa fonksiyon sonlandırılır
            if (selectedDoctor == null)
            {
                return;
            }

            // Hasta TC'si alınır
            var input = Helper.SingleTextInput("Hasta TC No");

            // TC'den hasta bulunur
            var patient = storage.Patients.Get(x => x.IdentityNumber == input);

            // Hasta yoksa hata verdirilir
            if (patient == null)
            {
                Console.WriteLine($"'{input}' TC No'lu hasta bulunamadı.");
                return;
            }

            // Randevu bulunur
            var appointment = storage.Appointments.Get(x => x.DoctorId == selectedDoctor.Id && x.PatientId == patient.Id);

            // Randevu saklama alanından silinir
            storage.Appointments.Remove(appointment);
            storage.Save();
        }
    }
}