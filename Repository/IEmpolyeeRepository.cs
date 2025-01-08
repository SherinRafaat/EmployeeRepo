using taskinterview.Model;

namespace taskinterview.Repository
{
    public interface IEmpolyeeRepository
    {
        
            IEnumerable<Empolyee> GetAll(string? filter = null);
            Empolyee GetById(int id);
            void Add(Empolyee employee);
            void Update(Empolyee employee);
            void Delete(int id);
            void Save();
        




    }
}
