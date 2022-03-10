using ConsoleApp1.Entities.Abstract;

namespace ConsoleApp1.Entities
{
    // Muayene entitysi
    public class Examination : Entity
    {
        public int DoctorId { get; }
        public int PatientId { get; }
        public string Diagnosis { get; set; }

        public Examination(int doctorId, int patientId)
        {
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}