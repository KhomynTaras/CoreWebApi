using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
