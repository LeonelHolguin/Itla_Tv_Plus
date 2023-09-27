using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveSerieViewModel
    {
        public int SerieId { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la serie")]
        public string SerieName { get; set; }

        [Required(ErrorMessage = "Debe colocar una imagen de portada")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Debe colocar un enlace al video")]
        public string VideoPath { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una productora")]
        public int ProducerId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el genero primario de la serie")]
        public int PrimaryGenderId { get; set; }

        public int SecondaryGenderId { get; set; }
        public IEnumerable<ProducerViewModel>? Producers { get; set; }
        public IEnumerable<GenderViewModel>? Genders { get; set; }
    }
}
