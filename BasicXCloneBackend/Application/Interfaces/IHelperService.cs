using BasicXCloneBackend.Application.DTOs;
using BasicXCloneBackend.Domain.Enums;

namespace BasicXCloneBackend.Application.Interfaces
{
	public interface IHelperService
	{
        Task<bool> HasUserExceededDailyActions(string userName);
        Task<RepostAvailabilityStatus> IsRepostAvailableForUser(string userName, int idPost);
        Task<List<RecordDTO>> LoadRecords(int page, bool orderByDate = true);
    }
}


