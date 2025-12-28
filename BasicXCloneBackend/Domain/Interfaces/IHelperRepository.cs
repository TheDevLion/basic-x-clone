using BasicXCloneBackend.Domain.Entities;

namespace BasicXCloneBackend.Domain.Interfaces
{
	public interface IHelperRepository
	{
        Task<List<Record>> GetSortedPostsByPage(int page);
        Task<List<Post>> GetSortedPostsByTrend(int page);
    }
}

