using CleanCodeLabb2.Model;

namespace CleanCodeLabb2.Repository
{
    public class UserRepository
    {
        private readonly MicroServiceDbContext _context;

        public UserRepository(MicroServiceDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
        return _context.Users;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

    }
}
