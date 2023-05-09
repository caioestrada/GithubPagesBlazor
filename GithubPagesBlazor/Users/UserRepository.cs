using LiteDB;

namespace GithubPagesBlazor.Users
{
    public class UserRepository
    {
        readonly LiteDatabase _db;

        public UserRepository()
        {
            _db = new LiteDatabase("Filename=githubPages.db;connection=shared");
            Users.EnsureIndex(x => x.Id);
        }

        public ILiteCollection<User> Users => _db.GetCollection<User>();

        public User GetById(int id) => Users.FindById(id);

        public void Insert(User user) => Users.Insert(user);

        public void Delete(int id) => Users.Delete(id);
    }
}
