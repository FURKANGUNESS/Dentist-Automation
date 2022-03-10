using System;
using System.Linq;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Patient
{
    public class PatientAppintmentsListPage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new PatientMenuPage());

            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();

            // Hastalar listelenmek üzere alınır
            var patients = storage.Patients.GetList();
            var selectedPatient = Helper.MakeSelection("Hasta Seçiniz", patients);

            if (selectedPatient == null)
            {
                return;
            }

            // Hastaların randevularına erişilir
            var appointments = storage.Appointments.GetList(x => x.PatientId == selectedPatient.Id);
            // randevulardan doktor id'lerine erişilir
            var doctorIds = appointments.Select(x => x.DoctorId);
            // Doktor id'lerinden doktorlara erişilir
            var doctors = storage.Doctors.GetList(x => doctorIds.Contains(x.Id));

            // Randevular bastırılır
            Console.WriteLine("--Randevu Listesi--\n");
            var index = 1;
            foreach (var doctor in doctors)
            {
                var date = appointments.First(x => x.DoctorId == doctor.Id).Date;
                Console.WriteLine($"{index++} - Doktor: {doctor.FullName}, Tarih: {date}");
            }
        }
    }
}