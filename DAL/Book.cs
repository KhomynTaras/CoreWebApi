using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Author { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
