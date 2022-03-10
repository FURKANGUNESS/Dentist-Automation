namespace ConsoleApp1.Pages.Abstract
{
    // State tasarım desenindeki State'e denk gelen class.
    // Tüm sayfaların kalıtım alacağı soyut class
    public abstract class Page
    {
        // Bünyesinde sayfaları kontrol eden PageManager classından obje barındırır
        // Bu objenin ChangePage metodunu kullanarak bir sayfadan diğer sayfalara geçiş yapılabilmektedir.
        // --STATE TASARIM DESENİ--
        protected PageManager PageManager;

        public void ChangePageManager(PageManager pageManager)
        {
            PageManager = pageManager;
        }
        
        // Sayfanın çalışacağı fonksiyon
        public abstract void Run();
    }
}