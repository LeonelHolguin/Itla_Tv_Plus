using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        //Navigation property
        public ICollection<Serie>? PrimarySeries { get; set; }
        public ICollection<Serie>? SecondarySeries { get; set; }
    }
}
