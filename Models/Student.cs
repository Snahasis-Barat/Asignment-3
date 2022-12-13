using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string standard { get; set; }
        [Required]
        public string address { get; set; }
    }
}
