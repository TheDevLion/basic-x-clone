using BasicXCloneBackend.Domain.Entities;
using BasicXCloneBackend.Domain.Enums;

namespace BasicXCloneBackend.Domain.Interfaces
{
    public interface IRepostRepository
    {
        Task<List<Repost>> GetReposts();
        Task<int> CreateRepost(Repost newRepost);
        Task<bool> HasUserAlreadyRepostedThisPost(string userName, int idPost);
        Task<int> CountRepostsByUserAndDate(string userName, DateTime date);
    }
}

