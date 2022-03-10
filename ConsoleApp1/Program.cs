namespace ConsoleApp1
{
    // programın çalıştığı class
    class Program
    {
        static void Main(string[] args)
        {
            // Otomasyon classından obje oluşturup, startlama operasyonu
            var automation = new Automation();
            automation.Start();
        }
    }
}