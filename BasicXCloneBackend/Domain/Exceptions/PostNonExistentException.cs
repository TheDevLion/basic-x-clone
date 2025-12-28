namespace BasicXCloneBackend.Domain.Exceptions
{
	public class PostNonExistentException : Exception
    {
		public PostNonExistentException(string message) : base(message) {}
	}
}


