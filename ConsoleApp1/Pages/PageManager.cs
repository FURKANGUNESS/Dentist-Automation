using ConsoleApp1.Pages.Abstract;

namespace ConsoleApp1.Pages
{
    // Sayfaları yöneten class
    public class PageManager
    {
        // Bünyesinde Page barındırır.
        private Page _page;

        // Yapıcı fonksiyonunda page alır
        public PageManager(Page page)
        {
            ChangePage(page);
        }

        // Mevcut sayfayı sonradan güncelleme olanağına sahiptir
        public void ChangePage(Page page)
        {
            _page = page;
            _page.ChangePageManager(this);
        }
        
        // Bünyesinde barındırdığı Page'in run fonksiyonunu çalıştırmak için var olan metod
        public void Run()
        {
            _page.Run();
        }
    }
}