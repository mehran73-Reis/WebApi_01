using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_01.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, Todoitem> _todos =
            new ConcurrentDictionary<string, Todoitem>();

        public TodoRepository()
        {
            Add(new Todoitem { Name = "Item1" });
        }
        public void Add(Todoitem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public void Update(Todoitem item)
        {
            _todos[item.Key] = item;
        }

        public Todoitem Find(string Key)
        {
            Todoitem item;
            _todos.TryGetValue(Key, out item);
            return item;
        }

        public Todoitem Remove(string Key)
        {
            Todoitem item;
            _todos.TryRemove(Key, out item);
            return item;
        }

        public IEnumerable<Todoitem> GetAll()
        {
            return _todos.Values;
        }
    }
}
