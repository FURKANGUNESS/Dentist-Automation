namespace ConsoleApp1.Entities
{
    // Hasta entitysi
    public class Patient : Person
    {
        // Listelenmesi yapılırken tostring'e düzgün dönüştürülebilmesi için override edildi.
        public override string ToString()
        {
            return $"{Id}, {FullName}, {IdentityNumber}, {Phone}, {Gender}";
        }
    }
}