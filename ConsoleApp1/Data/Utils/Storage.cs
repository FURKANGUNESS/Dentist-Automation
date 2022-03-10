using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp1.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1.Data.Utils
{
    // Saklama operasyonlarının yönetildiği class
    public sealed class Storage
    {
        // Doktor entitylerinin saklandığı property
        public BaseTable<Doctor> Doctors { get; }
        // Hasta entitylerinin saklandığı property
        public BaseTable<Patient> Patients { get; }
        // Randevu entitylerinin saklandığı property
        public BaseTable<Appointment> Appointments { get; }
        // Muayene entitylerinin saklandığı property
        public BaseTable<Examination> Examinations { get; }

        // Singleton tasarım desenini uygulamak için var olan property
        private static Storage _instance;
        // Id'lerin çakışmamasını sağlamak adına var olan obje
        public int AutoincrementId { get; private set; }
        
        // data.json dosyasının var olup olmadığı sorgulanır, varsa içerisindeki bilgiler alınıp yukarıdaki
        // propertyler set edilir, yoksa dosya oluşturulur, propertyler boş olarak set edilir.
        private Storage()
        {
            var exists = File.Exists("data.json");
            
            if (!exists)
            {
                Doctors = new DoctorTable(new List<Doctor>());
                Patients = new PatientTable(new List<Patient>());
                Appointments = new AppointmentTable(new List<Appointment>());
                Examinations = new ExaminationTable(new List<Examination>());
                AutoincrementId = 1;
                Save();
                return;
            }
            
            var jsonStr = File.ReadAllText("data.json");
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);

            var doctorEntities = ((JArray) dictionary["Doctors"]).ToObject<List<Doctor>>();
            var patientEntities = ((JArray) dictionary["Patients"]).ToObject<List<Patient>>();
            var appointmentEntities = ((JArray) dictionary["Appointments"]).ToObject<List<Appointment>>();
            var examinationEntities = ((JArray) dictionary["Examinations"]).ToObject<List<Examination>>();

            Doctors = new DoctorTable(doctorEntities);
            Patients = new PatientTable(patientEntities);
            Appointments = new AppointmentTable(appointmentEntities);
            Examinations = new ExaminationTable(examinationEntities);
            AutoincrementId = Convert.ToInt32(dictionary["IncrementIndex"]);
        }

        // Propertylerin güncellemenmesi akabininde çalıştırılan fonksiyon.
        // Propertylerin içindeki bilgileirin dosyaya aktarılması operasyonu.
        public void Save()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"Doctors", Doctors.GetList()},
                {"Patients", Patients.GetList()},
                {"Appointments", Appointments.GetList()},
                {"Examinations", Examinations.GetList()},
                {"IncrementIndex", AutoincrementId}
            };
            
            var jsonStr = JsonConvert.SerializeObject(dictionary);
            
            File.WriteAllText("data.json", jsonStr);
        }

        // Singleton tasarım deseninin uygulanması sonucunda var olan metod
        public static Storage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Storage();
            }

            return _instance;
        }

        // Id generate etme fonksiyonu
        public static int? GetId()
        {
            if (_instance == null)
            {
                return null;
            }
            
            return _instance.AutoincrementId++;
        }
    }
}