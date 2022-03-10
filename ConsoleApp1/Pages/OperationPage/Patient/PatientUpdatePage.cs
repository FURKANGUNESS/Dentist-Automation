using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Patient
{
    public class PatientUpdatePage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new PatientMenuPage());

            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();

            // Seçtirilmek üzere hastalar listelenir
            var patients = storage.Patients.GetList();
            var selectedPatient = Helper.MakeSelection("Hasta Seçiniz", patients);

            if (selectedPatient == null)
            {
                return;
            }

            // telefon bilgisi alınır
            var input = Helper.SingleTextInput("Telefon");

            // Hasta güncellenir
            selectedPatient.Phone = input;
            
            storage.Patients.Update(selectedPatient);
            storage.Save();
        }
    }
}