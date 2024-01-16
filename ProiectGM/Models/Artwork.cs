using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    // Artwork.cs
    public class Artwork
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul operei de artă este obligatoriu.")]
        public string Title { get; set; }

        // Alte proprietăți
        public int ExhibitionId { get; set; }
        public Exhibition Exhibition { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
