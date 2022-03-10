using System.Linq;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Examination
{
    public class ExaminationCreatePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new DoctorMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();

            // Seçtirilmek üzere doktorlar listelenir, seçime denk gelen yoksa hata mesajı döndürülür
            var doctors = storage.Doctors.GetList();
            var selectedDoctor = Helper.MakeSelection("Doktor Seçiniz", doctors);

            if (selectedDoctor == null)
            {
                return;
            }

            // Doktorun randevularından hasta idleri yakalanır
            var patientIds = storage.Appointments.GetList(x => x.DoctorId == selectedDoctor.Id)
                .Select(x => x.PatientId);
            // Hasta id'lerinden hastalar yakalanır
            var patients = storage.Patients.GetList(x => patientIds.Contains(x.Id));

            // Yakalanan hastalar listelenir, seçim yaptırılır
            var selectedPatient = Helper.MakeSelection("Hasta Seçiniz", patients);

            if (selectedPatient == null)
            {
                return;
            }

            // Doktor ve hastanın randevusuna erişilir
            var appointment =
                storage.Appointments.Get(x => x.DoctorId == selectedDoctor.Id && x.PatientId == selectedPatient.Id);

            // Teşhis alınır
            var input = Helper.SingleTextInput("Teşhis");
            
            // Muayenelere ekleme yapılır
            storage.Examinations.Add(new Entities.Examination(selectedDoctor.Id, selectedPatient.Id)
            {
                Diagnosis = input
            });
            
            // Randevu sonuçlandığı için silinir
            storage.Appointments.Remove(appointment);
            
            // Saklama alanı güncellenir.
            storage.Save();
        }
    }
}