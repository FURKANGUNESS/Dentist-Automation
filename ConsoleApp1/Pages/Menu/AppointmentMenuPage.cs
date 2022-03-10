using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.OperationPage.Appointment;

namespace ConsoleApp1.Pages.Menu
{
    // Randevu sayfası
    public class AppointmentMenuPage : Page
    {
        // Operasyonel sayfalara geçişi sağlayan menü sayfası
        public override void Run()
        {
            var subTitles = new List<string>
            {
                "Randevu Oluşturma",
                "Randevu İptal Etme",
                "İleriki Menü (Doktor)",
                "Alt Menü (Ana)"
            };
            var input = Helper.MenuInput("Randevu", subTitles);

            if (input == null)
            {
                return;
            }

            switch (input)
            {
                case 1:
                    PageManager.ChangePage(new AppointmentCreatePage());
                    break;
                case 2:
                    PageManager.ChangePage(new AppointmentDeletePage());
                    break;
                case 3:
                    PageManager.ChangePage(new DoctorMenuPage());
                    break;
                case 4:
                    PageManager.ChangePage(new HomePage());
                    break;
            }
        }
    }
}