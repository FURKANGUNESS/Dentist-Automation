using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Data
{
    // Generic BaseTable classını Doktorlar için kalıtım alır
    public class DoctorTable : BaseTable<Doctor>
    {
        public DoctorTable(List<Doctor> entities) : base(entities)
        {
        }
    }
}