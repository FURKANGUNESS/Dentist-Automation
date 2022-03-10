using System;
using System.Collections.Generic;
using ConsoleApp1.Pages.Abstract;

namespace ConsoleApp1.Pages.Menu
{
    // Ana sayfa
    public class HomePage : Page
    {
        // Alt ana sayfalara geçişi sağlayan sayfa
        public override void Run()
        {
            var input =Helper.MenuInput("Menüler", new List<string>
            {
                "Randevu",
                "Doktor",
                "Hasta"
            });

            if (input == null)
            {
                return;
            }

            switch (input)
            {
                case 1:
                    PageManager.ChangePage(new AppointmentMenuPage());
                    break;
                case 2:
                    PageManager.ChangePage(new DoctorMenuPage());
                    break;
                case 3:
                    PageManager.ChangePage(new PatientMenuPage());
                    break;
            }
        }
    }
}