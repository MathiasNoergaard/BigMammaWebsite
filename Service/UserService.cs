using BigMammaWebsite.Models;

namespace BigMammaWebsite.Service
{
    public class UserService
    {
        private static List<User> _userList { get; set; } = new();

        private JsonFileUserService JsonFileUserService { get; set; } 

        public UserService(JsonFileUserService jsonFilePizzaService)
        {
            JsonFileUserService = jsonFilePizzaService;
            //JsonFilePizzaService.SaveJsonPizzas(_pizzaDictionary.Values.ToList());
            _userList = JsonFileUserService.GetJsonUsers().ToList();
        }

        public List<User> GetItems()
        {
            return _userList;
        }

        public bool AddUser(User user)
        {
            if (MatchUsername(user)) return false;
            if(_userList.Count != 0)
            {
                user.ID = _userList.ElementAt(_userList.Count - 1).ID + 1;
            }
            else
            {
                user.ID = 1;
            }
            _userList.Add(user);
            JsonFileUserService.SaveJsonUsers(_userList);
            Pages.Sign_up_in_out.SignInModel.sessionID = user.ID;
            return true;
        }

        public static string GetUsernameByID(int id)
        {
            foreach(User user in _userList)
            {
                if (user.ID == id)
                    return user.Username;
            }
            return null;
        }

        //public Pizza? GetPizza(int id)
        //{
        //    foreach (Pizza pizza in _pizzaList)
        //    {
        //        if (pizza.ID == id)
        //        {
        //            return pizza;
        //        }
        //    }
        //    return null;
        //    //return (_pizzaDictionary.ContainsKey(id)) ? _pizzaDictionary[id] : null;
        //}

        //public Pizza? GetPizzaOld(int id)
        //{
        //    return (_pizzaDictionary.ContainsKey(id)) ? _pizzaDictionary[id] : null;
        //}

        //public void UpdatePizza(Pizza pizza)
        //{
        //    if (pizza == null) return;
        //    foreach (Pizza _pizza in _pizzaList)
        //    {
        //        if (_pizza.ID == pizza.ID)
        //        {
        //            _pizza.Name = pizza.Name;
        //            _pizza.Topping = pizza.Topping;
        //            _pizza.Price = pizza.Price;
        //        }
        //    }
        //    JsonFilePizzaService.SaveJsonPizzas(_pizzaList);
        //}

        public void DeleteUser(int id)
        {
            User temp = null;
            foreach (User user in _userList)
            {
                if (id == user.ID)
                {
                    temp = user;
                    break;
                }
            }
            if (temp != null)
            {
                _userList.Remove(temp);
                JsonFileUserService.SaveJsonUsers(_userList);
            }
        }

        //public bool AttemptLogin(string username, string password)
        //{
        //    foreach(User user in _userList)
        //    {
        //        if (username == user.Username && password == user.Password)
        //            return true;
        //    }

        //    return false;
        //}

        public static bool SignOut()
        {
            if (Pages.Sign_up_in_out.SignInModel.sessionID == -1)
                return false; //sign out failed
            Pages.Sign_up_in_out.SignInModel.sessionID = -1;
            return true; //sign out successful
        }

        public bool AttemptLogin(User userAttempt)
        {
            foreach (User user in _userList)
            {
                if (userAttempt.Username == user.Username && userAttempt.Password == user.Password)
                {
                    Pages.Sign_up_in_out.SignInModel.sessionID = user.ID;
                    Console.WriteLine(Pages.Sign_up_in_out.SignInModel.sessionID);
                    return true;
                }
            }
            
            return false;
        }

        public bool MatchUsername(User userAttempt)
        {
            foreach (User user in _userList)
            {
                if (userAttempt.Username == user.Username)
                    return true;
            }
            return false;
        }
    }
}
