using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_05.Models
{
    public class Value
    {
        public int Id { get; set; }
        public string Joke { get; set; }
    }

    public class ChuckResponse
    {
        public string Type { get; set;}
        public Value Value { get; set; }
    }
}
