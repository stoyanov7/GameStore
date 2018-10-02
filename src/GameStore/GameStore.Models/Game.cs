namespace GameStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Trailer { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageThumbnail { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Size { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}