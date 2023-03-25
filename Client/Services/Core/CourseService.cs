using DOG.Client.Services.Common;
using DOG.Shared.DTO;

namespace DOG.Client.Services.Core
{
    public class CourseService : BaseService<CourseDTO>
    {
        public CourseService(HttpClient client) 
            : base(client, "Course")
        {
        }
    }
}
