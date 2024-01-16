
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele vizitatorului este obligatoriu.")]
        public string Name { get; set; }

        // Alte proprietăți
        public List<Exhibition> ExhibitionsAttended { get; set; }
    }
}
