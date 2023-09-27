using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }

         //FKs
        public int ProducerId { get; set; }
        public int PrimaryGenderId { get; set; }
        public int? SecondaryGenderId { get; set;}

         //Navigation Property
        public Producer? Producer { get; set; }
        public Gender? PrimaryGender { get; set; }
        public Gender? SecondaryGender { get; set; }

    }
}
