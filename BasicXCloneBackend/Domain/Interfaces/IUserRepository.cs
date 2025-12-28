using BasicXCloneBackend.Domain.Entities;

namespace BasicXCloneBackend.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<bool> IsUserValid(string userName);
    }
}

