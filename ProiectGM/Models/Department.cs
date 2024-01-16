using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele departamentului este obligatoriu.")]
        public string Name { get; set; }

        // Alte proprietăți
        public Exhibition Exhibition { get; set; }
    }
}
