using ConsoleApp1.Entities.Abstract;

namespace ConsoleApp1.Entities
{
    // Randevu entitysi
    public class Appointment : Entity
    {
        public int DoctorId { get; }
        public int PatientId { get; }
        public string Date { get; set; }

        // Yapıcı fonksiyonda id propertylerini kalıtım alır
        public Appointment(int doctorId, int patientId)
        {
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}