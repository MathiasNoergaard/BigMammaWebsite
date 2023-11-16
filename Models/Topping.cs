namespace BigMammaWebsite.Models
{
    public class Topping
    {
        public enum Toppings
        {
            PizzaBottom,
            Pepperoni,
            Cheese,
            Ananas,
            Bacon,
            Egg
        }

        int[] prices = new int[]
        {
            65,
            10,
            15,
            5,
            10,
            7
        };

    }
}
