namespace BigMammaWebsite.Models
{
    public class OrderLine
    {
        public Pizza PizzaType { get; set; }
        public int Amount { get; set; }

        public OrderLine() { }
    }
}
