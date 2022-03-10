namespace ConsoleApp1.Entities
{
    // Doktor entitysi
    public class Doctor : Person
    {
        // Listelenmesi yapılırken tostring'e düzgün dönüştürülebilmesi için override edildi.
        public override string ToString()
        {
            return $"{Id}, {FullName}, {IdentityNumber}, {Profession}, {Phone}, {Gender}";
        }

        public string Profession { get; set; }
    }
}