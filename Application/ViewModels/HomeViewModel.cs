using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class HomeViewModel
    {
        public List<SerieViewModel> Series { get; set; }
        public List<ProducerViewModel> Producers { get; set; }
    }
}
