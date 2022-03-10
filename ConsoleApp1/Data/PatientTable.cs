using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Data
{
    // Generic BaseTable classını Hastalar için kalıtım alır
    public class PatientTable : BaseTable<Patient>
    {
        public PatientTable(List<Patient> entities) : base(entities)
        {
        }
    }
}