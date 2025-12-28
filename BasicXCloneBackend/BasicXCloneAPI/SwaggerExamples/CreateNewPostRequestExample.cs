using BasicXCloneBackend.Application.RequestModels;
using Swashbuckle.AspNetCore.Filters;

namespace BasicXCloneBackend.BasicXCloneAPI.SwaggerExamples
{
    public class CreateNewPostRequestExample : IExamplesProvider<CreateNewPostRequest>
    {
        public CreateNewPostRequest GetExamples()
        {
            return new CreateNewPostRequest("Example post created", "rodrigoczleo");
        }
    }
}
