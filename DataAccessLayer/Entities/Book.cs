using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Book : BaseEntity
    {
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
        public int Price { get; set; }
    }
}
