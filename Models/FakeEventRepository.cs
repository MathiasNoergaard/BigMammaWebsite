namespace BigMammaWebsite.Models
{
    /*public class FakeEventRepository
    {
        
        private int nextID = 1;
        private int NextID { get { return nextID++; } }
        private Dictionary<int, Event> eventDictionary { get; }
        private static FakeEventRepository _thisRepository;
        public static FakeEventRepository GetRepository { get { return _thisRepository ?? (_thisRepository = new());  } }

        public FakeEventRepository()
        {
            eventDictionary = new();
            
            Event temp = new(NextID, "Roskilde Festival", "A lot of music", "Roskilde", new(2020, 6, 9), 0);
            eventDictionary.Add(temp.ID, temp);
            temp = new Event() { City = "dgjfdjoi" };
            temp = new(NextID, "CPH Marathon", "Many Marathon runners", "Copenhagen", new(2020, 3, 6), 0);
            eventDictionary.Add(temp.ID, temp);
            temp = new(NextID, "CPH Distorsion", "A lot of beers", "Copenhagen", new(2019, 6, 4), 0);
            eventDictionary.Add(temp.ID, temp);
            temp = new(NextID, "Demo Day", "Project Presentation", "Roskilde", new(2020, 6, 9), 0);
            eventDictionary.Add(temp.ID, temp);
            temp = new(NextID, "VM Badminton", "Badminton", "Århus", new(2020, 10, 3), 0);
            eventDictionary.Add(temp.ID, temp);
        }

        public List<Event> GetAllEvents()
        {
            return eventDictionary.Values.ToList();
        }

        public void AddEvent(Event ev)
        {
            int amount = eventDictionary.Count;
            if(amount != 0)
            {
                ev.ID = eventDictionary.Keys.Max()+1;
            } else
            {
                ev.ID = 1;
            }
            eventDictionary.Add(ev.ID,ev);
        }
       
} */
}
