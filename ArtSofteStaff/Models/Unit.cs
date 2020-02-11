using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSofteStaff.Models
{
    public class Unit
    {
        public Unit()
        {
            Workers = new List<Worker>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
