  
using System.Collections.Generic;

namespace amazen.Interfaces
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T Create(T data);
        T GetById(int id);
        T Update(T data);
    }
}