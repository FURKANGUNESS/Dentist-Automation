namespace ConsoleApp1.Entities.Abstract
{
    // Entitylerimizin tümünün kalıtım alacağı abstract (soyut) class
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}