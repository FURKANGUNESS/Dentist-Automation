using System;
using System.Collections.Generic;
using ConsoleApp1.Pages.Abstract;
using ConsoleApp1.Pages.OperationPage.Patient;

namespace ConsoleApp1.Pages.Menu
{
    // Hasta sayfası
    public class PatientMenuPage : Page
    {
        // Operasyonel sayfalara geçişi sağlayan menü sayfası
        public override void Run()
        {
            var subTitles = new List<string>
            {
                "Hasta Güncelleme",
                "Hasta Randevularını Görüntüle",
                "Hasta Muayenelerini Görüntüle",
                "Önceki Menü (Doktor)",
                "Alt Menü (Ana)"
            };
            var input = Helper.MenuInput("Hasta", subTitles);

            if (input == null)
            {
                return;
            }
            
            switch (input)
            {
                case 1:
                    PageManager.ChangePage(new PatientUpdatePage());
                    break;
                case 2:
                    PageManager.ChangePage(new PatientAppintmentsListPage());
                    break;
                case 3:
                    PageManager.ChangePage(new PatientExaminationsListPage());
                    break;
                case 4:
                    PageManager.ChangePage(new DoctorMenuPage());
                    break;
                case 5:
                    PageManager.ChangePage(new HomePage());
                    break;
            }
        }
    }
}