using Microsoft.AspNetCore.Components;

namespace GithubPagesBlazor.Users
{
    public partial class UserPage
    {
        [Inject]
        public UserRepository _userRepository { get; set; }

        private IList<User> users = new List<User>();

        protected override Task OnInitializedAsync()
        {
            LoadUsers();
            return Task.CompletedTask;
        }

        void LoadUsers()
        {
            users = _userRepository.Users.FindAll().ToList();
        }

        void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
            LoadUsers();
        }

        void InsertUser()
        {
            _userRepository.Insert(new User { FirstName = "first name", LastName = "last name", Email = "test@test.com" });
            LoadUsers();
        }
    }
}
