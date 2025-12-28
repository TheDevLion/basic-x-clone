namespace BasicXCloneBackend.Domain.Exceptions
{
	public class DailyActionsExceededException : Exception
	{
        public DailyActionsExceededException(string message) : base(message) { }
    }
}


