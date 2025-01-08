using taskinterview.Model;

namespace taskinterview.Repository
{
    public class EmpolyeeRepository:IEmpolyeeRepository
    {
        private readonly AppDbContext _context;

        public EmpolyeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empolyee> GetAll(string? filter = null)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(e =>
                    e.Name.Contains(filter) ||
                    e.Email.Contains(filter) ||
                    e.Phone.Contains(filter) ||
                    e.Address.Contains(filter));
            }

            return query.ToList();
        }

        public Empolyee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Add(Empolyee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Update(Empolyee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

