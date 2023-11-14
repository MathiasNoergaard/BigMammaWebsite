using System.ComponentModel.DataAnnotations;

namespace BigMammaWebsite.Models
{
    public class Event
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Description { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } //use DateOnly or DateTime

        [Required]
        [Range(1, 100)]
        public int Price { get; set; }

        public Event() { }
        public Event(int iD, string name, string description, string city, DateTime dateTime, int price)
        {
            ID = iD;
            Name = name;
            Description = description;
            City = city;
            DateTime = dateTime;
            Price = price;
        }
    }
}
