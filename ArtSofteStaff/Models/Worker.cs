using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSofteStaff.Models
{   
    public class Worker
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public char Sex { get; set; }
        public int UnitID { get; set; }
        public int LanguageID { get; set; }
        public Unit Unit { get; set; }
        public Language Language { get; set; }
    }
}
