using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }

        //Navigation property
        public ICollection<Serie>? SeriesByProducer { get; set; }
    }
}
