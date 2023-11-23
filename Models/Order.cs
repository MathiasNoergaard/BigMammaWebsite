namespace BigMammaWebsite.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public List<OrderLine> orderPizzas { get; set; } //
        
        public Order() { }
    }
}
