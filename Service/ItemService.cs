using BigMammaWebsite.Models;

namespace BigMammaWebsite.Service
{
    public class ItemService : IItemService
    {
        private Dictionary<int, Event> _eventDictionary { get; } = new()
        {
            {1, new(1, "Roskilde Festival", "A lot of music", "Roskilde", new(2020, 6, 9), 0) },
            {2, new(2, "CPH Marathon", "Many Marathon runners", "Copenhagen", new(2020, 3, 6), 0)},
            {3, new(3, "CPH Distorsion", "A lot of beers", "Copenhagen", new(2019, 6, 4), 0)},
            {4, new(4, "Demo Day", "Project Presentation", "Roskilde", new(2020, 6, 9), 0)},
            {5, new(5, "VM Badminton", "Badminton", "Århus", new(2020, 10, 3), 0)}
        };
       
        public List<Event> GetItems()
        {
            return _eventDictionary.Values.ToList();
        }

        public void AddEvent(Event ev)
        {
            if (_eventDictionary.Count != 0)
            {
                ev.ID = _eventDictionary.Keys.Max() + 1;
            } else {
                ev.ID = 1;
            }
            _eventDictionary.Add(ev.ID, ev);
        }
    }
}
