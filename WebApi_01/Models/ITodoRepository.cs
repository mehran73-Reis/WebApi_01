using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_01.Models
{
    public interface ITodoRepository
    {
        void Add(Todoitem item);
        void Update(Todoitem item);

        Todoitem Find(string Key);
        Todoitem Remove(string Key);

        IEnumerable<Todoitem> GetAll();
    }
}
