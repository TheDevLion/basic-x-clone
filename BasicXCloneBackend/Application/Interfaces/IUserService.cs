using BasicXCloneBackend.Application.DTOs;

namespace BasicXCloneBackend.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<bool> IsUserValid(string? userName);
    }
}

