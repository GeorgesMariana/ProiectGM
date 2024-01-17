using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pictura renascentista")]
        public string Name { get; set; }

        // Alte proprietăți
        public Exhibition Exhibition { get; set; }
        public int ExhibitionId { get; set; }
    }
}
