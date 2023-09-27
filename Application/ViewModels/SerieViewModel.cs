using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
        public ProducerViewModel Producer { get; set; }
        public GenderViewModel PrimaryGender { get; set; }
        public GenderViewModel? SecondaryGender { get; set; }
    }
}
