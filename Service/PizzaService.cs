using BigMammaWebsite.Models;

namespace BigMammaWebsite.Service
{
    public class PizzaService
    {
        private Dictionary<int, Pizza> _pizzaDictionary { get; } = new()
        {
            {1, new(1, "Margherita", "Tomat & ost",new() {Topping.Toppings.Ananas}, 77) },
            {2, new(2, "Vesuvio", "Tomat, ost & skinke",new() {Topping.Toppings.Ananas}, 0)},
            {3, new(3, "Caprioccisa", "Tomat, ost, skinke & champignon",new() {Topping.Toppings.Ananas}, 0)},
            {4, new(4, "Calzone", "Indbagt pizza med tomat, ost & skinke",new() {Topping.Toppings.Ananas}, 0)},
            {5, new(5, "Quattro Stagioni", "tomat, ost, skinke champignon, rejer & paprika",new() {Topping.Toppings.Ananas}, 0)},
            {6, new(6, "Marinara", "Tomat, ost, rejer, muslinger & hvidløg",new() {Topping.Toppings.Ananas}, 0)},
            {7, new(7, "Vegetariana", "Tomat, ost & grønsager",new() {Topping.Toppings.Ananas}, 0)}
        };
       
        public List<Pizza> GetItems()
        {
            return _pizzaDictionary.Values.ToList();
        }

        public void AddPizza(Pizza pizza)
        {
            if (_pizzaDictionary.Count != 0)
            {
                pizza.ID = _pizzaDictionary.Keys.Max() + 1;
            } else {
                pizza.ID = 1;
            }
            _pizzaDictionary.Add(pizza.ID, pizza);
        }

        public Pizza? GetPizza(int id)
        {
            return (_pizzaDictionary.ContainsKey(id)) ? _pizzaDictionary[id] : null;
        }

        public void UpdatePizza(Pizza pizza)
        {
            if (pizza == null) return;
            _pizzaDictionary[pizza.ID] = pizza;
        }

        public void DeletePizza(Pizza pizza)
        {

        }
    }
}
