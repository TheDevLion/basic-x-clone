using BasicXCloneBackend.Application.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace BasicXCloneBackend.BasicXCloneAPI.SwaggerExamples
{
	public class CreateNewRepostExample
	{
        public class CreateNewRepostRequestExample : IExamplesProvider<CreateNewRepostRequest>
        {
            public CreateNewRepostRequest GetExamples()
            {
                return new CreateNewRepostRequest(1, "neymarjr");
            }
        }
    }
}


