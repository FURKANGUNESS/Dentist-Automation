using System.Collections.Generic;
using ConsoleApp1.Data.Utils;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Data
{
    // Generic BaseTable classını Muayeneler için kalıtım alır
    public class ExaminationTable : BaseTable<Examination>
    {
        public ExaminationTable(List<Examination> entities) : base(entities)
        {
        }
    }
}