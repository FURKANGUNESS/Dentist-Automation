using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.OperationPage.Doctor;
using ConsoleApp1.Pages.OperationPage.Examination;

namespace ConsoleApp1.Pages.Menu
{
    // Doktor sayfası
    public class DoctorMenuPage : Page
    {
        // Operasyonel sayfalara geçişi sağlayan menü sayfası
        public override void Run()
        {
            var subTitles = new List<string>
            {
                "Doktor Oluşturma",
                "Doktor Silme",
                "Doktor Güncelleme",
                "Doktor Görüntüleme",
                "Doktor Listeleme",
                "Muayene Sonuç Girişi",
                "Önceki Menü (Randevu)",
                "İleriki Menü (Hasta)",
                "Alt Menüy (Ana)"
            };
            
            var input = Helper.MenuInput("Doktor", subTitles);

            if (input == null)
            {
                return;
            }

            switch (input)
            {
                case 1:
                    PageManager.ChangePage(new DoctorCreatePage());
                    break;
                case 2:
                    PageManager.ChangePage(new DoctorDeletePage());
                    break;
                case 3:
                    PageManager.ChangePage(new DoctorUpdatePage());
                    break;
                case 4:
                    PageManager.ChangePage(new DoctorGetPage());
                    break;
                case 5:
                    PageManager.ChangePage(new DoctorGetListPage());
                    break;
                case 6:
                    PageManager.ChangePage(new ExaminationCreatePage());
                    break;
                case 7:
                    PageManager.ChangePage(new AppointmentMenuPage());
                    break;
                case 8:
                    PageManager.ChangePage(new PatientMenuPage());
                    break;
                case 9:
                    PageManager.ChangePage(new HomePage());
                    break;
            }
        }
    }
}