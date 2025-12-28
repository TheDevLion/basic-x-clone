using BasicXCloneBackend.Application.DTOs;

namespace BasicXCloneBackend.Application.Interfaces
{
	public interface IRepostService
	{
        Task<int> CreateRepost(RepostDTO newRepostDTO);
    }
}


