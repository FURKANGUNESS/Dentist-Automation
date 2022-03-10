using System;
using System.Linq;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1.Pages.OperationPage.Doctor
{
    public class DoctorGetListPage : Page
    {
        public override void Run()
        {
            // İşlem sonunda geçilecek olan sayfa set edilir
            PageManager.ChangePage(new DoctorMenuPage());
            
            // Singleton tasarım deseni uygulanmış olan Storage classından instance alınır
            var storage = Storage.GetInstance();

            // Doktorlar listelenmek üzere saklama alanınan alınır, bastırılır.
            var doctors = storage.Doctors.GetList();

            var index = 1;
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{index++} - {doctor}");
            }

            // Dönen liste boşsa if içerisindeki mesaj bastırılır.
            if (!doctors.Any())
            {
                Console.WriteLine("Doktor Yok");    
            }
        }
    }
}