
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        [Display(Name = "Guest")]


        [Required(ErrorMessage = "Numele vizitatorului este obligatoriu.")]
        public string Name { get; set; }

        // Alte proprietăți
        public List<Exhibition> ExhibitionsAttended { get; set; }
    }
}
