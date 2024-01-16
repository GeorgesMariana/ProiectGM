// Author.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele autorului este obligatoriu.")]
        public string Name { get; set; }

        // Alte proprietăți
        public List<Artwork> Artworks { get; set; }
    }
}
