// Exhibition.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectGM.Models
{
    public class Exhibition
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele expoziției este obligatoriu.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        // Alte proprietăți
        public List<Artwork> Artworks { get; set; }
        public Department Department { get; set; }
        public List<Visitor> Visitors { get; set; }
    }
}