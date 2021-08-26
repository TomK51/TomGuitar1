using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomGuitar1.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public string GuitarType{ get; set;}
        public string GuitarName { get; set; }
        public decimal GuitarCost { get; set; }
        public string GuitarPicPath { get; set; }
        public decimal InsuredValue { get; set; }
        public Guitar()
        {

        }
    }
}
