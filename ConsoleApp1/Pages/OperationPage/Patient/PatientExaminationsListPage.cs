using System;
using System.Linq;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Patient
{
    public class PatientExaminationsListPage : Page
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

            // Hasta id'den muayeneler alınır
            var examinations = storage.Examinations.GetList(x => x.PatientId == selectedPatient.Id);
            // Doktor id'ler yakalanır
            var doctorIds = examinations.Select(x => x.DoctorId);
            // Doktor id'lerden doktorlar yakalanır
            var doctors = storage.Doctors.GetList(x => doctorIds.Contains(x.Id));

            // Muayeneler bastırılır
            Console.WriteLine("--Muayene Listesi--\n");
            var index = 1;
            foreach (var examination in examinations)
            {
                var doctor = doctors.First(x => x.Id == examination.DoctorId);
                Console.WriteLine($"{index++} - Doktor: {doctor.FullName}, Teşhis: {examination.Diagnosis}");
            }
        }
    }
}