using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GenderViewModel
    {
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del género")]
        public string GenderName { get; set; }
    }
}
