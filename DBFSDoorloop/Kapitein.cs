using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFSDoorloop
{
    public class Kapitein
    {
        [Key]
        public int KapiteinId { get; set; }
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public int AlcoholPercentage { get; set; }
    }
}
