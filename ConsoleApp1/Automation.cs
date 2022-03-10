using ConsoleApp1.Pages;
using ConsoleApp1.Pages.Menu;

namespace ConsoleApp1
{
    public class Automation
    {
        public void Start()
        {
            // PageManger oluşturulur ve sürekli run edilir. Sayfalar arası geçişler sayfa içerisinden birbirine bağlı
            // Şekilkde yapılır.
            var pageManager = new PageManager(new HomePage());
            while (true)
            {
                pageManager.Run();
            }
        }
    }
}