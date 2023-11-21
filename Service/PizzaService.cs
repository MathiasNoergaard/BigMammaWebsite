using BigMammaWebsite.Models;

namespace BigMammaWebsite.Service
{
    public class PizzaService
    {
        private Dictionary<int, Pizza> _pizzaDictionary { get; } = new()
        {
            {1, new(1, "Margherita", "Tomat & ost", 77) },
            {2, new(2, "Vesuvio", "Tomat, ost & skinke", 0)},
            {3, new(3, "Caprioccisa", "Tomat, ost, skinke & champignon", 0)},
            {4, new(4, "Calzone", "Indbagt pizza med tomat, ost & skinke", 0)},
            {5, new(5, "Quattro Stagioni", "tomat, ost, skinke champignon, rejer & paprika", 0)},
            {6, new(6, "Marinara", "Tomat, ost, rejer, muslinger & hvidløg", 0)},
            {7, new(7, "Vegetariana", "Tomat, ost & grønsager", 0)}
        };

        private List<Pizza> _pizzaList { get; set; } = new();

        private JsonFilePizzaService JsonFilePizzaService { get; set; }

        public PizzaService(JsonFilePizzaService jsonFilePizzaService)
        {
            JsonFilePizzaService = jsonFilePizzaService;
            //JsonFilePizzaService.SaveJsonPizzas(_pizzaDictionary.Values.ToList());
            _pizzaList = JsonFilePizzaService.GetJsonPizzas().ToList();
        }

        public List<Pizza> GetItems()
        {
            return _pizzaList;
        }

        public void AddPizza(Pizza pizza)
        {
            if (_pizzaList.Count != 0)
            {
                pizza.ID = _pizzaList.ElementAt(_pizzaList.Count-1).ID + 1;
            } else {
                pizza.ID = 1;
            }
            _pizzaList.Add(pizza);
            JsonFilePizzaService.SaveJsonPizzas(_pizzaList);
        }

        public Pizza? GetPizza(int id)
        {
            foreach(Pizza pizza in _pizzaList)
            {
                if(pizza.ID == id)
                {
                    return pizza;
                }
            }
            return null;
            //return (_pizzaDictionary.ContainsKey(id)) ? _pizzaDictionary[id] : null;
        }

        public Pizza? GetPizzaOld(int id)
        {
            return (_pizzaDictionary.ContainsKey(id)) ? _pizzaDictionary[id] : null;
        }

        public void UpdatePizza(Pizza pizza)
        {
            if (pizza == null) return;
            foreach (Pizza _pizza in _pizzaList)
            {
                if (_pizza.ID == pizza.ID)
                {
                    _pizza.Name = pizza.Name;
                    _pizza.Topping = pizza.Topping;
                    _pizza.Price = pizza.Price;
                }
            }
            JsonFilePizzaService.SaveJsonPizzas(_pizzaList);
        }

        public void DeletePizza(int id)
        {
            Pizza temp = null;
            foreach(Pizza pizza in _pizzaList)
            {
                if (id == pizza.ID)
                {
                    temp = pizza;
                    break;
                }    
            }
            if(temp != null)
            {
                _pizzaList.Remove(temp);
                JsonFilePizzaService.SaveJsonPizzas(_pizzaList);
            }
        }

        public List<Pizza> FilterTopping(string topping)
        {
            List<Pizza> temp = new();
            foreach(Pizza pizza in _pizzaDictionary.Values)
            {
                if (pizza.Topping.ToLower().Contains(topping.ToLower())) 
                    temp.Add(pizza);
            }
            return temp;
        }
    }
}
