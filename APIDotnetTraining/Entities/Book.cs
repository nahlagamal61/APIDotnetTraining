namespace APIDotnetTraining.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        
        public int BookId { get; set; }

        [Required , MaxLength(100)]
        public string BookTitle { get; set; }

        [Required, MaxLength(100)]
        public string Auther { get; set; }

        public int Version { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }
    }
}
