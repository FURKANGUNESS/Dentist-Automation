using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Data
{
    // Generic BaseTable classını Randevular için kalıtım alır
    public class AppointmentTable : BaseTable<Appointment>
    {
        public AppointmentTable(List<Appointment> entities) : base(entities)
        {
        }
    }
}