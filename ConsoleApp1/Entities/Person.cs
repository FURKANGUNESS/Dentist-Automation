using ConsoleApp1.Entities.Abstract;

namespace ConsoleApp1.Entities
{
    // Hasta ve Doktor entitylerinin kalıtım alacağı abstract class 
    public abstract class Person : Entity
    {
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}