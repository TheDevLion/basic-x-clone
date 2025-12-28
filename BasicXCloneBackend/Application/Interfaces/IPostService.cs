using BasicXCloneBackend.Application.DTOs;
using BasicXCloneBackend.Domain.Entities;

namespace BasicXCloneBackend.Application.Interfaces
{
	public interface IPostService
	{
        Task<int> CreatePost(PostDTO newPostDTO);
        Task<List<PostDTO>> FilterPostsByKeywords(string keywords, int page);
    }
}


