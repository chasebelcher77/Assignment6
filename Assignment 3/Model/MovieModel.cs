using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Model
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Release Date is required.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")]
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        [Required(ErrorMessage = "Rating is required.")]
        public int Rating { get; set; }

      
        [Display(Name = "Movie Image")]
        public string Image { get; set; } = "/images/Movies/mov.jpg";
    }
}


