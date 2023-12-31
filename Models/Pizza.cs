﻿using System.ComponentModel.DataAnnotations;
using BigMammaWebsite.Models;

namespace BigMammaWebsite.Models
{
    public class Pizza
    {
        
        public int ID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage ="Navn skal mindst 3 tegn")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Navn skal starte med stort")]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Topping skal mindst 3 tegn")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Topping skal starte med stort")]
        public string Topping { get; set; }

        [Required]
        [Range(10, 100, ErrorMessage = "Pris skal være mindst 10 og max 100")]
        public int Price { get; set; }

        public Pizza() { }

        public Pizza(int iD, string name, string topping, int price)
        {
            ID = iD;
            Name = name;
            Topping = topping;
            Price = price;
        }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID.ToString()}, {nameof(Name)}={Name}, {nameof(Topping)}={Topping}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
