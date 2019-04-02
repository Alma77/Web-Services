using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_05.Models
{
    public class Country
    {
        public string Capital { get; set; }
        public int Population { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public List<Languages> Languages { get; set; }
    }

    public class Languages
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
    }
}
