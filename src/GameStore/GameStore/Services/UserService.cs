namespace GameStore.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Utilities;

    public class UserService : IUserService
    {
        private readonly GameStoreContext context;

        public UserService() => this.context = new GameStoreContext();

        public bool Create(string email, string password, string fullName)
        {
            using (this.context)
            {
                if (this.context.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !this.context.Users.Any();
                var passwordHash = PasswordUtilities.GetPasswordHash(password);

                var user = new User
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    FullName = fullName,
                    IsAdmin = isAdmin
                };

                this.context.Add(user);
                this.context.SaveChanges();

                return true;
            }
        }

        public bool UserExists(string email, string password)
        {
            var passwordHash = PasswordUtilities.GetPasswordHash(password);

            return this.context
                .Users
                .Any(u => u.Email == email && u.PasswordHash == passwordHash);
        }
    }
}